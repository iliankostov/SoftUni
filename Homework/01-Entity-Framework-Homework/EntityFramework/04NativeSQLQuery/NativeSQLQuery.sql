USE SoftUni
GO

SELECT Count(*) 
FROM Employees AS e 
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE YEAR(p.StartDate) = '2002'