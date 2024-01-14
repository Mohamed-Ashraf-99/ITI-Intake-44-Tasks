
using GenderType;
using HiringDate;
using SecurityLevel;
using System.Reflection;

namespace Employees
{
    public struct Employee
    {
        private int _id;
        private Privileges _privileges;
        private decimal _salary;
        private HireDate _hireDate;
        private Gender _gender;

        public void SetId(int id) => _id = id;
        public int GetId() => _id;

        public Employee(int id, Privileges privileges, decimal salary, HireDate hireDate, Gender gender)
        {
            _id = id;
            _privileges = privileges;
            _salary = salary;
            _hireDate = hireDate;
            _gender = gender;
        }

        //Privilege
        public void SetPrivilege(Privileges privileges)
        {
            _privileges = (Enum.IsDefined(typeof(Privileges), privileges))
                ? privileges
                : throw new Exception("Please Chose from the following 'DBA' || 'Developer' || 'Secretary' || 'Guest' ");
        }
        public Privileges GetPrivilege() => _privileges;

        //Salary
        public void SetSalary(decimal salary) => _salary = salary;
        public string GetSalary() => $"{_salary:C}";

        // Hire Date
        public void SetHireDate(DateTime hireDate)
        {
            _hireDate.SetDay(hireDate.Day);
            _hireDate.SetMonth(hireDate.Month);
            _hireDate.SetYear(hireDate.Year);
        }

        private string GetHireDate() => _hireDate.GetFullHireDate();
        
        //Gender
        public void SetGender(Gender gender)
        {
            _gender = (Enum.IsDefined(typeof(Gender), gender))
                ? gender
                : throw new Exception("Please Enter 'M || 'F'");
        }
        public Gender GetGender() => this._gender;

        // Override ToString()
        public override string ToString()
        {
            return $"ID: {_id} \nGender:{_gender} \nHire Date: {GetHireDate()} \nSalary: {_salary:C} \nSecurity Level: {_privileges}";
        }

    }
}


