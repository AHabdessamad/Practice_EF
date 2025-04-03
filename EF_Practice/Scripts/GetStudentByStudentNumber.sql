CREATE PROCEDURE GetStudentByStudentNumber
    @StudentNumber NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM Students
    WHERE StudentNumber = @StudentNumber;
END
