using Employees;
using GenderType;
using SecurityLevel;

public struct EmployeeController
{
    private Employee[] _employees;
    public EmployeeController(int empNumber)
    {
        _employees = new Employee[empNumber];
    }
    
    public void AddEmployees()
    {
        int id;
        DateTime hireDate;
        Gender gender;
        decimal salary;
        Privileges privileges;

        for (int i = 0; i < _employees.Length; i++)
        {
            Console.WriteLine($"=====================Enter Employee [{i + 1}] Data=======================");
            //Emplyee ID
            do
            {
                Console.Write($"Enter Employee [{i + 1}] ID: ");
                
            } while (!int.TryParse(Console.ReadLine(), out id));
            _employees[i].SetId(id);

            //Emplyee Gender
            do
            {
                Console.Write($"Enter Employee [{i + 1}] Gender: ");
            } while (!Enum.TryParse(Console.ReadLine(), out gender));
            _employees[i].SetGender(gender);

            //Emplyee Salary
            do
            {
                Console.Write($"Enter Employee [{i + 1}] Salary: ");
                
            } while (!decimal.TryParse(Console.ReadLine(), out salary));
            _employees[i].SetSalary(salary);

            //Emplyee Hire Date
            do
            {
                Console.Write($"Enter Employee [{i + 1}] Hire Date mm/dd/yyyy: ");
                
            } while (!DateTime.TryParse(Console.ReadLine(), out hireDate));
            _employees[i].SetHireDate(hireDate);

            //Employee Privileges
            do
            {
                Console.Write($"Enter Employee [{i + 1}] Privilege: ");
                
            } while (!Enum.TryParse(Console.ReadLine(), out privileges));
            _employees[i].SetPrivilege(privileges);

            Console.WriteLine();

        }
    }
    
    public void DisplayAllEmployeesData()
    {
        for (int i = 0; i < _employees.Length; i++)
        {
            Console.WriteLine($"=============Employee [{i + 1}] Data=================");
            Console.WriteLine(_employees[i].ToString());
            Console.WriteLine();
        }
    }
}

