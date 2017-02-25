-- create new groups
insert into Groups (Name) values ('Group2'), ('Group3')

-- create some users
insert into Users (Username, Password, FullName, LastLoginTime, GroupId) values 
('kiril', '123546', 'Kiril', '07-03-2015', 2),
('blagoi', '123546', 'Blagoi', '07-03-2015', 3)