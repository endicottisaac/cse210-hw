using System;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();

        foreach (Entry entry in _entries)
        {
            lines.Add(entry.GetFileString());
        }

        File.WriteAllLines(filename, lines);
        Console.WriteLine("Journal saved");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Couldn't find the file");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            if (parts.Length >= 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                _entries.Add(entry);
            }
        }

        Console.WriteLine("journal loaded");
    }

    public void DisplayStats()
    {
        int totalEntries = _entries.Count;

        if (totalEntries == 0)
        {
            Console.WriteLine("No data is available since there aren't journal entries");
            return;
        }

        List<string> uniqueDates = new List<string>();

        foreach (Entry entry in _entries)
        {
            if (!uniqueDates.Contains(entry._date))
            {
                uniqueDates.Add(entry._date);
            }
        }

        double averageEntriesPerDay = (double)totalEntries / uniqueDates.Count;

        Console.WriteLine($"Total journal entries: {totalEntries}");
        Console.WriteLine($"Average journal entries per day: {averageEntriesPerDay:F2}");
    }
}
