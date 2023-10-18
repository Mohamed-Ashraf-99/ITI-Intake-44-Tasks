use Company_SD_Full 

--1. Display the Department id, name and id and the name of its manager.

select Dnum , Dname , MGRSSN , Fname 
from Departments D join Employee E
on D.MGRSSN = E.SSN

--2. Display the name of the departments and the name of the projects under its control.

select Dname , Pname
from Departments D  join Project P
on D.Dnum = P.Dnum

--3. Display the full data about all the dependence associated with the name of the employee they depend on him/her

select * , Fname + ' ' + Lname as 'Employee Name'
from Dependent D join Employee E
on D.ESSN = E.SSN

--4. Display the Id, name, and location of the projects in Cairo or Alex city
 
select Pnumber , Pname ,Plocation 
from Project
where City in ('Alex' , 'Cairo')

--5. Display the Projects full data of the projects with a name starts with "a" letter

select * from Project
where Pname like 'a%'

--6. display all the employees in department 30 whose salary from 1000 to 2000 LE monthlyselect * from Employeewhere Dno = 30 and salary between 1000 and 2000--7. Retrieve the names of all employees in department 10 who work more than or equal to 10 hours per week on "AL Rabwah" project.select CONCAT(Fname+' ',Lname) [Employee Name]from Employee E join Works_for Won E.Dno = 10 and W.Hours >= 10 and E.SSN = W.ESSnjoin Project Pon P.Pnumber = W.Pno and P.Pname = 'AL Rabwah'--8. Find the names of the employees who directly supervised Kamel Mohamedselect CONCAT(E.Fname+' ' ,E.Lname) [Employees who supervised  Kamel Mohamed]from Employee E join Employee E1on E.Superssn = E1.SSNwhere E1.Fname = 'Kamel' and E1.Lname = 'Mohamed'--9. Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.select CONCAT(E.Fname+' ' ,E.Lname) [Employee Name] , Pnamefrom Employee E join Works_for Won E.SSN = W.ESSnjoin Project Pon P.Pnumber = W.Pnoorder by P.Pname --10. For each project located in Cairo City, find the project number, the controlling department name, the department manager’s last name address and birthdate.select P.Pnumber, D.Dname, CONCAT(E.Fname+' ' ,E.Lname) [Manager Name] , E.Address ,E.Bdatefrom Project P join Departments Don D.Dnum = P.Dnumjoin Employee Eon E.SSN = D.MGRSSNwhere P.City = 'Cairo'--11. Display All Data of the mangers.select *from Employee E join Departments Don E.SSN = D.MGRSSN--12. Display All Employees data and the data of their dependents even if they have no dependentsselect E.* , D.*from Employee E Left outer join Dependent Don E.SSN = D.ESSN--13. Insert your personal data in the employee table as a new employee in department number 30. SSN=102672, Superssn=112233select * from employeeinsert into Employee values ('Mohamed', 'Ashraf' , 102672 , 9/18/1999 , 'Cairo, Nasr City' , 'M', 20000, 112233, 30)--14. Insert another employee with personal data your friend as new employee in department number 30, SSN 102660, but don't enter any value for salary or manager number to him.insert into Employee (SSN, Fname, Lname, Bdate, Address, Sex, Dno)values (102660, 'Omar' , 'Mohamed' , 9/9/1999 , 'Cairo, Nasr City' , 'M', 30)--15. In the department table insert a new department called "DEPT IT", with id 100, employee with SSN=112233 as a manager for this department. The start date for this manager is '1-11-2006'insert into Departments values ('DEPT IT', 100, 112233, '1-11-2006');select * from Departments