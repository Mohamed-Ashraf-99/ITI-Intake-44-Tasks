USE ITI
/*
1. Create a stored procedure without parameters to show the number of 
students per department name.[use ITI DB] 
*/

CREATE PROC numOfStudentPerDepartment
WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
	     SELECT S.Dept_Id, COUNT(*)
		 FROM Student S
		 GROUP BY S.Dept_Id
	END TRY
	BEGIN CATCH
	    SELECT 'invalid query'
	END CATCH
END

EXECUTE numOfStudentPerDepartment;

/*
2. Create a stored procedure that will check for the # of employees in the 
project p1 if they are more than 3 print message to the user “'The number 
of employees in the project p1 is 3 or more'” if they are less display a 
message to the user “'The following employees work for the project p1'” in 
addition to the first name and last name of each one. [Company DB]
*/

USE Company_SD;

ALTER PROC checkNumOfEmployee
WITH ENCRYPTION
AS
BEGIN
   SET NOCOUNT ON;

   DECLARE @numOfEmp INT
   SELECT @numOfEmp = COUNT (ESSn)
   FROM Works_for 
   WHERE Pno = 100;

   IF @numOfEmp > 3
      BEGIN
         PRINT 'The number of employees in the project p1 is 3 or more'
	  END
   ELSE
      BEGIN
	     SELECT 'The following employees work for the project p1',E.Fname, E.Lname
	     FROM Employee E JOIN Works_for W
         ON E.SSN = W.ESSn
         WHERE W.Pno = 100;
	  END
END

EXECUTE checkNumOfEmployee;

/*
3. Create a stored procedure that will be used in case there is an old 
   employee has left the project and a new one become instead of him. The 
   procedure should take 3 parameters (old Emp. number, new Emp. number 
   and the project number) and it will be used to update works_on table. 
   [Company DB]
*/

CREATE PROC updateWorksFor @oldEmp INT, @newEmp INT, @projectNum INT
WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON;

	BEGIN TRY
	     UPDATE Works_for 
	     SET ESSn = @newEmp
	     WHERE ESSn = @oldEmp
	     AND Pno = @projectNum;
	END TRY
	BEGIN CATCH
	    PRINT 'Can not upadte';
	END CATCH
END

EXECUtE updateWorksFor 112233, 4595, 40;


/*
4-add column budget in project table and insert any draft values in it then 
then Create an Audit table with the following structure 
ProjectNo UserName ModifiedDate Budget_Old Budget_New 
p2 Dbo 2008-01-31 95000 200000 
This table will be used to audit the update trials on the Budget column 
(Project table, Company DB)
Example:
If a user updated the budget column then the project number, user name 
that made that update, the date of the modification and the value of the 
old and the new budget will be inserted into the Audit table
Note: This process will take place only if the user updated the budget 
column
*/

CREATE TABLE audit_table
(
    project_no    CHAR(2),
    user_name     VARCHAR(20),
    modified_date DATE,
    budget_old    MONEY,
    budget_new    MONEY
)

CREATE TRIGGER tr_project_forUpdateBudget
    ON Project
    FOR UPDATE
    AS
    IF (UPDATE(budget))
        BEGIN
            DECLARE @project_no CHAR(2), @old_budget MONEY, @new_budget MONEY
            SELECT @project_no = project_no, @new_budget = budget 
			FROM inserted
            SELECT @old_budget = budget 
			FROM deleted

            INSERT INTO audit_table (project_no, user_name, modified_date, budget_old, budget_new)
            VALUES (@project_no, SUSER_NAME(), GETDATE(), @old_budget, @new_budget)
        END

GO

--TEST CASE
UPDATE company.Project
SET budget = 160000
WHERE project_no = 'p2'

UPDATE company.Project
SET project_name = 'BMW'
WHERE project_no = 'p2'

/*
5. Create a trigger to prevent anyone from inserting a new record in the 
Department table [ITI DB]
“Print a message for user to tell him that he can’t insert a new record in 
that table”
*/
CREATE TRIGGER tr_department_insteadOfInsert
    ON Department
    INSTEAD OF INSERT
    AS
    PRINT 'You can''t insert a new record in that table'

GO

