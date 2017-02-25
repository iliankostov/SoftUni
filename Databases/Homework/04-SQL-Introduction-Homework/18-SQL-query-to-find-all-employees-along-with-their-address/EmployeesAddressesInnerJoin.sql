select FirstName, Name as Town, AddressText as Address
from Employees as e
inner join Addresses as a
on e.AddressID=a.AddressID
inner join Towns as t
on a.TownID=t.TownID