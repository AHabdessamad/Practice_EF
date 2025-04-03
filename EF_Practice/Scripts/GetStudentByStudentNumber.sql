CREATE PROCEDURE GetStudentByStudentNumber
    @StudentNumber NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM Persons P
    WHERE P.StudentNumber = @StudentNumber AND P.PersonType = 'Student';
END
