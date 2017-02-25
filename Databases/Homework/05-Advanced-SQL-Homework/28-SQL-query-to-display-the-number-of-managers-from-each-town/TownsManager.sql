select t.Name as [Town Name], count(m.FirstName) as [Number of Managers]
from Employees as e
inner join Employees as m
on m.EmployeeID = e.ManagerID
inner join Addresses as a
on e.AddressID = a.AddressID
inner join Towns as t
on a.TownID = t.TownID
group by t.Name