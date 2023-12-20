USE SD;

-->1-)Create the following tables with all the required information and load 
   ---the required data as specified in each table using insert 
------statements[at least two rows].
sp_addtype IOC,'nchar(2)'
create rule r1 as @value IN('NY','DS','KW')
create default def1 as 'NY'
sp_bindrule r1,'IOC'
sp_bindefault def1,'IOC'
CREATE TABLE Department
(
  DeptNO int,
  DeptName varchar(20),
  Location IOC,
  constraint c1 primary key(DeptNO),
)

INSERT INTO Department
VALUES (1,'Research','NY'),
       (2,'Accounting','DS'),
	   (3,'Markiting','KW');

---------------------------------------------
CREATE TABLE Employee
(
  EmpNO int,
  EmpFname varchar(20) NOT NULL,
  EmpLname varchar(20) NOT NULL,
  DeptNO int,
  Salary int,
  CONSTRAINT c2 PRIMARY KEY(EmpNO),
  CONSTRAINT c3 FOREIGN KEY(DeptNO) REFERENCES Department(DeptNO),
  CONSTRAINT c4 UNIQUE(Salary),
)
CREATE RULE r2 as @sal < 6000;
sp_bindrule r2, 'Employee.Salary';

INSERT INTO Employee
VALUES (25348, 'Mathew', 'Smith', 3, 2500),
       (10102, 'Ann', 'Jones', 3, 3000),
	   (18316, 'John', 'Barrimore', 1, 2400),
	   (29346, 'James', 'James', 2, 2800),
	   (9031, 'Lisa', 'Bertoni', 2, 4000),
	   (2581, 'Elisa', 'Hansel', 2, 3600),
	   (28559, 'Sybl', 'Moser', 1, 2900);

------------------------------------------------
CREATE TABLE Project
(
  ProjectNO int,
  ProjectName varchar(20) NOT NULL,
  Budget int,
  CONSTRAINT c5 PRIMARY KEY(ProjectNO),
)
INSERT INTO Project
VALUES (1, 'Apollo', 120000),
       (2, 'Gemini', 95000),
	   (3, 'Mercury', 185600);
--------------------------------------------------
--Testing Referential Integrity
--1-Add new employee with EmpNo =11111 In the works_on table [what will 
--happen]INSERT INTO Works_on
(EmpNO) values(11111);

--2-2-Change the employee number 10102 to 11111 in the works on table [what will 
--happen]


INSERT INTO Employee
Values(11111,'Mohamed', 'Ashraf', 3, 5000);

INSERT INTO Works_on
values(11111, 3, 'Analyst','');

UPDATE Works_on SET EmpNO = 10102
WHERE EmpNO = 11111;

--3-Modify the employee number 10102 in the employee table to 22222. [what will 
--happen]
UPDATE Employee SET EmpNo = 22222
WHERE EmpNo = 10102;

--4-Delete the employee with id 10102
DELETE FROM Employee
WHERE EmpNo = 10102;

----------------------------------------------
--Table modification
--1-Add TelephoneNumber column to the employee table[programmatically]
ALTER TABLE Employee add TelephoneNumber int;

--2-drop this column[programmatically]
ALTER TABLE Employee drop column TelephoneNumber;
-----------------------------------------------
--2. Create the following schema and transfer the following tables to it 
----a. Company Schema 
------i. Department table (Programmatically)
CREATE SCHEMA Company;
ALTER SCHEMA Company TRANSFER Department;

------ii. Project table (using wizard)

--b. Human Resource Schema
---i. Employee table (Programmatically)CREATE SCHEMA HR;ALTER SCHEMA HR TRANSFER Employee;--3. Write query to display the constraints for the Employee table.SELECT *FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGEWHERE TABLE_NAME = 'Employee';--4. Create Synonym for table Employee as Emp and then run the 
---following queries and describe the results
CREATE SYNONYM  Emp
FOR HR.Employee;
----a. Select * from Employee
SELECT *
FROM Employee;
----b. Select * from [Human Resource].Employee
SELECT *
FROM HR.Employee;
----c. Select * from Emp
SELECT *
FROM Emp;
----d. Select * from [Human Resource].EmpSELECT *
FROM HR.Emp;--5. Increase the budget of the project where the manager number is 
--10102 by 10%.UPDATE Company.Project SET Budget = Budget *1.1FROM Company.34Project P join Works_on W ON P.ProjectNO = W.ProjectNOJOIN HR.Employee EON W.EmpNO = E.EmpNOWHERE E.EmpNO = 10102and W.Job = 'Manager';--6. Change the name of the department for which the employee named 
--James works.The new department name is Sales.
UPDATE Company.Department SET DeptName = 'Sales'FROM Company.Department D JOIN HR.Employee EON D.DeptNO = E.DeptNOWHERE E.EmpFname = 'James';--7. Change the enter date for the projects for those employees who 
--work in project p1 and belong to department ‘Sales’. The new date is 
--12.12.2007UPDATE Works_ON SET Enter_Date = '12/12/2007'FROM Works_ON W JOIN Company.Project PON W.ProjectNO = P.ProjectNOJOIN Emp EON W.EmpNO = E.EmpNOJOIN Company.Department DON D.DeptNO = E.DeptNOWHERE P.ProjectNO = 1AND D.DeptName = 'Sales';--8. Delete the information in the works_on table for all employees who 
--work for the department located in KW.DELETE WFROM Works_on W JOIN HR.Employee EON W.EmpNO = E.EmpNOJOIN Company.Department DON D.DeptNO = E.DeptNOWHERE D.Location = 'KW';--9. Try to Create Login Named(ITIStud) who can access Only student and 
--Course tablesfrom ITI DB then allow him to select and insert data into 
--tables and deny Delete and update .(Use ITI DB