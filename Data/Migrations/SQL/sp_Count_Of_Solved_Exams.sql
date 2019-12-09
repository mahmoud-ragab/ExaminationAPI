CREATE PROCEDURE[dbo].[sp_Count_Of_Solved_Exams]

@id int
     AS



 select distinct COUNT(s.Id) as SlovedCount from StudentExam s
where s.Id in (select Student_Exam_Id from AnswerSheet )
and s.Student_Id =@id

RETURN 0