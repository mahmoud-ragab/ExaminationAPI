ALTER PROC genreateExam @courseID INT, @numberOfMcq INT, @numberOfTrue_False INT, @instructorID INT
AS
BEGIN
	DECLARE @numberOfMCQExist INT , @numberOfTrue_FalseExist int;
	IF(@numberOfMcq + @numberOfTrue_False = 10)
		BEGIN

			SELECT @numberOfMCQExist = COUNT(*) 
			FROM
			(SELECT  TOP(@numberOfMcq) Question.Id FROM Question where Question.questionType = 'MCQ' AND Question.Exam_Id IS NULL ORDER BY newid()) x
	
			SELECT @numberOfTrue_FalseExist = COUNT(*) 
			FROM
			(SELECT  TOP(@numberOfTrue_False) Question.Id FROM Question where Question.questionType = 'TRUE_FALSE' AND Question.Exam_Id IS NULL ORDER BY newid()) x
			
			IF( @numberOfTrue_FalseExist >= @numberOfTrue_False AND @numberOfMCQExist >= @numberOfMcq)
				BEGIN				
					INSERT INTO Exam(Course_Id,Instructor_Id) values(@courseID , @instructorID)
					declare @examID int = @@identity
					UPDATE Question 
					SET Exam_Id = @examID 
					WHERE Question.Id 
					IN (SELECT  TOP(@numberOfMcq) Question.Id FROM Question where Question.questionType = 'MCQ' AND Question.Exam_Id IS NULL ORDER BY newid())

					UPDATE Question
					SET Exam_Id = @examID 
					WHERE Question.Id 
					IN (SELECT  TOP(@numberOfTrue_False) Question.Id FROM Question where Question.questionType = 'TRUE_FALSE' AND Question.Exam_Id IS NULL ORDER BY newid())
				
					SELECT * FROM Question WHERE Question.Exam_Id = @examID

				END
		END	
END

--EXEC dbo.genreateExam 1,6,4 ,1
