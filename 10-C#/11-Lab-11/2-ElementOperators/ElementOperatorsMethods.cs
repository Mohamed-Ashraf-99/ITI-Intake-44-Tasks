using L2O___D09;

namespace _2_ElementOperators;

public static class ElementOperatorsMethods
{
    public static void DisplayFirstProductOutOfStock()
    {
        Console.WriteLine(new string('\u2500', 150));
        Console.WriteLine(">> First Product Out Of Stock: \n");
        var firstProductOutOfStock = GetFirstProductOutOfStock();
        Console.WriteLine(firstProductOutOfStock);
        Console.WriteLine(new string('\u2500', 150));
    }
    public static void DisplayFirstProductWhosePriceGreaterThan1000()
    {
        Console.WriteLine(">> First Product Out Of Stock: \n");
        var firstProductWhosePriceGreaterThan1000 = GetFirstProductWhosePriceGreaterThan1000();
        Console.WriteLine(firstProductWhosePriceGreaterThan1000);
        Console.WriteLine(new string('\u2500', 150));
    }
    public static void DisplaySecondNumberGreaterThanFive()
    {
        var secondNumberGreaterThanFive = GetSecondNumberGreaterThanFive();
        Console.WriteLine($"Second Number Greater Than Five = {secondNumberGreaterThanFive}");
        Console.WriteLine(new string('\u2500', 150));
    }
    private static Product GetFirstProductOutOfStock()
    {
        return ListGenerators.ProductList.First(product => product.UnitsInStock == 0);
    }
    private static Product GetFirstProductWhosePriceGreaterThan1000()
    {
        return ListGenerators.ProductList.FirstOrDefault(product => product.UnitPrice > 1000);
    }
    private static int GetSecondNumberGreaterThanFive()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        return numbers.Where(number => number > 5).Skip(1).First();
    }
}