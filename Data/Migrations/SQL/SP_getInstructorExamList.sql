create proc getInstructorExamList
    (@ins_ID int)
as
select *
from Exam E
    join
    StudentExam SE
    on E.Id = SE.Exam_Id and E.Instructor_Id = @ins_ID
    join
    Student S
    on SE.Student_Id = S.Id
return