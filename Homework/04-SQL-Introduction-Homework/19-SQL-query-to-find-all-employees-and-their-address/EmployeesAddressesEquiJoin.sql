select FirstName, Name as Town, AddressText as Address
from Employees as e, Towns as t, Addresses as a
where e.AddressID=a.AddressID and a.TownID=t.TownID