-- create table Groups
create table Groups
(
	Id int primary key identity not null,
	Name nvarchar(50) unique not null
)

-- fill some groups
insert into Groups (Name) values ('Group1')