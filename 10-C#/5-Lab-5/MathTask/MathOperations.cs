namespace MathTask;

public static class MathOperations
{
    public static double Add(double firstNumber, double secondNumber) => firstNumber + secondNumber;

    public static double Subtract(double firstNumber, double secondNumber) => firstNumber - secondNumber;

    public static double Multiply(double firstNumber, double secondNumber) => firstNumber * secondNumber;

    public static double Divide(double firstNumber, double secondNumber)
    {
        if (secondNumber != 0)
            return firstNumber / secondNumber;
        else
            return -1;
    }
}