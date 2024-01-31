namespace Lab_9;

public class BookFunctions
{
    public static string GetTitle (Book B) => $" Titel : {B.Title}";
    
    public static string GetAuthors(Book B) => $" Authors: {string.Join(", ", B.Authors)}";

    public static string GetPrice(Book B) => $" Price: {B.Price.ToString()}";
    
}