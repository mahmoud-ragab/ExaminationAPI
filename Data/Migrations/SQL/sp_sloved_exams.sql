CREATE PROCEDURE[dbo].[sp_sloved_exams]

@id int
     AS

select top(15) e.Id as ExamID,
i.Name as Instructor,
t.Name as Topic ,
c.Name as Course   ,

(select CONCAT(COUNT(q.Id) , ' / 10' )
from Question q
inner join AnswerSheet a
on a.question_id = q.id and q.exam_id =e.Id
and a.Answer_Id = q.CorrectAnswer

inner join StudentExam se
on se.Id = a.Student_Exam_Id and se.Student_Id=@id
) as Degree

from Exam e


inner join Course c
on e.Course_Id = c.Id

inner join topic t
on t.Id = c.Topic_Id

 

inner join Instructor i
on i.Id = e.Instructor_Id

inner join StudentCourse sc
on sc.Course_Id = e.Course_Id

inner join Student s
on s.Id = sc.Student_Id and s.id = @id


where e.Id in (
select se.Exam_Id from StudentExam se
inner join AnswerSheet a
on a.Student_Exam_Id = se.id
and se.Student_Id = @id
)

order by e.Id desc


RETURN 0
