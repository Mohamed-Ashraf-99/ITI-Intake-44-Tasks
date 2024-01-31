using L2O___D09;

namespace _1_RestrictionOperators;

public static class RestrictionOperatorsMethods
{
    public static void DisplayProductOutOfStockProducts()
    {
        var productOutOfStockProducts = GetProductOutOfStockProducts();
        Console.WriteLine(new string('\u2500', 150));
        Console.WriteLine(">> Products that are out of stock: \n");
        foreach (var product in productOutOfStockProducts)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine(new string('\u2500', 150));
    }
    public static void DisplayAllProductsThatAreInStockAndCostMoreThan3PerUnit()
    {
        var productsThatAreInStockAndCostMoreThan3PerUnit = GetAllProductsThatAreInStockAndCostMoreThan3PerUnit();
        Console.WriteLine(">> products that are in stock and cost more than 3.00 per unit: \n");
        foreach (var product in productsThatAreInStockAndCostMoreThan3PerUnit)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine(new string('\u2500', 150));
    }
    public static void DisplayDigitsWhoseNameIsShorterThanTheirValue()
    {
        Console.WriteLine(">> Digits Whose Name Is Shorter Than Their Value: \n");

        var digits = GetDigitsWhoseNameIsShorterThanTheirValue();
        foreach (var digit in digits)
        {
            Console.Write($"{digit}, ");
        }
        Console.WriteLine(string.Empty);
        Console.WriteLine(new string('\u2500', 150));
    }
    private static IEnumerable<Product> GetProductOutOfStockProducts()
    {
        return ListGenerators.ProductList.Where(product => product.UnitsInStock == 0);
    }
    private static IEnumerable<Product> GetAllProductsThatAreInStockAndCostMoreThan3PerUnit()
    {
        return ListGenerators.ProductList.Where(product => product.UnitsInStock > 0 && product.UnitPrice > 3);
    }
    private static IEnumerable<string> GetDigitsWhoseNameIsShorterThanTheirValue()
    {
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        
        return digits.Where((word, index) => word.Length < index);
    }
}