using L2O___D09;

namespace _7_Quantifiers;

public static class QuantifiersMethods
{
    public static void DisplayIfAnyOfTheWordsInDictionaryContainTheSubstring_ei()
    {
        var words = Read();
        var ifContains = words.Any(word => word.Contains("ei"));
        Console.WriteLine(new string('\u2500', 150));
        Console.Write(">> Determine if any of the words in dictionary contain the substring 'ei'. : ");
        Console.WriteLine(ifContains);
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayListOfProductsOnlyForCategoriesThatHaveAtLeastOneProductThatIsOutOfStock()
    {
        var productsInStock = GetListOfProductsOnlyForCategoriesThatHaveAtLeastOneProductThatIsOutOfStock();

        Console.WriteLine(
            ">> Return a grouped a list of products only for categories that have at least one product that is out of stock: \n");

        foreach (var category in productsInStock)
        {
            Console.WriteLine($">> Category Name [{category.Key}] : \n");
            foreach (var product in category.Value)
            {
                Console.WriteLine(
                    $" >> Product Id: [{product.ProductId}],  Product Name: [{product.ProductName}], Units in stock: [{product.UnitsInStock}], Unit Price: ${product.UnitPrice}");
            }

            Console.WriteLine(new string('\u2500', 150));
        }
    }


    public static void DisplayListOfProductsOnlyForCategoriesThatHaveProductsInStock()
    {
        var productsInStock = GetListOfProductsOnlyForCategoriesThatHaveProductsInStock();

        Console.WriteLine(
            ">> Return a grouped a list of products only for categories that have all of their products in stock: \n");

        foreach (var category in productsInStock)
        {
            Console.WriteLine($">> Category Name [{category.Key}] : \n");
            foreach (var product in category.Value)
            {
                Console.WriteLine(
                    $" >> Product Id: [{product.ProductId}],  Product Name: [{product.ProductName}], Units in stock: [{product.UnitsInStock}], Unit Price: ${product.UnitPrice}");
            }

            Console.WriteLine(new string('\u2500', 150));
        }
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

    private static Dictionary<string, List<Product>>
        GetListOfProductsOnlyForCategoriesThatHaveAtLeastOneProductThatIsOutOfStock()
    {
        return ListGenerators.ProductList
            .GroupBy(category => category.Category)
            .Where(
                products => products
                    .Any(product => product.UnitsInStock == 0))
            .ToDictionary(
                category => category.Key,
                products => products.ToList());
    }

    private static Dictionary<string, List<Product>> GetListOfProductsOnlyForCategoriesThatHaveProductsInStock()
    {
        return ListGenerators.ProductList
            .GroupBy(category => category.Category)
            .Where(
                products => products
                    .All(product => product.UnitsInStock > 0))
            .ToDictionary(
                category => category.Key,
                products => products.ToList());
    }
}