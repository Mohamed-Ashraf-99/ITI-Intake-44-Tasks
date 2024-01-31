using LabThree.Employee;
using LabThree.HiringDate;

namespace LabThree.EmplyeeIndexer;

public class EmployeeSearch
{
    private Employee.Employee[] _employees;
    public EmployeeSearch(Employee.Employee[] employees)
    {
        _employees = employees;
    }
    
    /// <summary>
    /// Retrieves an Employee object from the _employees array based on the specified employee ID.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <returns>The Employee object with the corresponding ID.</returns>
    /// <exception cref="Exception">Thrown when an employee with the specified ID is not found.</exception>
    public Employee.Employee this[int id]
    {
        get
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i].Id == id)
                {
                    return _employees[i];
                }
            }

            throw new Exception("Not Found");
        } 
    }
    
    /// <summary>
    /// Gets an Employee object from the _employees array based on a given name.
    /// </summary>
    /// <param name="name">The name of the employee to retrieve.</param>
    /// <returns>The Employee object with the specified name.</returns>
    /// <exception cref="Exception">Thrown when an employee with the specified name is not found.</exception>
    public Employee.Employee this[string name]
    {
        get
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i].Name == name)
                {
                    return _employees[i];
                }
            }

            throw new Exception("Not Found");
        } 
    }

    /// <summary>
    /// Gets an Employee object from the _employees array based on a given hire date.
    /// </summary>
    /// <param name="hireDate">The hiring date of the employee to retrieve.</param>
    /// <returns>The Employee object with the specified hiring date.</returns>
    /// <exception cref="Exception">Thrown when an employee with the specified hiring date is not found.</exception>
    public Employee.Employee this[HiringDate.HireDate hireDate]
    {
        get
        {
            for (int i = 0; i < _employees.Length; i++)
            {
                if (_employees[i].hireDate.Day == hireDate.Day && _employees[i].hireDate.Month == hireDate.Month && _employees[i].hireDate.Year == hireDate.Year)
                {
                    return _employees[i];
                }
            }

            throw new Exception("Not Found");
        }  
    }
}


