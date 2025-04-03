CREATE VIEW V_Teacher_Subject AS
SELECT 

    t.Id AS TeacherId,
    t.FirstName,
    t.LastName,
    t.HireDate,

    s.Id AS SubjectId,
    s.Name AS SubjectName,
    s.Description AS SubjectDescription

FROM Persons t
JOIN Subjects s ON t.SubjectId = s.Id;


