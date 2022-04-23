public class Program
{
    static void Main(string[] args)
    {
        int totalPoints = 0;
        int cpuPoints = 0;
        var toSearch = new List<SearchInput>
        {
            new SearchInput { Word = "lorem" },
            new SearchInput { Word = "ipsum" },
            new SearchInput { Word = "tincidunt" },
            new SearchInput { Word = "pretium" },
        };

        var fileContent = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "WordChallengeSource.txt"));
        foreach (var fileChar in fileContent)
        {
            foreach (var toSearchItem in toSearch)
            {
                cpuPoints++;
                if (fileChar.ToString().ToUpperInvariant() == toSearchItem.Word[toSearchItem.Index].ToString().ToUpperInvariant())
                {
                    if (toSearchItem.Index == toSearchItem.Word.Length - 1)
                    {
                        toSearchItem.Occurrences++;
                        toSearchItem.Index = 0;
                    }
                    else toSearchItem.Index++;
                }
                else toSearchItem.Index = 0;
            }
        }

        foreach (var toSearchItem in toSearch)
        {
            totalPoints += toSearchItem.Occurrences;
            Console.WriteLine($"Word points {toSearchItem.Occurrences} ({toSearchItem.Word})");
        }
        totalPoints += cpuPoints;
        Console.WriteLine($"CPU points {cpuPoints}");

        Console.WriteLine($"");
        Console.WriteLine($"Total points {totalPoints}");

        Console.ReadKey();
    }
}

public class SearchInput
{
    public int Index { get; set; } = 0;
    public int Occurrences { get; set; } = 0;
    public string Word { get; set; } = "";
}
