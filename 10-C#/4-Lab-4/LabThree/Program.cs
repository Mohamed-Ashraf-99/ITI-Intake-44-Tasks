using LabThree.EmplyeeIndexer;
using LabThree.HiringDate;
using LabThree.userCommunication;

namespace LabThree
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            
            int numberOfEmployees;
            do
            {
                Console.Write("Please Enter Employees Number :");
            } while(!int.TryParse(Console.ReadLine(), out numberOfEmployees));
            
            var employee = new Employee.Employee[numberOfEmployees];
            
            for (var i = 0; i < numberOfEmployees ; i++)
            {
                Console.WriteLine($"=====================Enter Employee [{i + 1}] Data=======================");
                var id = ConsoleReader.ReadInteger($"Enter Employee [{i + 1}] ID: ");
                var name = ConsoleReader.ReadName($"Enter Employee [{i + 1}] Name: ");
                var gender = ConsoleReader.ReadGender($"Enter Employee [{i + 1}] Gender: ");
                var salary = ConsoleReader.ReadSalary($"Enter Employee [{i + 1}] Salary: ");
                var Day = ConsoleReader.ReadDate($"Enter Employee [{i + 1}] Hire Date Day: ");
                var Month = ConsoleReader.ReadDate($"Enter Employee [{i + 1}] Hire Date Month: ");
                var Year = ConsoleReader.ReadDate($"Enter Employee [{i + 1}] Hire Date Year: ");
                var privileges = ConsoleReader.ReadPrivileges($"Enter Employee [{i + 1}] Privilege: ");
                HireDate date = new HireDate(Day, Month, Year);
                employee[i] = new Employee.Employee(id, name, privileges, salary, date, gender);
            }
            
            Console.WriteLine("==================Before Sort=======================");
            for (int  i = 0; i < employee.Length ; i++)
            {
                Console.WriteLine($"=============Employee [{i + 1}] Data=================");
                Console.WriteLine(employee[i].ToString());
                Console.WriteLine();
            }
            
            
            //Sort Employees
            Console.WriteLine("==============After Sort=======================");
            Array.Sort(employee);
             for (int  i = 0; i < employee.Length ; i++)
             {
                 Console.WriteLine($"=============Employee [{i + 1}] Data=================");
                 Console.WriteLine(employee[i].ToString());
                 Console.WriteLine();
             }
            
            Console.WriteLine("==================After Indexer=======================");
           
            var findEmployee = new EmployeeSearch(employee); 
            Console.WriteLine(string.Empty);
            
            
            Console.WriteLine("============== Search For Employee with ID=======================");
            
            var employeeId = ConsoleReader.ReadInteger($"Enter Employee ID: ");
            Console.WriteLine($"Employee with ID {employeeId} Date");
            Console.WriteLine(findEmployee[employeeId]);
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("=================Search For Employee with Name====================");

            var employeeName = ConsoleReader.ReadName("Enter Employee Name: ");
            Console.WriteLine($"Employee with name {employeeName} Data: ");
            Console.WriteLine(findEmployee[employeeName]);
            
            Console.WriteLine(string.Empty);
            Console.WriteLine("=================After Search with Employee Name====================");
            var day = ConsoleReader.ReadDate($"Enter Employee Hire Date Day: ");
            var month = ConsoleReader.ReadDate($"Enter Employee Hire Date Month: ");
            var year = ConsoleReader.ReadDate($"Enter Employee Hire Date Year: ");
            var employeeHireDate = new HireDate(day, month, year);
            Console.WriteLine($"Employee with Hire Date {day}/{month}/{year} Data: ");
            Console.WriteLine(findEmployee[employeeHireDate]);
        }
    }
}


