select t.Name as Town, d.Name as Departmet, count(*) as [Employees Count]
from Employees as e
inner join Departments as d
on e.DepartmentID = d. DepartmentID
inner join Addresses as a
on e.AddressID = a. AddressID
inner join Towns as t
on a.TownID = t.TownID
group by t.Name, d.Name