--TEST CASE
INSERT INTO Department (Dept_Id, Dept_Name, Dept_Desc, Dept_Location)
VALUES (100, 'Testing', 'Testing', 'Cairo')


/*
6. Create a trigger that prevents the insertion Process for Employee table in 
March [Company DB].
*/
CREATE TRIGGER tr_employee_insteadOfInsert
    ON Employee
    INSTEAD OF INSERT
    AS
    IF (FORMAT(GETDATE(), 'MMMM') = 'March')
        BEGIN
            PRINT N'You can''t insert any row in the employees table during March...'
        END
    ELSE
        BEGIN
            INSERT INTO Employee
            SELECT *
            FROM inserted
        END

GO

--TEST CASE
INSERT INTO hr.Employee (emp_no, emp_fname, emp_lname, dept_no, salary)
VALUES (10152, 'Islam', 'Gamal', 'd1', 20000)


/*
7. Create a trigger on student table after insert to add Row in Student Audit 
table (Server User Name , Date, Note) where note will be “[username] 
Insert New Row with Key=[Key Value] in table [table name]”
*/
CREATE TABLE std_audit_table
(
    user_name VARCHAR(100),
    date      DATE,
    note      VARCHAR(200)
)


CREATE TRIGGER tr_student_forInsert
    ON Student
    FOR INSERT
    AS
    DECLARE @user_name VARCHAR(100), @st_id INT
    SET @user_name = SUSER_NAME()
    SELECT @st_id = St_Id
    FROM inserted
    INSERT INTO std_audit_table (user_name, date, note)
    VALUES (@user_name, GETDATE(),
            @user_name + ' has been inserted a new row with key = ' + CAST(@st_id AS VARCHAR) + ' in table Student')

GO

--TEST CASE
INSERT INTO Student (St_Id, St_Fname, St_Lname)
VALUES (25, 'Islam', 'Gamal')


/*
8. Create a trigger on student table instead of delete to add Row in Student
Audit table (Server User Name, Date, Note) where note will be“ try to 
delete Row with Key=[Key Value]”
*/
CREATE TRIGGER tr_student_insteadOfDelete
    ON Student
    INSTEAD OF DELETE
    AS
    DECLARE @user_name VARCHAR(100), @st_id INT
    SET @user_name = SUSER_NAME()
    SELECT @st_id = St_Id
    FROM deleted
    INSERT INTO std_audit_table (user_name, date, note)
    VALUES (@user_name, GETDATE(),
            'Try to delete row with key = ' + CAST(@st_id AS VARCHAR))

GO

--TEST CASE
DELETE
FROM Student
WHERE St_Id = 25


/*
9. Display all the data from the Employee table (HumanResources Schema) 
As an XML document “Use XML Raw”. “Use Adventure works DB” 
A) Elements
B) Attributes
*/
SELECT *
FROM HumanResources.Employee
FOR XML RAW, ELEMENTS

SELECT *
FROM HumanResources.Employee
FOR XML RAW


/*
10. Display Each Department Name with its instructors. “Use ITI DB”
A) Use XML Auto
B) Use XML Path
*/
SELECT d.Dept_Name,
       i.Ins_Id,
       i.Ins_Name
FROM Instructor i
    INNER JOIN dbo.Department d
        ON d.Dept_Id = i.Dept_Id
FOR XML AUTO, ELEMENTS


SELECT d.Dept_Name,
       i.Ins_Id   "Dept_Name/Ins_Id",
       i.Ins_Name "Dept_Name/Ins_Name"
FROM Instructor i
    INNER JOIN dbo.Department d
        ON d.Dept_Id = i.Dept_Id
FOR XML PATH


/*
11. Use the following variable to create a new table “customers” inside the company DB.
Use OpenXML
*/
DECLARE @docs XML ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'

DECLARE @hdocs INT
EXEC sp_xml_preparedocument @hdocs OUT, @docs

SELECT *
INTO customer
FROM OPENXML(@hdocs, '//customer')
             WITH (
                 fname VARCHAR(20) '@FirstName',
                 zip_code VARCHAR(20) '@Zipcode',
                 order_item VARCHAR(30) 'order',
                 order_id INT 'order/@ID'
                 )

EXEC sp_xml_removedocument @hdocs
