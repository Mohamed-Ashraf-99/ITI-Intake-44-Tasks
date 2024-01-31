namespace _8_GroupingOperators;

public static class GroupingOperatorsMethods
{
    public static void GetListOfNumbersByTheirRemainderWhenDividedBy5()
    {
        var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        var numbersDividedByFive = numbers.GroupBy(num => num % 5);
        Console.WriteLine(new string('\u2500', 150));
        foreach (var group in numbersDividedByFive)
        {
            Console.WriteLine($">> Numbers with a remainder of {group.Key} when divided by 5:");
            foreach (var number in group)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine(new string('\u2500', 150));
        }
    }

    public static void DisplayListOfWordsByTheirFirstLetterUseDictionary()
    {
        var words = Read();
        var groupBy = words.GroupBy(word => word[0]);
        foreach (var groupOfWords in groupBy)
        {
            Console.WriteLine($">> Words starting with '{groupOfWords.Key}': ");
            foreach (var word in groupOfWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(new string('\u2500', 150));
        }
    }

    public static void DisplayMatchesWordsThatAreConsistsOfTheSameCharactersTogether()
    {
        string[] words = { "from ", "salt", "earn ", "last ", "near ", " form " };
        var groupedWords = words.GroupBy(word => word.Trim(), new WordsEqualityComparer());
        foreach (var group in groupedWords)
        {
            Console.WriteLine(string.Join(" >> ", group));
        }
        Console.WriteLine(new string('\u2500', 150));

    }
    
    private static IEnumerable<string> Read()
    {
        string path = "D:\\1-Programming\\2-ITI-Intake-44\\9-C#\\11-Day-11\\Assignment Files\\dictionary_english.txt";
        var words = new List<string>();
        using (var sr = new StreamReader(path))
        {
            string? line;
            while ((line = sr.ReadLine()) is not null)
            {
                words.Add(line);
            }
        }

        return words;
    }
}