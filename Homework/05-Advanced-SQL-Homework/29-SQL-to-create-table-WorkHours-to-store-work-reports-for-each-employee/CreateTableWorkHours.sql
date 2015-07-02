create table WorkHours 
(
	Id int primary key identity not null,
	WorkDate smalldatetime,
	Task nvarchar(max),
	WorkHours time,
	Comments nvarchar(max),
	EmployeeId int foreign key references Employees(EmployeeID) not null
)