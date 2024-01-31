namespace Lab_9;

public class LibraryEngine
{
    public delegate string BookDelegate(Book book);

    public static void ProcessBooks(List<Book> bList, BookDelegate fptr)
    {
        int i = 1;
        foreach (Book B in bList)
        {
            Console.WriteLine($"Book {i} {fptr(B)}");
            i++;
        }
    }
}