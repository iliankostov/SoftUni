select d.Name as Department, e.JobTitle as [Job Title], avg(e.Salary) as [Average Salary]
from Employees as e
inner join Departments as d
on e.DepartmentID = d.DepartmentID
group by e.JobTitle, d.Name