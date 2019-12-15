create proc getInstructorExamListByCourse
    (@ins_ID int,@crs_ID int)
as
select *
from Exam E
    where E.Instructor_Id = @ins_ID and E.Course_Id = @crs_ID
return