create proc getAnswerSheetOfStudent
    (@stu_ID int,
    @exam_ID int)
as
select *
from StudentExam SE
    join
    AnswerSheet A
    on SE.Id = A.Student_Exam_Id and SE.Exam_Id = @exam_ID and SE.Student_Id = @stu_ID
    join
    Answer AA
    on A.Answer_Id = AA.Id
    join
    Question Q
    on Q.Id = A.Question_Id
return