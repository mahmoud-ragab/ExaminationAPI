ALTER PROC genreateExam @courseID INT, @numberOfMcq INT, @numberOfTrue_False INT
AS
BEGIN
	DECLARE @numberOfMCQExist INT , @numberOfTrue_FalseExist int;
	IF(@numberOfMcq + @numberOfTrue_False = 10)
		BEGIN
			INSERT INTO Exam(Course_Id) values(@courseID)
			declare @examID int = @@identity

			SELECT @numberOfMCQExist = COUNT(*) 
			FROM
			(SELECT  TOP(@numberOfMcq) Question.Id FROM Question where Question.questionType = 'MCQ' AND Question.Exam_Id IS NULL ORDER BY newid()) x
			IF( @numberOfMCQExist >= @numberOfMcq)
				BEGIN
					UPDATE Question 
					SET Exam_Id = @examID 
					WHERE Question.Id 
					IN (SELECT  TOP(@numberOfMcq) Question.Id FROM Question where Question.questionType = 'MCQ' AND Question.Exam_Id IS NULL ORDER BY newid())
				END
	
			SELECT @numberOfTrue_FalseExist = COUNT(*) 
			FROM
			(SELECT  TOP(@numberOfTrue_False) Question.Id FROM Question where Question.questionType = 'TRUE_FALSE' AND Question.Exam_Id IS NULL ORDER BY newid()) x
			IF( @numberOfTrue_FalseExist >= @numberOfTrue_False)
				BEGIN
					UPDATE Question
					SET Exam_Id = @examID 
					WHERE Question.Id 
					IN (SELECT  TOP(@numberOfTrue_False) Question.Id FROM Question where Question.questionType = 'TRUE_FALSE' AND Question.Exam_Id IS NULL ORDER BY newid())
				END
		END	
END

EXEC dbo.genreateExam 1,6,4
