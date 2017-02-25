USE SoftUni
GO

SELECT 
    e.FirstName
    FROM Employees AS e
    WHERE  EXISTS (SELECT 
        1
        FROM  EmployeesProjects AS ep
        INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID
        WHERE (e.EmployeeID = ep.EmployeeID) AND (2002 = (DATEPART (year, p.StartDate)))
    )