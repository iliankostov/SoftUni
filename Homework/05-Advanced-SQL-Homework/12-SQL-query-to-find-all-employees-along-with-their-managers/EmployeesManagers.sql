select e.FirstName + ' ' + e.LastName as Employee, isnull(m.FirstName + ' ' + m.LastName, '(no manager)') as Manager
from Employees as e
left outer join Employees as m
on e.ManagerID = m.EmployeeID