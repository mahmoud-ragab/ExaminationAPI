create proc getInstructorListOfCourses
    (@ins_ID int)
as
select *
from Instructor I
    join
    InstructorCourse IC
    on I.Id = IC.Instructor_Id
    join
    Course C
    on C.Id = IC.Course_Id
return