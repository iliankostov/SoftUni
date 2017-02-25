select e.FirstName as Employee, d.Name as Department, e.HireDate
from Employees as e
inner join Departments as d
on d.DepartmentID=e.DepartmentID
where d.Name in ('Sales', 'Finance')
and e.HireDate between convert(datetime, '1995') and convert(datetime, '2005')