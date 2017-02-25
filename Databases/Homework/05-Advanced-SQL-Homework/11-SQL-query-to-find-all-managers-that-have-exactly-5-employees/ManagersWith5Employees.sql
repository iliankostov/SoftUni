select m.FirstName as [Manager First Name], m.LastName as [Manager Last Name], count(e.ManagerId) as [Employees Count]
from Employees as m
inner join Employees as e
on m.EmployeeID = e.ManagerID
group by m.FirstName, m.LastName
having count(e.ManagerId) = 5