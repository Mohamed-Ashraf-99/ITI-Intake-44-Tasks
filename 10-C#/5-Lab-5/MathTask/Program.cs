namespace MathTask;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(MathOperations.Add(10, 20));
        Console.WriteLine(MathOperations.Subtract(70, 20));
        Console.WriteLine(MathOperations.Multiply(60, 20));
        Console.WriteLine(MathOperations.Divide(50, 20));
    }
}