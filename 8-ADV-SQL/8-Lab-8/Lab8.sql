USE ITI

/*
1. Create a view that displays student full name, course name if the 
student has a grade more than 50.
*/

CREATE VIEW studView
AS
SELECT S.St_Fname + ' ' + S.St_Lname AS [Student Name], C.Crs_Name
FROM Student S JOIN Stud_Course SC
ON S.St_Id = SC.St_Id
JOIN Course C
ON SC.Crs_Id = C.Crs_Id
WHERE SC.Grade > 50;

SELECT *
FROM studView;

/*
  2. Create an Encrypted view that displays manager names and the topics 
  they teach.
*/

CREATE VIEW ManagerNameTopicsView
WITH ENCRYPTION
AS
SELECT I.Ins_Name, C.Crs_Name
FROM Instructor I JOIN Ins_Course IC
ON I.Ins_Id = IC.Ins_Id
JOIN Course C
ON IC.Crs_Id = C.Crs_Id;

SELECT *
FROM ManagerNameTopicsView;

sp_helptext 'ManagerNameTopicsView';

/*
3. Create a view that will display Instructor Name, Department Name for 
the ‘SD’ or ‘Java’ Department
*/

CREATE VIEW InstructorView
AS
SELECT I.Ins_Name, D.Dept_Name
FROM Instructor I JOIN Department D
ON I.Dept_Id = D.Dept_Id
WHERE D.Dept_Name IN('SD','Java');

SELECT *
FROM InstructorView
/*
4. Create a view “V1” that displays student data for student who lives in 
Alex or Cairo. 
Note: Prevent the users to run the following query 
Update V1 set st_address=’tanta’
Where st_address=’alex’
*/

CREATE VIEW V1
AS
SELECT *
FROM Student S
WHERE S.St_Address IN ('Alex', 'Cairo') 
WITH CHECK OPTION;

Update V1 set st_address='tanta'
Where st_address='alex';

/*
5. Create a view that will display the project name and the number of 
employees work on it. “Use SD database”
*/

/*
6. Create index on column (Hiredate) that allow u to cluster the data in 
table Department. What will happen?
*/

CREATE CLUSTERED INDEX IX_Department
ON Department(Dept_Name);

/*
7. Create index that allow u to enter unique ages in student table. What will 
happen?
*/

CREATE UNIQUE INDEX UIX_Student
ON Student(St_Age);

/*
8. Using Merge statement between the following two tables [User ID, 
Transaction Amount]
*/

CREATE TABLE LastTransactions
(
  userID int,
  transActionsAmount int
);

INSERT INTO LastTransactions
VALUES(1, 1000),(2, 2000), (3, 1000);

CREATE TABLE DailyTransactions
(
  userID int,
  transActionsAmount int
);


INSERT INTO DailyTransactions
VALUES(1, 4000),(4, 2000), (2, 10000);

MERGE INTO LastTransactions 
AS T
USING DailyTransactions 
AS S
ON T.userID = S.userID
WHEN MATCHED THEN
UPDATE
SET T.transActionsAmount 
= S.transActionsAmount
WHEN NOT MATCHED THEN
INSERT 
VALUES(S.userID, S.transActionsAmount);

-----------------------------------------------------
--PART TWO
USE SD

/*
1) Create view named “v_clerk” that will display employee#,project#, the date of hiring of 
all the jobs of the type 'Clerk'.
*/

CREATE VIEW v_clerk
AS
SELECT E.EmpNO, W.ProjectNo, W.Enter_Date
FROM HR.Employee E JOIN Works_on W
ON E.EmpNO = W.EmpNo
WHERE W.Job = 'Clerk';

/*
2) Create view named “v_without_budget” that will display all the projects data 
without budget
*/

CREATE VIEW v_without_budget
AS
SELECT *
FROM Company.Project P
WHERE P.Budget = NULL;

/*
3) Create view named “v_count “ that will display the project name and the # of jobs in it
*/

CREATE VIEW v_count
AS
SELECT P.ProjectName , COUNT(W.Job) AS [job_count]
FROM Company.Project P JOIN Works_on W
ON P.ProjectNO = W.ProjectNo
GROUP BY P.ProjectName, W.Job;

SELECT *
FROM v_count;

/*
4) Create view named ” v_project_p2” that will display the emp# for the project# ‘p2’
use the previously created view “v_clerk”
*/

CREATE VIEW v_project_p2
AS
SELECT vc.EmpNO
FROM v_clerk vc
WHERE vc.ProjectNo = 2;

SELECT *
FROM v_project_p2;

/*
5) modifey the view named “v_without_budget” to display all DATA in project p1 and p2 
*/

ALTER VIEW v_without_budget
AS
SELECT * 
FROM Company.Project P
WHERE P.ProjectNO IN(1, 2);

SELECT *
FROM v_without_budget;

/*
6) Delete the views “v_ clerk” and “v_count”
*/
DROP VIEW v_clerk;
DROP VIEW v_count;

/*
7) Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
*/

CREATE VIEW EmpView
AS
SELECT E.EmpNO, E.EmpLname
FROM HR.Employee E
WHERE E.DeptNO = 2;

SELECT *
FROM EmpView

/*
8) Display the employee lastname that contains letter “J”
Use the previous view created in Q#7
*/

SELECT E.EmpLname
FROM EmpView E
WHERE E.EmpLname LIKE '%J%';

/*
9) Create view named “v_dept” that will display the department# and department name.
*/

CREATE VIEW v_dept
AS
SELECT D.DeptNO, D.DeptName
FROM Company.Department D;

SELECT *
FROM v_dept;

/*
10) using the previous view try enter new department data where dept# is ’d4’ and dept name 
is ‘Development’
*/

INSERT INTO v_dept
VALUES(4, 'Development');

/*
11)Create view name “v_2006_check” that will display employee#, the project #where he 
works and the date of joining the project which must be from the first of January and the 
last of December 2006
*/

CREATE VIEW v_2006_check
AS
SELECT W.EmpNO, W.ProjectNO
FROM  Works_on W
WHERE W.Enter_Date BETWEEN '01-01-2006' AND '12-31-2006';

SELECT *
FROM v_2006_check;