namespace PointTask.PointClass;

public class Point : IComparable<Point>,ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public Point() : this(0, 0, 0) {}
    public Point(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString() => $"Point Coordinates: ({X}, {Y}, {Z})";
    public bool Equals(Point other) => X == other.X && Y == other.Y && Z == other.Z;
    
    /// <summary>
    /// Override the Equals Method
    /// First check if the other object the same type of the current object
    /// if no return false, Cuz && is a short-circuit operator
    /// so if the left side = False the right side will not be checked
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (this == obj) return true;
        if (obj == null) return false;
        if (this.GetType() != obj.GetType()) return false;
        return obj is Point point && X == point?.X && Y == point?.Y && Z == point?.Z;;
    }

    //Operator Overloading
    
    public static Point operator + (Point firstPoint, Point secondPoint) => new Point(firstPoint.X + secondPoint.X, firstPoint.Y + secondPoint.Y, firstPoint.Z + secondPoint.Z);
    
    public static bool operator ==(Point firstPoint, Point secondPoint) => firstPoint.Equals(secondPoint);
    
    public static bool operator !=(Point? firstPoint, Point secondPoint) => !firstPoint.Equals(secondPoint);
    
    public int CompareTo(Point? other)
    {
        if (other is null)
            return 1;
        if (X > other.X) 
            return 1;
        else if (X < other.X)
            return -1;
        if (Y > other.Y)
            return 1;
        else if (Y < other.Y)
            return -1;
        else
            return 0;
    }
    public object Clone() => new Point(X, Y, Z);
    
} 