select avg(Salary)
from Employees as e
inner join Departments as d
on e.DepartmentID=d.DepartmentID
where d.DepartmentID = 1