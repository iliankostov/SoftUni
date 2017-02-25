select e.FirstName as Employee, m.FirstName as Manager
from Employees as e
left outer join Employees as m
on e.ManagerID=m.EmployeeID