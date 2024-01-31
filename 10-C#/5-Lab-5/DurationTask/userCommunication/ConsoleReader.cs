namespace DurationTask.userCommunication;

public class ConsoleReader
{
    public static int ReadInger(string meesage)
    {
        int number;
        do
        {
            Console.Write(meesage);
        } while (!int.TryParse(Console.ReadLine(), out number));

        return number;
    }
}