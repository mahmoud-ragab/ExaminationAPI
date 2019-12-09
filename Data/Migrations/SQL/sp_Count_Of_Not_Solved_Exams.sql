Create PROCEDURE [dbo].[sp_Count_Of_Not_Solved_Exams]

@id int
	 AS

 
select COUNT( e.Id) as ct
 
from exam e

inner join Course c
on e.Course_Id=c.Id 

inner join StudentCourse sc
on c.Id =sc.Course_Id  

 
inner join Student s 
on s.Id = sc.Student_Id and s.Id =@id


where  e.Id   not in (select Exam_Id from StudentExam)

RETURN 0
