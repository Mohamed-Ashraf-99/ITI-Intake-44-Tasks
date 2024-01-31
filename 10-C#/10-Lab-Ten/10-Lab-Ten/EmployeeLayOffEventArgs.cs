namespace _10_Lab_Ten;

public class EmployeeLayOffEventArgs : EventArgs
{
    public LayOffCause Cause { get; set; }
}