using L2O___D09;

namespace _5_OrderingOperators;

public static class OrderingOperatorsMethods
{
    public static void DisplaySortedListOfProductsByName()
    {
        Console.WriteLine(new string('\u2500', 150));
        var products = SortListOfProductsByName();
        Console.WriteLine(">> Sorted List Of Products By Name : \n");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine(new string('\u2500', 150));
    }


    public static void DisplayUsesCustomComparerToDoCaseInsensitiveSortOfWordsInArray()
    {
        var words = UsesCustomComparerToDoCaseInsensitiveSortOfWordsInArray();
        Console.WriteLine(">> Uses custom comparer to do case-insensitive sort of words in array: \n");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine(new string('\u2500', 150));
    }


    public static void DisplaySortedListOfProductsByUnitsInStockFromHighestToLowest()
    {
        var products = SortListOfProductsByUnitsInStockFromHighestToLowest();
        Console.WriteLine(">> Sort a list of products by units in stock from highest to lowest: \n");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine(new string('\u2500', 150));
    }


    public static void DisplaySortedListOfDigits()
    {
        var words = SortListOfDigits();
        Console.WriteLine(
            ">> Sort a list of digits, first by length of their name, and then alphabetically by the name itself: \n");
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine(new string('\u2500', 150));
    }


    public static void DisplaySortedListFirstByWordLengthAndThenByCaseInsensitive()
    {
        var words = SortFirstByWordLengthAndThenByCaseInsensitiveSortOfTheWords();
        Console.WriteLine(
            ">> Sort first by word length and then by a case-insensitive sort of the words in an array: \n");
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine(new string('\u2500', 150));
    }


    public static void DisplaySortedListOfProductsFirstByCategoryAndThenByUnitPriceFromHighestToLowest()
    {
        var products = SortListOfProductsFirstByCategoryAndThenByUnitPriceFromHighestToLowest();
        Console.WriteLine(
            ">> Sort a list of products, first by category, and then by unit price, from highest to lowest: \n");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine(new string('\u2500', 150));
    }


    public static void DisplaySortedListFirstByWordLengthAndThenByCaseInsensitiveDescending()
    {
        var words = SortFirstByWordLengthAndThenByCaseInsensitiveDescending();
        Console.WriteLine(">> Sort first by word length and then by a case-insensitive descending: \n");
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine(new string('\u2500', 150));
    }


    public static void DisplayListOfAllDigitsInWhoseSecondLetterIsIThatIsReversed()
    {
        var digits = CreateListOfAllDigitsInWhoseSecondLetterIsIThatIsReversed();
        Console.WriteLine(
            ">> Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array: \n");
        foreach (var digit in digits)
        {
            Console.WriteLine(digit);
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    private static IEnumerable<Product> SortListOfProductsByName()
    {
        return ListGenerators.ProductList.OrderBy(product => product.ProductName);
    }

    private static IEnumerable<string> UsesCustomComparerToDoCaseInsensitiveSortOfWordsInArray()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        return words.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);
        ;
    }

    private static IEnumerable<Product> SortListOfProductsByUnitsInStockFromHighestToLowest()
    {
        return ListGenerators.ProductList.OrderByDescending(product => product.UnitsInStock);
    }

    private static IEnumerable<string> SortListOfDigits()
    {
        string[] words =
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine"
        };
        return words.OrderBy(word => word.Length).ThenBy(word => word);
    }

    private static IEnumerable<string> SortFirstByWordLengthAndThenByCaseInsensitiveSortOfTheWords()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        return words.OrderBy(word => word.Length).ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
    }

    private static IEnumerable<Product> SortListOfProductsFirstByCategoryAndThenByUnitPriceFromHighestToLowest()
    {
        return ListGenerators.ProductList.OrderBy(product => product.Category)
            .ThenByDescending(product => product.UnitPrice);
    }

    private static IEnumerable<string> SortFirstByWordLengthAndThenByCaseInsensitiveDescending()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        return words.OrderBy(word => word.Length).ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);
    }

    private static IEnumerable<string> CreateListOfAllDigitsInWhoseSecondLetterIsIThatIsReversed()
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digits.Where(word => word[1] == 'i').Reverse();
    }
}