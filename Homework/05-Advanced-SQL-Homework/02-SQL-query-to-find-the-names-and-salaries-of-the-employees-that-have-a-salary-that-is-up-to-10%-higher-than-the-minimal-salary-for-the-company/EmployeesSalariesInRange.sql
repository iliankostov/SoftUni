select FirstName, LastName, Salary
from Employees
where Salary between (select min(Salary) from Employees) and (select min(Salary)*1.1 from Employees)