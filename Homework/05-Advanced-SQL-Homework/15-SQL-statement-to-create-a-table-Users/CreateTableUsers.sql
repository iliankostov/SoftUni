-- create table Users
create table Users 
(
	Id int primary key identity not null,
	Username nvarchar(50) unique not null,
	Password nvarchar(50) not null,
	FullName nvarchar(50) not null,
	LastLoginTime smalldatetime not null,

	constraint Check_Password check (len(Password) > 5)
)

-- fill some users
insert into Users (Username, Password, FullName, LastLoginTime) values
('pencho', '123456', 'Pencho', '07-01-2015'),
('gencho', '123456', 'Gencho', '07-02-2015'),
('atanas', '123456', 'Atanas', '06-30-2015')