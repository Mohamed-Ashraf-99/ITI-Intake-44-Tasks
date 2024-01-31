namespace _10_Lab_Ten;

public class BoardMember : Employee
{
    public void Resign ()
    {
        throw new NotImplementedException();
    }

    public BoardMember(int employeeId, string employeeName, DateTime birthDate, int vacationStock) : base(employeeId, employeeName, birthDate, vacationStock)
    {
    }
}