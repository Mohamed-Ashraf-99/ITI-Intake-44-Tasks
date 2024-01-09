using System.Diagnostics;

namespace _3_count_the_occurrence_of_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            int number = 100_000;
            int counter = 0;
            string[] numbers = new string[number];

            stopwatch.Start();
            for (int i = 0; i < number; i++)
            {
                numbers[i] = i.ToString();
            }
           
            for (int i = 0;i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    if (numbers[i][j] == '1')
                    {
                        counter++;
                    }
                }
            }
            stopwatch.Stop();

            Console.WriteLine(counter);
            Console.WriteLine($"Process Exceution Time in MS For Loop:  {stopwatch.ElapsedMilliseconds}");
            

            //With Mathematical Functions and Numeric values
            var stopwatchTwo = new Stopwatch();

            int digits = 5 ;
            stopwatchTwo.Start();
            double counterTwo = digits * Math.Pow(10, digits - 1);
            stopwatchTwo.Stop();
            Console.WriteLine(counterTwo);
            Console.WriteLine($"Process Exceution Time in MS For Equation: {stopwatchTwo.ElapsedMilliseconds}");
        }
    }
}
