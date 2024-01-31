using LabThree.HiringDate;
using LabThree.SecurityLevel;

namespace LabThree.Employee
{
    public class Employee : IComparable<Employee>
    {
        private int _id;
        private string _name;
        private Privileges _privileges;
        private decimal _salary;
        private GenderType.GenderType _gender;
        private HireDate _hireDate;
        public int Id { get => _id; set => _id = ValidId(value);}
        public string Name { get => _name; set => _name = ValidName(value); }
        public Privileges Privilege { get => _privileges; set => _privileges = ValidPrivileges(value); }
        public decimal Salary { get => _salary; set => _salary = ValidSalary(value); }
        public GenderType.GenderType Gender { get => _gender; set => _gender = ValidGender(value); }
        public HireDate hireDate { get => _hireDate; set => _hireDate = value ; }
        
        public Employee(int id, string name ,Privileges privileges, decimal salary, HireDate date, GenderType.GenderType gender)
        {
            Id = id;
            Name = name;
            Privilege = privileges;
            Salary = salary;
            hireDate = date;
            Gender = gender;
        }
        /// <summary>
        /// Returns a formatted string representation of the Employee object.
        /// </summary>
        /// <returns>A formatted string containing ID, Gender, Hire Date, Salary, and Security Level.</returns>
        public override string ToString()
        {
            return $"ID: {_id} \nName: {_name} \nGender:{_gender} \nHire Date: {HireDateFormater()} \nSalary: {_salary:C} \nSecurity Level: {_privileges}";
        }
        /// <summary>
        /// Compares this Employee object to another Employee object based on their Hire Date.
        /// </summary>
        /// <param name="employee">The Employee object to compare to.</param>
        /// <returns>
        /// -1 if this Employee was hired earlier than the provided Employee.
        /// 0 if both Employees were hired on the same date.
        /// 1 if this Employee was hired later than the provided Employee.
        /// </returns>
        public int CompareTo(Employee? employee)
        {
            if (employee is null)
                return 1;
            if (hireDate.Year > employee.hireDate.Year)
                return 1;
            else if(hireDate.Year < employee.hireDate.Year)
                return -1;
            if (hireDate.Month > employee.hireDate.Month)
                return 1;
            else if(hireDate.Month < employee.hireDate.Month)
                return -1;
            if (hireDate.Day > employee.hireDate.Day)
                return 1;
            else if(hireDate.Day < employee.hireDate.Day)
                return -1;
            else
                return 0;
        }
        //Validation
        /// <summary>
        /// Validates and returns a valid ID value.
        /// </summary>
        /// <param name="id">The ID value to validate.</param>
        /// <returns>The valid ID value if it is greater than zero.</returns>
        private int ValidId(int id)
        {
            if (id <= 0)
                throw new Exception("Id must be greater than Zero");
            else
            {
                return id;
            }
        }
        /// <summary>
        /// Validates and returns a valid Privileges enum value.
        /// </summary>
        /// <param name="privileges">The Privileges enum value to validate.</param>
        /// <returns>The valid Privileges enum value.</returns>
        private Privileges ValidPrivileges(Privileges privileges)
        {
            if (Enum.IsDefined(typeof(Privileges), privileges))
            {
                return privileges;
            }
            else
            {
                throw new Exception("Please Chose from the following 'DBA' || 'Developer' || 'Secretary' || 'Guest' ");
            }
        }
        /// <summary>
        /// Validates and returns a valid salary value.
        /// </summary>
        /// <param name="salary">The salary value to validate.</param>
        /// <returns>The valid salary value if it is greater than zero.</returns>
        private decimal ValidSalary(decimal salary)
        {
            if (salary <= 0)
                throw new Exception("Salary must be more than Zero");
            else
                return salary;
        }
        /// <summary>
        /// Formats the HireDate property as a string.
        /// </summary>
        /// <returns>The formatted string representation of the HireDate property.</returns>
        private string HireDateFormater() => hireDate.ToString();
        /// <summary>
        /// Validates and returns a valid GenderType.GenderType enum value.
        /// </summary>
        /// <param name="gender">The GenderType.GenderType enum value to validate.</param>
        /// <returns>The valid GenderType.GenderType enum value.</returns>
        private GenderType.GenderType ValidGender(GenderType.GenderType gender)
        {
            if (Enum.IsDefined(typeof(GenderType.GenderType), gender))
            {
                return gender;
            }
            else
            {
                throw new Exception("Please Enter 'M || 'F'");
            }
        }
        private string ValidName(string name)
        {
            foreach (var ch in name)
            {
                if (char.IsDigit(ch))
                {
                    throw new Exception("Name Can't contains numbers");
                }
            }
            return name;
        }
    }
}


