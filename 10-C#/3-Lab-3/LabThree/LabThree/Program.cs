namespace LabThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size;
           
            do
            {
                Console.Write("How many Employees you want to Add :");
            } while(!int.TryParse(Console.ReadLine(), out size));
            
            EmployeeController employee = new EmployeeController(size);

            employee.AddEmployees();
            employee.DisplayAllEmployeesData();

        }
    }
}


