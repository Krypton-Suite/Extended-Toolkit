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

internal static class GroupedTableComposer
{
    public static bool TryCompose(
        GroupedResolvedSource source,
        IReadOnlyList<string> groupPropertyNames,
        SortOrder sortOrder,
        DataGridViewGrouperOptions options,
        IDictionary<string, bool> collapseState,
        out DataTable? table)
    {
        table = null;
        if (groupPropertyNames.Count == 0)
        {
            return false;
        }

        if (source.TableTemplate is null || source.TableTemplate.Columns.Count == 0)
        {
            return false;
        }

        var output = source.TableTemplate.Clone();
        EnsureInternalColumns(output);

        var slice = source.Snapshot.ToList();
        Walk(output, slice, 0, string.Empty, groupPropertyNames, sortOrder, options, collapseState);
        table = output;
        return true;
    }

    private static void EnsureInternalColumns(DataTable t)
    {
        void AddIfMissing(string name, Type type)
        {
            if (!t.Columns.Contains(name))
            {
                t.Columns.Add(name, type);
            }
        }

        AddIfMissing(DataGridViewGrouperSchema.IsGroup, typeof(bool));
        AddIfMissing(DataGridViewGrouperSchema.GroupLevel, typeof(int));
        AddIfMissing(DataGridViewGrouperSchema.GroupPath, typeof(string));
        AddIfMissing(DataGridViewGrouperSchema.SummaryText, typeof(string));
    }

    private static void Walk(
        DataTable output,
        List<object?> slice,
        int depth,
        string pathPrefix,
        IReadOnlyList<string> groupPropertyNames,
        SortOrder sortOrder,
        DataGridViewGrouperOptions options,
        IDictionary<string, bool> collapseState)
    {
        if (depth >= groupPropertyNames.Count)
        {
            foreach (var row in slice)
            {
                AddDataRow(output, row);
            }

            return;
        }

        string prop = groupPropertyNames[depth];
        var buckets = new Dictionary<object, List<object?>>(KeyEquality.Instance);
        foreach (var row in slice)
        {
            object key = NormalizeKey(GetRawKey(row, prop));
            if (!buckets.TryGetValue(key, out var list))
            {
                list = [];
                buckets[key] = list;
            }

            list.Add(row);
        }

        var orderedKeys = buckets.Keys.ToList();
        orderedKeys.Sort((a, b) => KeyComparer.CompareNormalized(a, b, sortOrder));

        foreach (var key in orderedKeys)
        {
            var groupRows = buckets[key];

            string path = string.IsNullOrEmpty(pathPrefix)
                ? $"{depth}:{KeyFingerprint(key)}"
                : $"{pathPrefix}/{depth}:{KeyFingerprint(key)}";

            int leafCount = CountLeafRows(groupRows, depth, groupPropertyNames);
            AppendGroupHeaderRow(output, depth, path, prop, key, leafCount, options);

            bool collapsed = collapseState.TryGetValue(path, out bool flag)
                ? flag
                : options.StartCollapsed;

            if (!collapsed)
            {
                Walk(output, groupRows, depth + 1, path, groupPropertyNames, sortOrder, options,
                    collapseState);
            }
        }
    }

    private static int CountLeafRows(
        List<object?> rows,
        int currentDepth,
        IReadOnlyList<string> groupPropertyNames)
    {
        if (currentDepth >= groupPropertyNames.Count - 1)
        {
            return rows.Count;
        }

        string prop = groupPropertyNames[currentDepth + 1];
        var buckets = new Dictionary<object, List<object?>>(KeyEquality.Instance);
        foreach (var row in rows)
        {
            object key = NormalizeKey(GetRawKey(row, prop));
            if (!buckets.TryGetValue(key, out var list))
            {
                list = [];
                buckets[key] = list;
            }

            list.Add(row);
        }

        return buckets.Values.Sum(b => CountLeafRows(b, currentDepth + 1, groupPropertyNames));
    }

    private static void AppendGroupHeaderRow(
        DataTable output,
        int depth,
        string path,
        string propertyName,
        object? normalizedKey,
        int leafCount,
        DataGridViewGrouperOptions options)
    {
        DataRow r = output.NewRow();
        foreach (DataColumn column in output.Columns)
        {
            if (column.ColumnName.StartsWith("__KG_", StringComparison.Ordinal))
            {
                continue;
            }

            r[column] = DBNull.Value;
        }

        string displayKey = FormatKey(normalizedKey);
        string header = BuildCaption(propertyName, displayKey, leafCount, options);
        if (options.PromotePrimaryGroupValueIntoFirstColumn && output.Columns.Count > 0)
        {
            DataColumn? first = output.Columns.Cast<DataColumn>()
                .FirstOrDefault(c => !c.ColumnName.StartsWith("__KG_", StringComparison.Ordinal));
            if (first != null)
            {
                r[first] = header;
            }
        }

        r[DataGridViewGrouperSchema.IsGroup] = true;
        r[DataGridViewGrouperSchema.GroupLevel] = depth;
        r[DataGridViewGrouperSchema.GroupPath] = path;
        r[DataGridViewGrouperSchema.SummaryText] = header;
        output.Rows.Add(r);
    }

