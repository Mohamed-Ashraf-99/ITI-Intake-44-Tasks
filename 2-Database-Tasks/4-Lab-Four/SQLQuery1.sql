Use Company_SD_Full

--1. Display (Using Union Function)
--a. The name and the gender of the dependence that's gender is Female and 
--depending on Female Employee.
--b. And the male dependence that depends on Male Employee.

select D.Dependent_name , D.Sex 
from Dependent D join Employee E 
on D.ESSN = E.SSN
where D.Sex = 'F' and E.Sex = 'F'
union all
select D.Dependent_name , D.Sex 
from Dependent D join Employee E 
on D.ESSN = E.SSN
where D.Sex = 'M' and E.Sex = 'M';

--2. For each project, list the project name and the total hours per week (for all employees) spent on that project.

select P.Pname , Sum(W.Hours) [Total Hours]
from Project P join Works_for W
on P.Pnumber = W.Pno
group by P.Pname

--3. Display the data of the department which has the smallest employee ID over all employees' ID.

select * 
from  Departments D join Employee E
on  D.Dnum = E.Dno
where E.SSN = (select min(ssn) from Employee);

--4. For each department, retrieve the department name and the maximum, minimum and average salary of its employees.select Dname, max(E.salary) [Maximum Salary] , min(E.salary) [Minimum Salary] , avg(E.salary) [Average Salary]
from Departments D join Employee E
on D.Dnum = E.Dno
group by D.Dname;

--5. List the full name of all managers who have no dependents.

select CONCAT(Fname,' ',Lname) [Full Name] 
from Employee E join Departments D
on E.SSN = D.MGRSSN
left outer join Dependent D1
on D1.ESSN = E.SSN
where D1.ESSN is null;

--6. For each department -- if its average salary is less than the average salary of all employees-- display its number, name and number of its employees.Select D.Dnum , D.Dname ,Count(E.SSN) [Number of Employees]from Departments D left  join Employee Eon D.Dnum = E.Dnogroup by  D.Dname , D.Dnumhaving Avg(salary) < (select avg(salary) from Employee);--7. Retrieve a list of employees names and the projects names they are working on 
--ordered by department number and within each department, ordered alphabetically by 
--last name, first name.Select CONCAT(E.Fname,' ',E.Lname) [Full Name]  , P.Pname from Employee E join Works_for Won W.ESSn = E.SSN join Project Pon P.Pnumber = W.Pnoorder by E.Dno , E.Lname , E.Fname;--8. Try to get the max 2 salaries using subquery****select Max(salary)from ( select salary       From Employee	   where salary < (select MAX(salary) from Employee)	   )as T2;--9. Get the full name of employees that is similar to any dependent name intersictSELECT CONCAT(E.Fname,' ', E.Lname)[Employees Name]
FROM Employee E join Dependent D
on E.SSN = D.ESSN
WHERE D.Dependent_name = CONCAT(E.Fname,' ', E.Lname);--10. Display the employee number and name if at least one of them have dependents (use exists keyword) self-study.SELECT E.SSN, CONCAT(E.Fname,' ', E.Lname) [Employee Name]
FROM Employee E
WHERE EXISTS (SELECT * FROM Dependent D WHERE D.ESSN = E.SSN );-- 11.	In the department table insert new department called "DEPT IT" , with id 100, employee with
-- SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'

INSERT INTO Departments VALUES ('DEPT IT', 100, 112233, '1-11-2006');


-- 12.	Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)  
-- moved to be the manager of the new department (id = 100), 
-- and they give you(your SSN =102672) her position (Dept. 20 manager) 
--	a.	First try to update her record in the department table

UPDATE Departments SET MGRSSN = 968574 WHERE Dnum = 100;

--	b.	Update your record to be department 20 manager.

UPDATE Departments SET MGRSSN = 102672 WHERE Dnum = 20;

--	c.	Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)

UPDATE Employee SET Superssn = 102672 WHERE SSN = 102660;



-- 13.	Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344)
--      so try to delete his data from your database in case you know that you will be 
--       temporarily in his position.
-- Hint: (Check if Mr. Kamel has dependents, works as a department manager, 
--        supervises any employees or works in any projects and handle these cases).

-- 1- Check if Mr. Kamel has dependents  ****delete

UPDATE Dependent SET ESSN =102672 WHERE ESSN=223344;

-- 2- works as a department manager

UPDATE Departments SET MGRSSN=102672 WHERE MGRSSN = 223344;

-- 3- supervises any employees

UPDATE Employee SET Superssn=102672 WHERE Superssn = 223344;

-- 4- works in any projects********

UPDATE Works_for SET ESSn=102672 WHERE ESSn= 223344;
DELETE FROM Employee WHERE SSN = 223344;

-- 14.	Try to update all salaries of employees who work in Project �Al Rabwah� by 30%

UPDATE Employee  SET Salary = Salary*1.3 
FROM Works_for WF join Employee 
ON Employee.SSN = WF.ESSn 
join Project P on P.Pnumber = WF.Pno
WHERE P.Pname = 'Al Rabwah';




















