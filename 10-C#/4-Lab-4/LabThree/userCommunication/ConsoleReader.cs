// using HiringDate;

using LabThree.HiringDate;
using LabThree.SecurityLevel;

namespace LabThree.userCommunication;

public static class ConsoleReader
{
    /// <summary>
    /// Reads an integer value from the console with the given message prompt.
    /// </summary>
    /// <param name="message">The message prompt displayed to the user.</param>
    /// <returns>The integer value entered by the user.</returns>
    public static int  ReadInteger(string message)
    {
        int result;
        do
        {
            Console.Write(message);
        } 
        while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }

    /// <summary>
    /// Reads a GenderType enum value from the console with the given message prompt.
    /// </summary>
    /// <param name="message">The message prompt displayed to the user.</param>
    /// <returns>The GenderType enum value entered by the user.</returns>
    public static GenderType.GenderType ReadGender(string message)
    {
        GenderType.GenderType gender;
        do
        {
            Console.Write(message);
        } while (!Enum.TryParse(Console.ReadLine(), out gender));
        return gender;
    }

    /// <summary>
    /// Reads a decimal value from the console with the given message prompt.
    /// </summary>
    /// <param name="message">The message prompt displayed to the user.</param>
    /// <returns>The decimal value entered by the user.</returns>
    public static decimal ReadSalary(string message)
    {
        decimal salary;
        do
        {
            Console.Write(message);

        } while (!decimal.TryParse(Console.ReadLine(), out salary));
        return salary;
    }

    /// <summary>
    /// Reads a DateTime value from the console with the given message prompt.
    /// </summary>
    /// <param name="message">The message prompt displayed to the user.</param>
    /// <returns>The DateTime value entered by the user.</returns>
    public static int ReadDate(string message)
    {
        int hireDate;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out hireDate));
        return hireDate;
    }

    /// <summary>
    /// Reads a Privileges enum value from the console with the given message prompt.
    /// </summary>
    /// <param name="message">The message prompt displayed to the user.</param>
    /// <returns>The Privileges enum value entered by the user.</returns>
    public static Privileges ReadPrivileges(string message)
    {
        Privileges privileges;
        do
        {
            Console.Write(message);

        } while (!Enum.TryParse(Console.ReadLine(), out privileges));
        return privileges;
    }

    public static string ReadName(string message)
    {
        string name;
        Console.Write(message);
        name = Console.ReadLine();
        return name;
    }
}