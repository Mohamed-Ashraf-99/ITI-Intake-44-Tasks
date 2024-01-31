namespace _5_OrderingOperators;

static class Program
{
    static void Main()
    {
        OrderingOperatorsMethods.DisplaySortedListOfProductsByName();
        OrderingOperatorsMethods.DisplayUsesCustomComparerToDoCaseInsensitiveSortOfWordsInArray();
        OrderingOperatorsMethods.DisplaySortedListOfProductsByUnitsInStockFromHighestToLowest();
        OrderingOperatorsMethods.DisplaySortedListOfDigits();
        OrderingOperatorsMethods.DisplaySortedListFirstByWordLengthAndThenByCaseInsensitive();
        OrderingOperatorsMethods.DisplaySortedListOfProductsFirstByCategoryAndThenByUnitPriceFromHighestToLowest();
        OrderingOperatorsMethods.DisplaySortedListFirstByWordLengthAndThenByCaseInsensitiveDescending();
        OrderingOperatorsMethods.DisplayListOfAllDigitsInWhoseSecondLetterIsIThatIsReversed();
    }
}