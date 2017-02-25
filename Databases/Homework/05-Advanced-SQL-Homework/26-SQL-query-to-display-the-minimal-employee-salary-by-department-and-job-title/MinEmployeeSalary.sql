select d.Name as Department, e.JobTitle as [Job Title], e.FirstName as [First Name], min(e.Salary) as [Min Salary]
from Employees as e
inner join Departments as d
on e.DepartmentID = d.DepartmentID
group by e.JobTitle, d.Name, e.FirstName
