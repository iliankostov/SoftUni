select * into ##TempEmployeesProjects
from EmployeesProjects

drop table EmployeesProjects

create table EmployeesProjects
(
	EmployeeID int foreign key references Employees(EmployeeID) not null,
	ProjectID int foreign key references Projects(ProjectID) not null
)

insert into EmployeesProjects
select * from ##TempEmployeesProjects