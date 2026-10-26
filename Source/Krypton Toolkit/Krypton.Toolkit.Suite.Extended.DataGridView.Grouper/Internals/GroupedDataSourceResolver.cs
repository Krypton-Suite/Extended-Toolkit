#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Grid.Grouper;

internal static class GroupedDataSourceResolver
{
    public static bool TryResolve(object? dataSource, string? dataMember, out GroupedResolvedSource resolved)
    {
        resolved = default;

        switch (dataSource)
        {
            case null:
                return false;

            case DataTable table:
                resolved = GroupedResolvedSource.ForDataRows(CopyLiveRows(table), table);
                return true;

            case DataView view when view.Table is not null:
                resolved = GroupedResolvedSource.ForDataRows(CopyLiveRows(view), view.Table);
                return true;

            case BindingSource bs when bs.List is IList list:
                resolved = FromIListSnapshot(list, InferTable(bs));
                return true;

            case IList loose:
                resolved = FromIListSnapshot(loose, schemaTable: null);
                return true;

            default:
                return TryRelatedList(dataSource, dataMember, out resolved);
        }
    }

    private static List<DataRow> CopyLiveRows(DataTable table)
    {
        var rows = new List<DataRow>(table.Rows.Count);
        foreach (DataRow row in table.Rows)
        {
            if (row.RowState != DataRowState.Deleted)
            {
                rows.Add(row);
            }
        }

        return rows;
    }

    private static List<DataRow> CopyLiveRows(DataView view)
    {
        var rows = new List<DataRow>(view.Count);
        foreach (DataRowView drv in view)
        {
            rows.Add(drv.Row);
        }

        return rows;
    }

    private static bool TryRelatedList(object dataSource, string? _, out GroupedResolvedSource resolved)
    {
        resolved = default;

        try
        {
            if (dataSource == null)
            {
                return false;
            }

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(dataSource);
            PropertyDescriptor? listProp = props["List"];

            object? cand = listProp?.GetValue(dataSource);
            if (cand is IList list)
            {
                resolved = FromIListSnapshot(list, schemaTable: null);
                return true;
            }
        }
#pragma warning disable CA1031
        catch { }
#pragma warning restore CA1031

        return false;
    }

    private static DataTable? InferTable(BindingSource bs) => bs.DataSource switch
    {
        DataTable t => t,
        DataView v => v.Table,
        _ => null
    };

    public static GroupedResolvedSource FromIListSnapshot(IList list, DataTable? schemaTable)
    {
        if (list.Count == 0)
        {
            if (schemaTable != null)
            {
                return GroupedResolvedSource.ForDataRows(Array.Empty<DataRow>(), schemaTable);
            }

            return new GroupedResolvedSource(
                GroupedResolvedSource.SourceKind.Objects,
                Array.Empty<object?>(),
                null,
                inferredElementType: null);
        }

        switch (list[0])
        {
            case DataRowView:
            {
                var rows = new List<DataRow>(list.Count);
                foreach (var entry in list)
                {
                    if (entry is DataRowView drv)
                    {
                        rows.Add(drv.Row);
                    }
                }

                return GroupedResolvedSource.ForDataRows(
                    rows,
                    rows.Count > 0 ? rows[0].Table : schemaTable
                    ?? throw new InvalidOperationException(
                        nameof(DataRowView)
                        + " list is empty but no schema table could be inferred; bind a BindingSource.DataSource typed as "
                        + nameof(DataTable)
                        + " or supply rows first."));
            }

            case DataRow:
            {
                var rows = new List<DataRow>(list.Count);
                foreach (var entry in list)
                {
                    if (entry is DataRow dr)
                    {
                        rows.Add(dr);
                    }
                }

                return GroupedResolvedSource.ForDataRows(
                    rows,
                    rows.Count > 0 ? rows[0].Table : schemaTable
                    ?? throw new InvalidOperationException(nameof(DataRow)
                        + " list is empty without a fallback schema."));
            }

            default:
                return GroupedResolvedSource.ForObjectListSnapshot(list);
        }
    }
}

internal readonly struct GroupedResolvedSource
{
    public GroupedResolvedSource(SourceKind kind, IReadOnlyList<object?> snapshot, DataTable? tableTemplate, Type? inferredElementType)
    {
        Kind = kind;
        Snapshot = snapshot;
        TableTemplate = tableTemplate;
        InferredElementType = inferredElementType;
    }

    public SourceKind Kind { get; }

    public IReadOnlyList<object?> Snapshot { get; }

    /// <summary>Present when grouping <see cref="DataRow"/> rows so schemas clone cleanly.</summary>
    public DataTable? TableTemplate { get; }

    /// <summary>When list items are CLR objects we infer property schema from this type.</summary>
    public Type? InferredElementType { get; }

    public static GroupedResolvedSource ForDataRows(IReadOnlyList<DataRow> rows, DataTable schemaTable) =>
        new(SourceKind.Table, rows.Cast<object?>().ToList(), schemaTable, inferredElementType: null);

    public static GroupedResolvedSource ForObjectListSnapshot(IList list)
    {
        var buf = new List<object?>(list.Count);
        foreach (var item in list)
        {
            buf.Add(item);
        }

        Type? hinted = buf.FirstOrDefault(s => s is not null)?.GetType();

        DataTable? templateFromProps = hinted is null ? null : BuildReflectiveTemplate(hinted);

        return new GroupedResolvedSource(SourceKind.Objects, buf, templateFromProps, hinted);
    }

    private static DataTable BuildReflectiveTemplate(Type elementType)
    {
        var props = TypeDescriptor.GetProperties(elementType);
        var table = new DataTable();
        foreach (PropertyDescriptor p in props)
        {
            if (!p.IsBrowsable || p.PropertyType.Namespace == nameof(System.Reflection))
            {
                continue;
            }

            Type t = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
            if (t.IsGenericTypeDefinition || t == typeof(void))
            {
                table.Columns.Add(p.Name, typeof(object));
                continue;
            }

            try
            {
                table.Columns.Add(p.Name, t.IsEnum ? Enum.GetUnderlyingType(t) : t);
            }
#pragma warning disable CA1031
            catch
#pragma warning restore CA1031
            {
                table.Columns.Add(p.Name);
            }
        }

        return table;
    }

    internal enum SourceKind
    {
        Table,
        Objects
    }
}
