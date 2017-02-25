select top 1 t.Name as [Town Name], count(e.FirstName) as [Number of Employees]
from Employees as e
inner join Addresses as a
on e.AddressID = a.AddressID
inner join Towns as t
on a.TownID = t.TownID
group by t.Name
order by [Number of Employees] desc