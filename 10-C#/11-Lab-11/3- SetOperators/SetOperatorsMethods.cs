using L2O___D09;

namespace _3__SetOperators;

public static class SetOperatorsMethods
{
    public static void DisplayUniqueCategoryNamesFromProductList()
    {
        Console.WriteLine(new string('\u2500', 150));
        var uniqueCategoryNamesFromProductList = GetUniqueCategoryNamesFromProductList();
        Console.WriteLine(">>  Find the unique Category names from Product List: \n");
        foreach (var category in uniqueCategoryNamesFromProductList)
        {
            Console.WriteLine(category);
        }

        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayUniqueFirstLettersSequence()
    {
        var productCustomersNamesFirstLetter =
            GetUniqueFirstLettersSequence();
        Console.WriteLine(
            ">> Produce a Sequence containing the unique first letter from both product and customer names: \n");
        foreach (var letter in productCustomersNamesFirstLetter)
        {
            Console.Write($"{letter}, ");
        }

        Console.WriteLine("\n");
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayCommonFirstLetterFromProductAndCustomerNames()
    {
        var commonLetters =
            GetCommonFirstLetterFromProductAndCustomerNames();
        Console.WriteLine(">> Common first letter from both product and customer names: \n");
        foreach (var letter in commonLetters)
        {
            Console.Write($"{letter}, ");
        }

        Console.WriteLine("\n");
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayFirstLettersOfProductNamesThatAreNotAlsoFirstLettersOfCustomerNames()
    {
        var commonLetters =
            GetFirstLettersOfProductNamesThatAreNotAlsoFirstLettersOfCustomerNames();
        Console.WriteLine(">> First letters of product names that are not also first letters of customer names: \n");
        foreach (var letter in commonLetters)
        {
            Console.Write($"{letter}, ");
        }

        Console.WriteLine("\n");
        Console.WriteLine(new string('\u2500', 150));
    }

    public static void DisplayTheLastThreeCharactersInEachNamesOfAllCustomersAndProducts()
    {
        var lastThreeLetters =
            GetTheLastThreeCharactersInEachNamesOfAllCustomersAndProducts();
        Console.WriteLine(
            ">> the last Three Characters in each names of all customers and products, including any duplicates: \n");
        foreach (var letter in lastThreeLetters)
        {
            Console.Write($"{letter}, ");
        }

        Console.WriteLine("\n");
        Console.WriteLine(new string('\u2500', 150));
    }

    private static IEnumerable<string> GetUniqueCategoryNamesFromProductList()
    {
        return ListGenerators.ProductList.Select(product => product.Category).Distinct();
    }

    private static IEnumerable<char> GetUniqueFirstLettersSequence()
    {
        var productsNames = ListGenerators
            .ProductList
            .Select(product => product.ProductName.First());

        var customersNames = ListGenerators
            .CustomerList
            .Select(customer => customer.CompanyName.First());

        var productCustomersNames = productsNames
            .Concat(customersNames);

        return productCustomersNames
            .Distinct();
    }

    private static IEnumerable<char> GetCommonFirstLetterFromProductAndCustomerNames()
    {
        var productsNames = ListGenerators
            .ProductList
            .Select(product => product.ProductName.First());

        var customersNames = ListGenerators
            .CustomerList
            .Select(customer => customer.CompanyName.First());

        var commonLetters = productsNames.Where(character 
            => customersNames.Contains(character)).Distinct();

        return commonLetters;
    }

    private static IEnumerable<char> GetFirstLettersOfProductNamesThatAreNotAlsoFirstLettersOfCustomerNames()
    {
        var productsNames = ListGenerators
            .ProductList
            .Select(product => product.ProductName.First());

        var customersNames = ListGenerators
            .CustomerList
            .Select(customer => customer.CompanyName.First());

        var productFirstLetter = productsNames
            .Except(customersNames);

        return productFirstLetter.Distinct();
    }

    private static IEnumerable<string> GetTheLastThreeCharactersInEachNamesOfAllCustomersAndProducts()
    {
        var productsNames = ListGenerators
            .ProductList
            .Select(product => product.ProductName);

        var productsNamesLastThreeLetters =
            productsNames
                .Select(name => name.Substring(Math.Max(0, name.Length - 3)));

        var customersNames = ListGenerators
            .CustomerList
            .Select(customer => customer.CompanyName);

        var customersNamesLastThreeLetters =
            customersNames
                .Select(name => name.Substring(Math.Max(0, name.Length - 3)));

        var lastThreeCharacters = productsNamesLastThreeLetters.Concat(customersNamesLastThreeLetters);

        return lastThreeCharacters;
    }
}