namespace _10_Lab_Ten;

public class SalesPerson : Employee
{
    public int AchievedTarget { get; set; }
    public bool CheckTarget (int Quota)
    {
        throw new NotImplementedException();
    }

    public SalesPerson(int employeeId, string employeeName, DateTime birthDate, int vacationStock) : base(employeeId, employeeName, birthDate, vacationStock)
    {
    }
}