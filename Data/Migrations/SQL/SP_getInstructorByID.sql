create proc getInstructorByID
    (@ins_ID int)
as
select *
from Instructor I
where I.Id = @ins_ID
return