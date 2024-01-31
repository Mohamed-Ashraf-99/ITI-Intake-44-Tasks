using DateTime = System.DateTime;

namespace _10_Lab_Ten;

class Program
{
    static void Main(string[] args)
    {
        var employees = new List<Employee>()
        {
            new Employee(10, "Ashraf", new DateTime(9 / 18 / 1999), 21),
            new Employee(20, "Mohamed", new DateTime(9 / 18 / 1960), 21),
            new Employee(30, "Omar", new DateTime(9 / 18 / 1950), 21),
            new Employee(40, "Ahmed", new DateTime(9 / 18 / 2002), 21),
            new Employee(50, "Mahmoud", new DateTime(9 / 18 / 2007), 21),
        };
        var department = new Department(10, "SD", employees);

        foreach (var employee in employees)
        {
            department.AddStaff(employee);
        }
        
        //Register
        // employees[0].EmployeeLayOff += department.RemoveStaff;
        // employees[1].EmployeeLayOff += department.RemoveStaff;
        // employees[2].EmployeeLayOff += department.RemoveStaff;
        // employees[3].EmployeeLayOff += department.RemoveStaff;
        // employees[4].EmployeeLayOff += department.RemoveStaff;
        //
        // employees[0].RequestVacation(new DateTime(1/1/2024), new DateTime(1/28/2024));
        // employees[1].RequestVacation(new DateTime(1/1/2024), new DateTime(1/28/2024));
        // employees[2].RequestVacation(new DateTime(1/1/2024), new DateTime(1/28/2024));
        // employees[3].RequestVacation(new DateTime(1/1/2024), new DateTime(1/28/2024));
        // employees[4].RequestVacation(new DateTime(1/1/2024), new DateTime(1/28/2024));
    }
}