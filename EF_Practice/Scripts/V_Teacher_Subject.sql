CREATE VIEW V_Teacher_Subject AS
SELECT 

    P.Id AS TeacherId,
    P.FirstName,
    P.LastName,
    P.HireDate,

    s.Id AS SubjectId,
    s.Name AS SubjectName,
    s.Description AS SubjectDescription

FROM Persons P
JOIN Subjects s ON t.SubjectId = s.Id;


