using L2O___D09;

namespace _6_PartitioningOperators;

public static class PartitioningOperatorsMethods
{
    public static void DisplaySequenceOfJustTheNamesOfListOfProducts()
    {
        Console.WriteLine(new string('\u2500', 150));
        var productsNames = GetSequenceOfJustTheNamesOfListOfProducts();
        Console.WriteLine(">>  Return a sequence of just the names of a list of products : \n");
        foreach (var productName in productsNames)
        {
            Console.WriteLine(productName);
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplaySequenceOfTheUpperCaseAndLowerCaseVersionsOfEachWord()
    {
        string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
        Console.WriteLine(
            ">> Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types) : \n");
        var wordUpperAndLower = words.SelectMany(word => new[]
        {
            new { Uppercase = word.ToUpper(), Lowercase = word.ToLower() }
        });

        foreach (var word in wordUpperAndLower)
        {
            Console.WriteLine($"Uppercase: {word.Uppercase}, Lowercase: {word.Lowercase}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayProductsPropertiesReplaceUnitPriceWithPrice()
    {
        var products = ListGenerators.ProductList.Select(
            product => new
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.UnitPrice,
            });
        Console.WriteLine(
            ">> Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type: \n");
        foreach (var product in products)
        {
            Console.WriteLine(
                $"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: ${product.Price}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DetermineIfTheValueOfIntegersInAnArrayMatchTheirPositionInTheArray()
    {
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        var result = numbers.Select((number, index) => new { Number = number, InPlace = number == index });

        Console.WriteLine("Determine if the value of ints in an array match their position in the array: \n");
        foreach (var item in result)
        {
            Console.WriteLine($"{item.Number}: {item.InPlace}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayAllPairs()
    {
        int[] numbersA = [0, 2, 4, 5, 6, 8, 9];
        int[] numbersB = [1, 3, 5, 7, 8];

        var pairs = numbersA
            .SelectMany(a =>
                numbersB.Where(b => a < b),
            (a, b) => new { NumberA = a, NumberB = b });

        Console.WriteLine("Pairs where a < b:");
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.NumberA} is less than {pair.NumberB}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }
    
    public static void DisplayAllOrdersWhereTheOrderTotalIsLessThan50000()
    {
        var orders = GetAllOrdersWhereTheOrderTotalIsLessThan50000();
        Console.WriteLine(">> . Select all orders where the order total is less than 500.00 \n");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Total: {order.Total}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayAllOrdersWhereTheOrderDateMadeBefore1998()
    {
        var orders = GetAllOrdersWhereTheOrderDateMadeBefore1998();
        Console.WriteLine(">> Select all orders where the order made in 1998 or later \n");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Total: {order.OrderDate}");
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    private static IEnumerable<string> GetSequenceOfJustTheNamesOfListOfProducts()
    {
        return ListGenerators.ProductList.Select(product => product.ProductName);
    }

    private static IEnumerable<Order> GetAllOrdersWhereTheOrderTotalIsLessThan50000()
    {
        return ListGenerators.CustomerList.SelectMany(customer => customer.Orders).Where(
            order => order.Total < 500.00M);
    }

    private static IEnumerable<Order> GetAllOrdersWhereTheOrderDateMadeBefore1998()
    {
        return ListGenerators.CustomerList.SelectMany(customer => customer.Orders).Where(
            order => order.OrderDate < new DateTime(1998, 1, 1));
    }
}