create proc getInstructorAnswerSheetOfExam
    (@exam_ID int)
as
select *
from AnswerSheet A
join StudentExam SE
on SE.Exam_Id = @exam_ID and A.Student_Exam_Id = SE.Id
return