namespace _1_Longest_Distance_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[] numbers = new int[size];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }


            int longestDistance = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = numbers.Length - 1; j > i + 1; j--)
                {

                    if (numbers[j] == numbers[i])
                    {
                        int distance = (j - i) - 1;
                        if (distance > longestDistance)
                        {
                            longestDistance = distance;
                        }
                        break;
                    }

                }
            }
            Console.WriteLine(longestDistance);
        }
    }
}
