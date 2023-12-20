Use [ITI.bak]

--1. Retrieve number of students who have a value in their age
Select count(St_age) from student;

--2. Get all instructors Names without repetition
Select distinct Ins_name from Instructor;

--3. Display student with the following Format (use isNull function)Select S.St_Id As [Student ID] , concat(isnull(S.St_Fname,''),' ',isnull(S.St_Lname,'')) As [Student Fullname],D.Dept_Name As [Department Name]from Student S join Department Don S.Dept_Id = D.Dept_Id--4. Display instructor Name and Department Name 
--Note: display all the instructors if they are attached to a department or not
Select I.Ins_Name ,D.Dept_Name
from Instructor I left outer join Department D
on I.Dept_Id = D.Dept_Id

--5. Display student full name and the name of the course he is taking
--For only courses which have a grade
Select 
concat(isnull(S.St_Fname,''),' ',isnull(S.St_Lname,'')) As [Student Fullname] , 
C.Crs_Name As [Course Name]
from Student S join Stud_Course SC
on S.St_Id = SC.St_Id
join Course C
on C.Crs_Id = SC.Crs_Id
where SC.Grade is not null;

--6. Display number of courses for each topic name
SELECT  T.Top_Name, COUNT(C.Top_Id)
FROM Topic T join Course C
ON T.Top_Id = C.Top_Id
GROUP BY T.Top_Name ;





















