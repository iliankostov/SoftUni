-- let passwords allows null
alter table Users
alter column Password nvarchar(50) null

-- update passwords to null
update Users
set Password = null
where LastLoginTime < convert(date, '03-10-2010')