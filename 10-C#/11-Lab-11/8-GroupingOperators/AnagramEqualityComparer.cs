namespace _8_GroupingOperators;

public class WordsEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string? left, string? right)
    {
        if (left == null && right == null)
            return true;
        if (left == null | right == null)
            return false;

        return string.Concat(left.OrderBy(c => c)).Equals(string.Concat(right.OrderBy(c => c)));
    }

    public int GetHashCode(string obj)
    {
        return string.Concat(obj.OrderBy(c => c)).GetHashCode();
    }
}