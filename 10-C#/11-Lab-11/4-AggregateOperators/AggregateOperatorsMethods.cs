using L2O___D09;

namespace _4_AggregateOperators;

public static class AggregateOperatorsMethods
{
    public static void DisplayTheNumberOfOddNumbers()
    {
        Console.WriteLine(new string('\u2500', 150));
        var numberOfOddNumbers = GetTheNumberOfOddNumbers();
        Console.Write(">> The number of odd numbers in the array = ");
        Console.WriteLine(numberOfOddNumbers);
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayCustomersAndHowManyOrdersEachHas()
    {
        var customerAndHisOrders = GetCustomersAndHowManyOrdersEachHas();
        Console.WriteLine(">> The customers and how many orders each has: \n");
        foreach (var customer in customerAndHisOrders)
        {
            Console.WriteLine($"{customer}, || Number of orders: ({customer.Orders.Length}).");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayCategoriesAndHowManyProductsEachHas()
    {
        var categoriesAndNumberOfProducts =
            GetCategoriesAndHowManyProductsEachHas();
        Console.WriteLine(">> Categories and how many products each has: \n");
        foreach (var category in categoriesAndNumberOfProducts)
        {
            Console.WriteLine($"{category.Key} {category.Value}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheTotalOfTheNumbersInAnArray()
    {
        var totalLength = GetTheTotalOfTheNumbersInAnArray();
        Console.Write(">> The total of the numbers in an array = ");
        Console.WriteLine(totalLength);
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheTotalNumberOfCharactersOfAllWordsInDictionary()
    {
        var totalLength = GetTheTotalNumberOfCharactersOfAllWordsInDictionary();
        Console.Write(">> The total number of characters of All words in the dictionary = ");
        Console.WriteLine(totalLength);
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheTotalUnitsInStockForEachProductCategory()
    {
        var categoriesAndNumberOfUnitsInStock =
            GetTheTotalUnitsInStockForEachProductCategory();
        Console.WriteLine(">> Categories and how many units in stock each has: \n");
        foreach (var category in categoriesAndNumberOfUnitsInStock)
        {
            Console.WriteLine($"{category.Key} {category.Value}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheProductsWithTheCheapestPriceInEachCategory()
    {
        var categoriesAndNumberOfUnitsInStock =
            GetTheProductsWithTheCheapestPriceInEachCategory();
        Console.WriteLine(">> The products with the cheapest price in each category: \n");
        foreach (var category in categoriesAndNumberOfUnitsInStock)
        {
            Console.WriteLine($"The Cheapest Product in [{category.Key}] >> {category.Value}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheLengthOfTheLongestWordInDictionary()
    {
        var wordLength = GetTheLengthOfTheLongestWordInDictionary();
        Console.Write(">> The length of the longest word in dictionary = ");
        Console.WriteLine(wordLength);
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheMostExpensivePriceAmongEachCategoryProducts()
    {
        var categoriesAndheMostExpensivePrice =
            GetTheMostExpensivePriceAmongEachCategoryProducts();
        Console.WriteLine(">> The most expensive among each category: \n");
        foreach (var category in categoriesAndheMostExpensivePrice)
        {
            Console.WriteLine($"The most expensive price in [{category.Key}] = ${category.Value}.");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheProductWithTheMostExpensivePriceAmongEachCategory()
    {
        var categoriesAndheMostExpensivePrice = GetTheProductWithTheMostExpensivePriceAmongEachCategory();
        Console.WriteLine(">> The most product among each category: \n");
        foreach (var category in categoriesAndheMostExpensivePrice)
        {
            Console.WriteLine($"The most expensive product in [{category.Key}] >> {category.Value}.");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheAverageLengthOfTheWordsInDictionary()
    {
        var wordLengthAverage = GetTheAverageLengthOfTheWordsInDictionary();
        Console.Write(">>  The average length of the words in dictionary = ");
        Console.WriteLine(Math.Round(wordLengthAverage, 2));
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheAveragePriceOfEachCategoryProducts()
    {
        var categoriesAndheMostExpensivePrice = GetTheAveragePriceOfEachCategoryProducts();
        Console.WriteLine(">> The average price of each category products: \n");
        foreach (var category in categoriesAndheMostExpensivePrice)
        {
            Console.WriteLine($"The average price of products in [{category.Key}] = ${Math.Round(category.Value, 2)}.");
        }
        Console.WriteLine(new string('\u2500', 150));
    }
    private static int GetTheNumberOfOddNumbers()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        return numbers.Count(number => number % 2 != 0);
    }

    private static IEnumerable<Customer> GetCustomersAndHowManyOrdersEachHas()
    {
        return ListGenerators.CustomerList;
    }

    private static Dictionary<string, int> GetCategoriesAndHowManyProductsEachHas()
    {
        return ListGenerators
            .ProductList.GroupBy(product => product.Category)
            .ToDictionary(
                category
                    => category.Key, product
                    => product.Count()
            );
    }

    private static int GetTheTotalOfTheNumbersInAnArray()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        return numbers.Length;
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

    private static int GetTheTotalNumberOfCharactersOfAllWordsInDictionary()
    {
        var words = Read();
        return words.Sum(sentence => sentence.Length);
        
    }

    private static Dictionary<string, int> GetTheTotalUnitsInStockForEachProductCategory()
    {
        return ListGenerators.ProductList
            .GroupBy(product => product.Category)
            .ToDictionary(category => category.Key,
                numberOfUnits => numberOfUnits.Sum(unit => unit.UnitsInStock));
    }

    private static Dictionary<string, Product?> GetTheProductsWithTheCheapestPriceInEachCategory()
    {
        return ListGenerators.ProductList
            .GroupBy(category => category.Category)
            .ToDictionary(category => category.Key,
                product => product.MinBy(cheapestProduct => cheapestProduct.UnitPrice));
    }

    private static int GetTheLengthOfTheLongestWordInDictionary()
    {
        var words = Read();
        return words.MaxBy(word => word.Length)!.Length;
    }

    private static Dictionary<string, decimal> GetTheMostExpensivePriceAmongEachCategoryProducts()
    {
        return ListGenerators.ProductList.GroupBy(product => product.Category)
            .ToDictionary(category => category.Key,
                product => product.MaxBy(price => price.UnitPrice)!.UnitPrice);
    }

    private static Dictionary<string, Product?> GetTheProductWithTheMostExpensivePriceAmongEachCategory()
    {
        return ListGenerators.ProductList.GroupBy(product => product.Category)
            .ToDictionary(category => category.Key,
                product => product.MaxBy(price => price.UnitPrice));
    }

    private static double GetTheAverageLengthOfTheWordsInDictionary()
    {
        var words = Read();
        return words.Average(word => word.Length);
    }
    
    private static Dictionary<string, decimal> GetTheAveragePriceOfEachCategoryProducts()
    {
        return ListGenerators.ProductList.GroupBy(category => category.Category)
            .ToDictionary(category => category.Key,
                product => product.Average(price => price.UnitPrice));
    }
}