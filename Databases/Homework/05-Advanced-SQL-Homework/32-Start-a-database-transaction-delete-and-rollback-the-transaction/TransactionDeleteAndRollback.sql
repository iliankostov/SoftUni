begin transaction DeleteAndRollback

alter table Departments nocheck constraint FK_Departments_Employees
delete  Employees
where DepartmentID = 
	(select DepartmentID 
	 from Departments
	 where Name = 'Sales')
delete from Departments
where Name = 'Sales'

rollback transaction DeleteAndRollback