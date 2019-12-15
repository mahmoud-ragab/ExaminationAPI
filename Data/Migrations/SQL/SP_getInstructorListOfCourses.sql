create proc getInstructorListOfCourses
    (@ins_ID int)
as
select *
from Course C
    join
    InstructorCourse IC
    on IC.Instructor_Id = @ins_ID  and C.Id = IC.Course_Id
return