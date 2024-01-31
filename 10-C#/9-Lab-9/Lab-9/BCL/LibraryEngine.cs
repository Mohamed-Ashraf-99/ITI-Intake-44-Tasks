using Lab_9;

namespace BCL;

public class LibraryEngine
{
    
    public static void ProcessBooks(List<Book> bList, Func<Book, string> fptr)
    {
        int i = 1;
        foreach (Book B in bList)
        {
            Console.WriteLine($"Book {i} {fptr(B)}");
            i++;
        }
    }
}