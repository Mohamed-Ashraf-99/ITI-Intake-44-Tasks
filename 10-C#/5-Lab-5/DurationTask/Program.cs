using DurationTask.DurationClass;

namespace DurationTask;

class Program
{
    static void Main(string[] args)
    {
        Duration durationOne = new Duration(1, 10, 15);
        Console.WriteLine(durationOne);
        Console.WriteLine(string.Empty);

        Duration durationTwo = new Duration(3600);
        Console.WriteLine(durationTwo);
        Console.WriteLine(); 
        
        Duration durationThree = new Duration(7800);
        Console.WriteLine(durationThree);
        Console.WriteLine(); 
        
        Duration durationFour = new Duration(666);
        Console.WriteLine(durationFour);
        Console.WriteLine(string.Empty);

        //////////////////////////////////////////////////////
        durationThree = durationOne + durationTwo;
        Console.Write($"durationOne + durationTwo = ");
        Console.WriteLine(durationThree);
        Console.WriteLine(string.Empty);
        
        Console.Write($"durationOne + 7800 = ");
        durationThree = durationOne + 7800;
        Console.WriteLine(durationThree);
        Console.WriteLine(string.Empty);
        
        Console.Write($"666 + durationThree = ");
        durationThree = 666 + durationThree;
        Console.WriteLine(durationThree);
        Console.WriteLine(string.Empty);
        
        Console.Write($"D3=D1++ (Increase One Minute) =  ");
        durationThree = durationOne++;
        Console.WriteLine(durationThree);
        Console.WriteLine(string.Empty);
        
        Console.Write($"D3 = D1-- (Decrease One Minute) = ");
        durationThree = --durationTwo;
        Console.WriteLine(durationThree);
        Console.WriteLine(string.Empty);
        
        Console.Write($"If ( D1 > D2 ) => ");
        Console.WriteLine(durationOne > durationTwo ? "True" : "False");
        Console.WriteLine(string.Empty);
        
        Console.Write($"If ( D1 <= D2 ) => ");
        Console.WriteLine(durationOne <= durationTwo ? "True" : "False");
        Console.WriteLine(string.Empty);

        Console.Write("DateTime obj = (DateTime)durationOne => ");
        DateTime obj = (DateTime)durationOne;
        Console.WriteLine(obj);

    }
}