select FirstName + ' ' + LastName as FullName, d.Name as Department, Salary
from Employees as e
inner join Departments as d
on e.DepartmentID=d.DepartmentID
where Salary = (select min(Salary) 
				from Employees 
				where DepartmentID = e.DepartmentID)