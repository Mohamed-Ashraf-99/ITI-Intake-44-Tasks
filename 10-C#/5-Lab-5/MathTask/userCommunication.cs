namespace MathTask;

public static class userCommunication
{
    public static double ReadDouble(string message)
    {
        double number;
        do
        {
            Console.WriteLine(message);
        } while (!double.TryParse(Console.ReadLine(), out number));
        return number;
    }
}