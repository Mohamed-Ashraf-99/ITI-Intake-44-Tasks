namespace DurationTask.DurationClass;

public class Duration
{
    private int _hours;
    private int _minutes;
    private int _seconds;
    
    public int Hours { get => _hours; set => _hours = ValidHour(value); }
    public int Minutes { get => _minutes; set => _minutes = ValidMinutes(value); }
    public int Seconds { get => _seconds; set => _seconds = ValidSeconds(value); }
    
    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }
    public Duration(int seconds)
    {
        Hours = seconds / 3600;
        Minutes = (seconds % 3600) / 60;
        Seconds = seconds % 60; 
    }

    public override string ToString()
    {
        if (DurationInSeconds() >= 3600)
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        else
            return $"Minutes: {Minutes}, Seconds: {Seconds}";
    } 
    
    public override bool Equals(object? obj) => obj is Duration other && Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;

    public static implicit operator DateTime(Duration duration)
    {
        return new DateTime(2024, 1, 17, duration.Hours, duration.Minutes, duration.Seconds);
    }
    
    public override int GetHashCode() => HashCode.Combine(Hours, Minutes, Seconds);
    
    // ==========Operator overloading===========
    public static Duration operator +(Duration durationOne, Duration durationTwo)
    {
        int hours = durationOne.Hours + durationTwo.Hours;
        int minutes = durationOne.Minutes + durationTwo.Minutes;
        int seconds = durationOne.Seconds + durationTwo.Seconds;
        return new Duration(hours, minutes, seconds);
    }

    public static Duration operator +(Duration durationOne, int seconds)
    {
        int totalSeconds = (durationOne.Hours * 60 + durationOne.Minutes * 60 +durationOne.Seconds )+ seconds;
        return new Duration(totalSeconds);
    }

    public static Duration operator +(int seconds, Duration durationOne)
    {
        int totalSeconds = (durationOne.Hours * 60 + durationOne.Minutes * 60 +durationOne.Seconds )+ seconds;
        return new Duration(totalSeconds);
    }

    public static Duration operator ++(Duration duration) => duration + new Duration(0, 1, 0);

    public static Duration operator -(Duration durationOne, Duration durationTwo)
    {
        int hours = Math.Max(0, durationOne.Hours - durationTwo.Hours);
        int minutes = Math.Max(0, durationOne.Minutes - durationTwo.Minutes);
        int seconds = Math.Max(0, durationOne.Seconds - durationTwo.Seconds);
        return new Duration(hours, minutes, seconds);
    }

    public static Duration operator -(int seconds, Duration duration)
    {
        int totalSeconds = Math.Max(0, seconds - duration.DurationInSeconds());
        return new Duration(totalSeconds);
    }
    
    public static Duration operator --(Duration duration) => duration - new Duration(0, 1, 0);
    
    public static bool operator >(Duration durationOne, Duration durationTwo) => durationOne.DurationInSeconds() > durationTwo.DurationInSeconds();

    public static bool operator <(Duration durationOne, Duration durationTwo) => durationOne.DurationInSeconds() > durationTwo.DurationInSeconds();
    
    public static bool operator >=(Duration durationOne, Duration durationTwo) => durationOne.DurationInSeconds() > durationTwo.DurationInSeconds();
    
    public static bool operator <=(Duration durationOne, Duration durationTwo) => durationOne.DurationInSeconds() > durationTwo.DurationInSeconds();
    
    public static bool operator true(Duration duration) => duration.DurationInSeconds() > 0;

    public static bool operator false(Duration duration) => duration.DurationInSeconds() == 0;
    
    private int ValidHour(int hour)
    {
        if (hour < 0)
            throw new Exception("Hours Must be more tha Zero");
        else
            return hour;
    }
    private int ValidMinutes(int minute)
    {
        if (minute >= 0 && minute <= 60)
            return minute;
        else
            throw new Exception("Minutes must be between 0 and 60");
    }
    private int ValidSeconds(int seconds)
    {
        if (seconds >= 0 && seconds <= 60)
            return seconds;
        else
            throw new Exception("Minutes must be between 0 and 60");
    }
    private int DurationInSeconds() => (Hours * 60 * 60) + (Minutes * 60) + Seconds;
}