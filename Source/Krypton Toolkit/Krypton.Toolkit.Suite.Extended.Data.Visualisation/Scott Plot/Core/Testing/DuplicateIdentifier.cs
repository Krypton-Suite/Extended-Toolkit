namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// Helper class to detect for duplicate items in complex collections
/// and display helpful error messages to the console the facilitate debugging.
/// </summary>
public class DuplicateIdentifier<T>(string title)
{
    private readonly List<KeyValuePair<string, T>> _things = [];

    private readonly string _title = title;

    public void Add(string id, T thing)
    {
        _things.Add(new KeyValuePair<string, T>(id, thing));
    }

    public void ShouldHaveNoDuplicates()
    {
        HashSet<string> duplicateIDs = [];
        HashSet<string> seenIDs = [];
        for (int i = 0; i < _things.Count; i++)
        {
            string id = _things[i].Key;
            if (seenIDs.Contains(id))
            {
                duplicateIDs.Add(id);
            }
            seenIDs.Add(id);
        }

        if (!duplicateIDs.Any())
        {
            return;
        }

        StringBuilder sb = new();
        foreach (string id in duplicateIDs)
        {
            IEnumerable<T> duplicateThings = _things.Where(x => x.Key == id).Select(x => x.Value);
            string duplicateThingsString = string.Join(", ", duplicateThings);
            sb.AppendLine($"The {_title} \"{id}\" is not unique as it is shared by: {duplicateThingsString}");
        }
        throw new InvalidOperationException(sb.ToString());
    }
}