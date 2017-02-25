select FirstName, LastName, Salary
from Employees
where Salary = (select min(Salary) from Employees)