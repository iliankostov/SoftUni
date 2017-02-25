-- add column GroupId to table Users
alter table Users
add GroupId int

-- add foreign key
alter table Users
add foreign key (GroupId)
references Groups(Id)

-- fill some data in GroupId
update Users set GroupId = 1 where Id = 6
update Users set GroupId = 1 where Id = 7
update Users set GroupId = 1 where Id = 8