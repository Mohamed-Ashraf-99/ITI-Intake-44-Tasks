USE Company_SD;

/*
1. Create a cursor for Employee table that increases Employee 
salary by 10% if Salary <3000 and increases it by 20% if 
Salary >=3000. Use company DB
*/

DECLARE c1 CURSOR
FOR SELECT E.Salary
    FROM Employee E

DECLARE @salary INT
OPEN c1
FETCH c1 INTO @salary
WHILE @@FETCH_STATUS = 0
    BEGIN
	   IF @salary >= 3000
	      UPDATE Employee
	      SET Salary = @salary * 1.2
	      WHERE CURRENT OF c1
	   ELSE
	      UPDATE Employee
	      SET Salary = @salary * 1.1
	      WHERE CURRENT OF c1 
FETCH c1 INTO @salary
	END
CLOSE c1
DEALLOCATE c1;


/*
2. Display Department name with its manager name using 
cursor. Use ITI DB
*/

USE ITI;

DECLARE c1 CURSOR
FOR SELECT D.Dept_Name, D.Dept_Manager
    FROM Department D
FOR READ ONLY

DECLARE @Department_Name VARCHAR(20), @Department_Manager VARCHAR(20)
OPEN c1
FETCH NEXT FROM c1 INTO @Department_Name, @Department_Manager
WHILE @@FETCH_STATUS = 0
     BEGIN
	    SELECT @Department_Name AS [Department Name], @Department_Manager [Manager Name]
		FETCH NEXT FROM c1 INTO @Department_Name, @Department_Manager
	 END
CLOSE c1
DEALLOCATE c1;

/*
3. Try to display all students first name in one cell separated 
by comma. Using Cursor
*/

USE ITI;

DECLARE c1 CURSOR
FOR SELECT S.St_Fname
    FROM Student S
	WHERE S.St_Fname IS NOT NULL
FOR READ ONLY

DECLARE @name VARCHAR(20), @all_Names VARCHAR(300)
OPEN c1
FETCH NEXT FROM c1 INTO @name
WHILE @@FETCH_STATUS = 0
      BEGIN
	     SELECT @all_Names = CONCAT(@all_Names, @name, ', ')
		 FETCH NEXT FROM c1 INTO @name
	  END
SELECT @all_Names
CLOSE c1
DEALLOCATE c1;

/*
4. Create full, differential Backup for SD DB.
*/

USE SD;

INSERT INTO HR.Employee
VALUES(4595, 'Mohamed', 'Ashraf', 1, 30000),
      (4596, 'Ahmed', 'Mohamed', 1, 30000),
	  (4597, 'Mohamed', 'Ahmed', 1, 30000),
	  (4598, 'Ahmed', 'Ashraf', 1, 30000);

--Auto Backup
BACKUP DATABASE ITI TO DISK = 'D:\1-Programming\2-ITI-Intake-44\10-ADV-DB\Day10\Auto-Backup\ITI.bak'

/*
5. Use import export wizard to display students data (ITI DB) 
in excel sheet
*/

/*
6. Try to generate script from DB ITI that describes all tables 
and views in this DB
*/

/*
7. Create a sequence object that allow values from 1 to 10 
without cycling in a specific column and test it.
*/

--CREATE SEQUENCE OBJECT
CREATE SEQUENCE LimitedSequence
    AS INT
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 10
    NO CYCLE;

--Temp Table
CREATE TABLE temp
(
  ID INT ,
  FullNAME VARCHAR(20)
);

INSERT INTO temp
VALUES(1, 'Ashraf');

INSERT INTO temp
VALUES(NEXT VALUE FOR LimitedSequence, 'Ashraf');

DROP SEQUENCE LimitedSequence;