USE SoftUni
GO

-- Create proc
CREATE PROC FindAllProjectsForGivenEmployee
(
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
)
AS
BEGIN
SELECT p.Name, p.Description, p.StartDate
FROM Projects AS p
JOIN EmployeesProjects AS ep ON p.ProjectID = ep.ProjectID
JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
WHERE e.FirstName = @FirstName AND e.LastName = @LastName
END
GO

-- Try proc
EXEC FindAllProjectsForGivenEmployee 'Ruth', 'Ellerbrock' 