namespace _10_Lab_Ten;

public class Department
{
    public int DeptID { get; set; }
    public string DeptName { get; set; }
 
    private List<Employee> _staff;

    public Department(int deptId, string deptName, List<Employee> staff)
    {
        DeptID = deptId;
        DeptName = deptName;
        _staff = staff;
    }

    public Department(int deptId, string deptName)
    {
        // throw new NotImplementedException();
    }

    public void AddStaff (Employee employee)
    {
        //Try Register for EmployeeLayOff Event Here
        _staff.Add(employee);
    }
    
    ///CallBackMethod
    public void RemoveStaff (object sender , EmployeeLayOffEventArgs eventArgs)
    {
        if (sender is Employee employee)
        {
            _staff.Remove(employee);
            Console.WriteLine($"Employee {employee.EmployeeName} Removed from the Staff Because {eventArgs.Cause}");
        }
    }
}