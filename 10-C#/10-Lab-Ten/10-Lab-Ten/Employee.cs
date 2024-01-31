namespace _10_Lab_Ten;

/// <summary>
/// Publisher 
/// </summary>
public class Employee
{
    public event EventHandler<EmployeeLayOffEventArgs>? EmployeeLayOff;
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public DateTime BirthDate { get; set; }
    public int VacationStock { get; set; }

    public Employee(int employeeId, string employeeName, DateTime birthDate, int vacationStock)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
        BirthDate = birthDate;
        VacationStock = vacationStock;
    }

    public Employee()
    {
        
    }

    public override string ToString() => $"Name: {EmployeeName}, ID: {EmployeeId}, BirthDate: {BirthDate} VacationStock: ({VacationStock})";
    

    public bool RequestVacation(DateTime from, DateTime to)
    {
        if (to.Day - from.Day < VacationStock)
        {
            VacationStock -= (to.Day - from.Day);
            return true;
        }
        else
            OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = LayOffCause.VacationStock });
        return false;
    }

    public bool EndOfYearOperation()
    {
        if (BirthDate.Year > 1964)
            return true;
        else 
            return false;
    }

    protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs employeeLayOffEvent)
    {
        EmployeeLayOff?.Invoke(this, employeeLayOffEvent);
    }
}