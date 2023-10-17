
use [Company-DB-Schema]

--Display all the employees Data--

select * from Employee

--Display the employee First name, last name, Salary and Department number--

select FName , LName, Salary , DNO from Employee

--Display all the projects names, locations and the department which is responsible 
-- 

select PNmae , PLoc, DNum from Project

--Four--

select FName+ ' ' + LName as [Full Name] , Salary * 12 * 10/100 as [Annual Comm] from Employee

--Five--

select SSN , FName from Employee 
where Salary > 1000

--Six--

select SSN , FName from Employee 
where Salary * 12 > 10000

--Seven--

select FName , Salary from Employee
where Sex = 'Female'

--eight--

select DNum , DName from Department
where ManagerID = 968574

--Nine--

select PNum, PName, PLoc from Project
where DNO = 10