    private static string BuildCaption(string propertyName, object? displayKey, int leafCount, DataGridViewGrouperOptions options)
    {
        string summary = $"{propertyName}: {displayKey}";
        if (options.IncludeChildCountInHeader)
        {
            summary += $" ({leafCount})";
        }

        return summary;
    }

    private static string FormatKey(object? key)
    {
        if (key == DBNull.Value)
        {
            return string.Empty;
        }

        return key?.ToString() ?? "<null>";
    }

    private static void AddDataRow(DataTable output, object? sourceRow)
    {
        DataRow r = output.NewRow();
        switch (sourceRow)
        {
            case DataRow dr:
                foreach (DataColumn column in output.Columns)
                {
                    if (column.ColumnName.StartsWith("__KG_", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    if (dr.Table.Columns.Contains(column.ColumnName))
                    {
                        r[column] = dr[column] is { } v ? v : DBNull.Value;
                    }
                    else
                    {
                        r[column] = DBNull.Value;
                    }
                }

                break;

            default:
                if (sourceRow is null)
                {
                    return;
                }

                foreach (DataColumn column in output.Columns)
                {
                    if (column.ColumnName.StartsWith("__KG_", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    PropertyDescriptor? pd =
                        TypeDescriptor.GetProperties(sourceRow).Find(column.ColumnName, ignoreCase: true);
                    if (pd == null)
                    {
                        r[column] = DBNull.Value;
                        continue;
                    }

                    object? val = pd.GetValue(sourceRow);
                    r[column] = val ?? DBNull.Value;
                }

                break;
        }

        r[DataGridViewGrouperSchema.IsGroup] = false;
        r[DataGridViewGrouperSchema.GroupLevel] = -1;
        r[DataGridViewGrouperSchema.GroupPath] = string.Empty;
        r[DataGridViewGrouperSchema.SummaryText] = string.Empty;
        output.Rows.Add(r);
    }

    private static object? GetRawKey(object? row, string propertyName)
    {
        switch (row)
        {
            case DataRow dr:
                return dr.Table.Columns.Contains(propertyName) ? dr[propertyName] : null;

            case null:
                return null;

            default:
                PropertyDescriptor? pd =
                    TypeDescriptor.GetProperties(row).Find(propertyName, ignoreCase: true);
                return pd?.GetValue(row);
        }
    }

    private static object NormalizeKey(object? v) => v is null or DBNull ? DBNull.Value : v;

    private static string KeyFingerprint(object? key)
    {
        string s = key == DBNull.Value ? "\u241F" : key?.ToString() ?? "<null>";

        unchecked
        {
            int hash = 17;
            foreach (char c in s)
            {
                hash = hash * 397 ^ c;
            }

            string prefix = s.Length <= 64 ? s : s.Substring(0, 64);
            return $"{Uri.EscapeDataString(prefix)}-{hash:X8}";
        }
    }

    private sealed class KeyEquality : IEqualityComparer<object>
    {
        public static readonly KeyEquality Instance = new();

        bool IEqualityComparer<object>.Equals(object? x, object? y) => EqualsNormalized(NormalizeKey(x), NormalizeKey(y));

        public int GetHashCode(object obj) => NormalizeKey(obj) switch
        {
            null or DBNull => 0,
            _ => obj!.GetHashCode()
        };

        private static bool EqualsNormalized(object? a, object? b)
        {
            if (a is DBNull && b is DBNull)
            {
                return true;
            }

            return Equals(a, b);
        }
    }

    private static class KeyComparer
    {
        public static int CompareNormalized(object? a, object? b, SortOrder order)
        {
            a = NormalizeKey(a);
            b = NormalizeKey(b);
            int factor = order == SortOrder.Descending ? -1 : 1;

            if (a is DBNull && b is DBNull)
            {
                return 0;
            }

            if (a is DBNull)
            {
                return -1 * factor;
            }

            if (b is DBNull)
            {
                return 1 * factor;
            }

            if (a is IComparable ac)
            {
                try
                {
                    int cmp = ac.CompareTo(b);
                    return cmp * factor;
                }
                catch
                {
                    // ignored
                }
            }

            return string.Compare(
                       a?.ToString(),
                       b?.ToString(),
                       StringComparison.CurrentCultureIgnoreCase) * factor;
        }
    }
}
