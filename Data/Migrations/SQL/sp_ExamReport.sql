CREATE PROCEDURE[dbo].[sp_ExamReport]

@ExamID int,
@StudentID int
     AS

 select q.Id as QuestionID, q.Content as Question, q.Exam_Id, q.CorrectAnswer as CorrectAnswerID,
 ans.Content as CorrectAnswer, a.Answer_Id as StudentAnswerID,
 (select ans.Content from Answer ans where a.Answer_Id = ans.Id) as StudentAnswer,
 IIF(q.CorrectAnswer = a.Answer_Id, 'Correct', 'Incorrect') as Result,
 s.Name as studentName,s.Address as studentAddress, c.Name as CourseName, i.Name as InstructorName, t.Name as  TopicName


from Question q

inner join AnswerSheet a
on a.Question_Id = q.Id

inner join StudentExam se
on se.Id = a.Student_Exam_Id
and se.Exam_Id = @ExamID and se.Student_Id = @StudentID

inner join Answer ans
on ans.id = q.CorrectAnswer

 inner join Student s
 on s.Id = se.Student_Id

 inner join Exam e
 on e.Id = se.Exam_Id

 inner join Course c
 on c.Id = e.Course_Id

inner join InstructorCourse ic
on ic.Course_Id = e.Course_Id

inner join Instructor i
on i.Id = ic.Instructor_Id

inner join topic t
on t.Id = c.Topic_Id



RETURN 0
