select Count(*) as SalesEmployeesCount
from Employees as e
inner join Departments as d
on e.DepartmentID=d.DepartmentID
where d.Name = 'Sales'