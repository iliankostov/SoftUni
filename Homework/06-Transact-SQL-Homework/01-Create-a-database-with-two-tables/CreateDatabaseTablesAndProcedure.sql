create database Bank
go

use Bank

create table Persons
(
	Id int primary key identity not null,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	SSN nvarchar(50)
)
go

create table Accounts
(
	Id int primary key identity not null,
	PersonId int foreign key references Persons(Id) not null,
	Balance money not null
)
go

insert into Persons values 
('Ivan', 'Ivanov', '132456789'),
('Georgi', 'Ivanov', '132456789'),
('Ivan', 'Georgiev', '132456789'),
('Ivan', 'Petrov', '132456789'),
('Petar', 'Ivanov', '132456789')

insert into Accounts values
(1, 5000),
(1, 10000),
(1, 15000),
(1, 20000),
(1, 25000)
go

create procedure FullName
as
begin
select FirstName + ' ' + LastName as [Full Name] from Persons
end
go

execute FullName