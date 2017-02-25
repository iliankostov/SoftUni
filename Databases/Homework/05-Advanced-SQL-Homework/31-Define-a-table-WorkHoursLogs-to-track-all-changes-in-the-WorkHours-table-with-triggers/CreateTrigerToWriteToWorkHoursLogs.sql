-- define table
create table WorkHoursLogs
(
	Id int primary key identity not null,
	NewWorkDate smalldatetime,
	NewTask nvarchar(max),
	NewWorkHours time,
	NewComments nvarchar(max),
	NewEmployeeId int,
	ExecutedCommand nchar(6)
)
go

-- create triger for insert
create trigger WorkHoursInsertTriger 
on WorkHours for insert
as  
begin
insert WorkHoursLogs
(NewWorkDate, NewTask, NewWorkHours, NewComments, NewEmployeeId, ExecutedCommand)
(select WorkDate, Task, WorkHours, Comments, EmployeeId, 'Insert'
	from inserted)
end
go

-- create triger for update
create trigger WorkHoursUpdateTriger
on WorkHours for update
as  
begin
insert WorkHoursLogs
(NewWorkDate, NewTask, NewWorkHours, NewComments, NewEmployeeId, ExecutedCommand)
(select WorkDate, Task, WorkHours, Comments, EmployeeId, 'Update'
	from inserted)
end
go

-- create triger for delete
create trigger WorkHoursDeleteTriger
on WorkHours for delete
as  
begin
insert WorkHoursLogs
(NewWorkDate, NewTask, NewWorkHours, NewComments, NewEmployeeId, ExecutedCommand)
(select WorkDate, Task, WorkHours, Comments, EmployeeId, 'Delete'
	from deleted)
end
go