select d.Name as Department, avg(e.Salary) as AverageSalary
from Departments as d
inner join Employees as e
on e.DepartmentID = d.DepartmentID
group by d.Name