USE ITI

/*
1. Create a scalar function that takes date and returns Month name of that 
date
*/

CREATE FUNCTION getMonthDate(@date DATE)
RETURNS INT
BEGIN
    DECLARE @monthDate INT = Month(@date)
    RETURN @monthDate
END;

SELECT dbo.getMonthDate(getdate());

/*
2. Create a multi-statements table-valued function that takes 2 integers 
and returns the values between them.
*/

CREATE FUNCTION getValues(@first int, @last int)
returns @t table(val int)
AS
BEGIN
   DECLARE @x int = @first
       WHILE @x < @last
	        BEGIN
			     SET @x += 1
				 INSERT INTO @t (val) VALUES (@x)
			END
	RETURN
END;

SELECT * FROM getValues(10, 20);

/*
3. Create inline function that takes Student No and returns Department 
Name with Student full name.
*/	 

CREATE FUNCTION getDepartmentName(@StudentNo INT)
RETURNS TABLE 
AS
RETURN
(
   SELECT S.St_Fname + '' + S.St_Lname AS[Full Name], D.Dept_Name
   FROM Department D JOIN Student S
   ON D.Dept_Id = S.Dept_Id
   WHERE S.St_Id = @StudentNo
)

SELECT * FROM getDepartmentName(1);

/*
  4. Create a scalar function that takes Student ID and returns a message to 
user 
*/
--a. If first name and Last name are null then display 'First name & 
--last name are null'
--b. If First name is null then display 'first name is null'
--c. If Last name is null then display 'last name is null'
--d. Else display 'First name & last name are not null'

CREATE FUNCTION CheckStudentName
(
    @StudentID INT
)
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @firstName NVARCHAR(20)
    DECLARE @lastName NVARCHAR(20)
    DECLARE @message NVARCHAR(20)

   SELECT @firstName = S.St_Fname, @lastName = S.St_Lname
   FROM Student S
   WHERE S.St_Id = @StudentID

    IF (@FirstName IS NULL AND @LastName IS NULL)
        SET @message = 'First name & last name are null'
    ELSE IF (@FirstName IS NULL)
        SET @message = 'First name is null'
    ELSE IF (@LastName IS NULL)
        SET @message = 'Last name is null'
    ELSE
        SET @message = 'First name & last name are not null'

    RETURN @message
END

SELECT dbo.CheckStudentName(14);

/*
  5. Create inline function that takes integer which represents manager ID 
  and displays department name, Manager Name and hiring date
*/

CREATE FUNCTION getManagerData(@managerId INT)
RETURNS TABLE
AS
RETURN
(
  SELECT D.Dept_Name, E.ename, E.hiredate
  FROM emp E JOIN Department D
  ON E.eid = D.Dept_Manager
  WHERE E.eid = @managerId
)

SELECT * FROM getManagerData(1);

/*
  6. Create multi-statements table-valued function that takes a string
  If string='first name' returns student first name
  If string='last name' returns student last name 
  If string='full name' returns Full Name from student table 
  Note: Use “ISNULL” function
*/

CREATE FUNCTION getStudentName(@string VARCHAR(20))
RETURNS @studentName TABLE(stName VARCHAR(20))
AS
BEGIN
    IF(@string = 'first name')
	 BEGIN
	   INSERT INTO @studentName
	   SELECT ISNULL(St_fname,'')
	   FROM Student
	END
    ELSE IF(@string = 'last name')
	   BEGIN
	      INSERT INTO @studentName
	       SELECT ISNULL(St_Lname, '')
	       FROM Student
	  END
	ELSE IF(@string = 'full name')
	   BEGIN
	       INSERT INTO @studentName
	       SELECT St_fname + ' '+ St_Lname AS [Full]
	       FROM Student
	  END
	RETURN
END

SELECT * FROM getStudentName('first name');
SELECT * FROM getStudentName('last name');
SELECT * FROM getStudentName('full name');

/*
   7. Write a query that returns the Student No and Student first name 
   without the last char
*/

SELECT St_Id,
       SUBSTRING(St_Fname, 1, LEN(St_Fname) - 1) AS St_Fname
FROM Student;

/*
  8. Write query to delete all grades for the students Located in SD 
  Departmen
*/

DELETE c
FROM Department d
    INNER JOIN Student s
        ON d.Dept_Id = s.Dept_Id
    INNER JOIN Stud_Course c
        ON s.St_Id = c.St_Id
WHERE d.Dept_Name = 'sd';

--BONUS 02
DECLARE @count INT = 3001;
WHILE (@count <= 6000)
    BEGIN
        INSERT INTO Student (St_Id, St_Fname, St_Lname)
        VALUES (@count, 'Jane', 'Smith')
        SET @count += 1;
    END

