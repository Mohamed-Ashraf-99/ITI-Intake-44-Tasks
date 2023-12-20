-- 1.	Retrieve number of students who have a value in their age. 
SELECT COUNT(St_Age) FROM Student;

-- 2.	Get all instructors Names without repetition
SELECT DISTINCT Ins_Name FROM Instructor;

-- 3.	Display student with the following Format (use isNull function)
--		#Student ID	  #Student Full Name	#Department name
SELECT 
	S.St_Id [Student ID],
	CONCAT(ISNULL(S.St_Fname,''),' ',ISNULL(S.St_Lname,'')) [Student Full Name],
	D.Dept_Name [Department name]
from Student S join Department D
on S.Dept_Id = D.Dept_Id;

-- 4.	Display instructor Name and Department Name 
-- Note: display all the instructors if they are attached to a department or not
SELECT 
	I.Ins_Name [Instructor Name],
	D.Dept_Name [Department Name ]
FROM Instructor I left outer join Department D
ON I.Dept_Id = D.Dept_Id;

-- 5.	Display student full name and the name of the course he is taking
---		For only courses which have a grade  
SELECT 
	CONCAT(ISNULL(S.St_Fname,''),' ',ISNULL(S.St_Lname,'')) [Student Full Name], 
	C.Crs_Name [Courses Name] 
FROM Student S join Stud_Course SC
ON S.St_Id = SC.St_Id
join Course C
on C.Crs_Id = SC.Crs_Id
WHERE SC.Grade is not NULL;

-- 6.	Display number of courses for each topic name
SELECT  T.Top_Name, COUNT(C.Top_Id)
FROM Topic T join Course C
ON T.Top_Id = C.Top_Id
GROUP BY T.Top_Name ;

-- 7.	Display max and min salary for instructors
SELECT 
	MAX(ISNULL(I.Salary, 0)) [Max Salary],
	MIN(ISNULL(I.Salary, 0)) [Min Salary]
FROM Instructor I ;

-- 8.	Display instructors who have salaries less than the average salary of all instructors.
SELECT *
FROM Instructor I
WHERE I.Salary < (SELECT AVG(Salary) FROM Instructor);

-- 9.	Display the Department name that contains the instructor who receives the minimum salary.
SELECT D.Dept_Name
FROM Instructor I join Department D
ON I.Dept_Id = D.Dept_Id
WHERE I.Salary = (SELECT MIN(Salary) FROM Instructor);

-- 10.	 Select max two salaries in instructor table. 
SELECT TOP(2) I.Salary
FROM Instructor I
ORDER BY I.Salary DESC

-- 11.	 Select instructor name and his salary but if there is no salary display
--		 instructor bonus keyword. “use coalesce Function”
SELECT 
	I.Ins_Name [Instructor Name],
	coalesce( CONVERT(VARCHAR(50), I.Salary), 'bonus') [Instructor Name Salary]
FROM Instructor I

-- 12.	Select Average Salary for instructors 
SELECT AVG(isnull(Salary,0)) FROM Instructor;

-- 13.	Select Student first name and the data of his supervisor 
SELECT X.St_Fname [Student First Name], Y.*
FROM Student X join Student Y
on  X.St_super = y.St_Id ;

-- 14.	Write a query to select the highest two salaries in Each Department
--		for instructors who have salaries. “using one of Ranking Functions”
Select Salary, newtable.Dept_Id
from (
		select * ,Dense_rank() over(PARTITION by Dept_Id order by Salary desc) as S	from Instructor
	) as newtable
where S<=2


-- 15.	 Write a query to select a random  student from each department.  “using one of Ranking Functions”


Select *from (
	select * ,Dense_rank() over(PARTITION by Dept_Id  order by newid() ) as DN from Student
	 ) as newtable WHERE DN = 1





