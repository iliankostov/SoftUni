create view Users_today as
select *
from Users
where LastLoginTime = Convert(date, getdate())