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

--6. display all the employees in department 30 whose salary from 1000 to 2000 LE monthly