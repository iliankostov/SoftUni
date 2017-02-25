select Count(*) as EmployeesWithManager
from Employees
where ManagerID is not null