select e.FirstName as Employee,et.Name as EmployeeTown, ea.AddressText as EmployeeAddress, 
m.FirstName as Manager,mt.Name as ManagerTown, ma.AddressText as ManagerAddress
from Employees as e
inner join Employees as m
on e.ManagerID=m.EmployeeID
inner join Addresses as ea
on e.AddressID=ea.AddressID
inner join Towns as et
on ea.TownID=et.TownID
inner join Addresses as ma
on m.AddressID=ma.AddressID
inner join Towns as mt
on ma.TownID=mt.TownID