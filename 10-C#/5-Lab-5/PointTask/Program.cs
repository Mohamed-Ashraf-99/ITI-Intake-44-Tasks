using PointTask.PointClass;
using PointTask.userCommunication;

namespace PointTask;

class Program
{
    static void Main(string[] args)
    {
        var P = new Point(10, 10, 10);
        Console.WriteLine(P);
        Console.WriteLine(string.Empty);
        
        var pointOne = new Point();
        pointOne.X = ConsoleReader.ReadInger("Enter the value of X Direction: ");
        pointOne.Y = ConsoleReader.ReadInger("Enter the value of Y Direction: ");
        pointOne.Z = ConsoleReader.ReadInger("Enter the value of Z Direction: ");
        
        Console.WriteLine(pointOne);
        Console.WriteLine(string.Empty);
        var pointTwo = new Point();
        pointTwo.X = ConsoleReader.ReadInger("Enter the value of X Direction: ");
        pointTwo.Y = ConsoleReader.ReadInger("Enter the value of Y Direction: ");
        pointTwo.Z = ConsoleReader.ReadInger("Enter the value of Z Direction: ");
        Console.WriteLine(pointTwo);
        
        //Check the equality of PointOne and PointTwo
        Console.WriteLine(pointOne.Equals(pointTwo) ? "P1 Equals P2" : "P1 Not Equal P2");
        Console.WriteLine(string.Empty);
        
        //Add PointOne and PointTwo
        Point pointThree = pointOne + pointTwo;
        Console.WriteLine(pointThree);
        Console.WriteLine(string.Empty);
        Console.WriteLine("Check the equality with == operator");
        //Check Equality with == != operators
        Console.WriteLine(pointOne == pointTwo ? "pointOne Equal pointTwo" : "pointOne not Equal pointTwo");


        var points = new Point[3];
        points[0] = new Point(30, 20, 30);
        points[1] = new Point(20, 20, 30);
        points[2] = new Point(90, 20, 30);

        Console.WriteLine("Sort According to Y ");
        Array.Sort(points);

        foreach (var point in points)
        {
            Console.WriteLine(point);
        }
        
        var pointsTwo = new Point[3];
        pointsTwo[0] = new Point(20, 70, 30);
        pointsTwo[1] = new Point(20, 20, 30);
        pointsTwo[2] = new Point(20, 50, 30);

        Console.WriteLine("Sort According to Y ");
        Array.Sort(pointsTwo);

        foreach (var point in pointsTwo)
        {
            Console.WriteLine(point);
        }

        pointThree = new Point(10, 20, 30);
        Point? clonedPoint = pointThree.Clone() as Point;
        Console.WriteLine();
        Console.WriteLine(clonedPoint);
    }
}