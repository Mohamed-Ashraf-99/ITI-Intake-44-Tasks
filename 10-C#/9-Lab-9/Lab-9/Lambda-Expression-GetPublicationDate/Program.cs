using Lab_9;

namespace Lambda_Expression_GetPublicationDate;

class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>()
        {
            new Book("1234567890", "Clean code", new string[] {"Robert C.Martin", "Author B"}, DateTime.Parse("2022-01-01"), 19.99m),
            new Book("0987654321", "C# Illustrated", new string[] {"Author C", "Author D"}, DateTime.Parse("2022-02-15"), 29.99m),
            new Book("5678901234", "C# In a nutshell", new string[] {"Author E", "Author F"}, DateTime.Parse("2022-03-20"), 14.99m),
        };
        LibraryEngine.ProcessBooks(books, (Book book) => $" ISBN : {book.PublicationDate}");

    }
}