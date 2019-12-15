create PROC genreateExam @courseID INT, @numberOfMcq INT, @numberOfTrue_False INT, @instructorID INT
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
					SET Exam_Id = @examID,
					CoursedId = @courseID
					WHERE Question.Id 
					IN (SELECT  TOP(@numberOfMcq) Question.Id FROM Question where Question.questionType = 'MCQ' AND Question.Exam_Id IS NULL AND Question.CoursedId = @courseID ORDER BY newid())

					UPDATE Question
					SET Exam_Id = @examID,
					CoursedId = @courseID
					WHERE Question.Id 
					IN (SELECT  TOP(@numberOfTrue_False) Question.Id FROM Question where Question.questionType = 'TRUE_FALSE' AND Question.Exam_Id IS NULL AND Question.CoursedId = @courseID ORDER BY newid())
				
					SELECT * FROM Question WHERE Question.Exam_Id = @examID

				END
			ELSE
				BEGIN
					SELECT -1 AS 'Id' , 'N/A' AS 'Content' , -1 AS 'CorrectAnswer' , 'N/A' AS 'questionType' , -1 AS 'CoursedId' , -1 AS 'Exam_Id'
				END
		
		END	
END

EXEC dbo.genreateExam 1,6,4 ,1
