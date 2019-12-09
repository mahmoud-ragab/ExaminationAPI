CREATE PROCEDURE[dbo].[sp_Not_sloved_exams]

@id int
     AS
select e.Id as ExamID,
i.Name as Instructor ,
t.Name as Topic,
c.Name as Course


from exam e

inner join Course c
on e.Course_Id= c.Id

inner join StudentCourse sc
on c.Id = sc.Course_Id

inner join topic t
on t.Id = c.Topic_Id

inner join InstructorCourse ic
on ic.Course_Id = c.Id

inner join Instructor i
on i.Id = ic.Instructor_Id


inner join Student s
on s.Id = sc.Student_Id and s.Id = @id


where e.Id not in (select Exam_Id from StudentExam)




RETURN 0