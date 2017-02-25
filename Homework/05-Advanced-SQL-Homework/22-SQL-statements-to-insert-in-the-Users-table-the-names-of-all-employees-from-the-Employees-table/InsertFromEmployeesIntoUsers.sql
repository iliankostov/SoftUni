insert into Users (Username, Password, FullName, LastLoginTime)
select 
	lower(left(FirstName, 3) + (LastName)), 
	lower(left(FirstName, 1) + (LastName) + 'pass'), 
	FirstName + ' ' + LastName,
	convert(date, getdate())
from Employees