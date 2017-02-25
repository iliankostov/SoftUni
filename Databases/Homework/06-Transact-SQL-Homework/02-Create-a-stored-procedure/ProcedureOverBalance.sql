use Bank
go

create procedure GetOverBalanced(
@InitialBalance money
)
as
begin
select p.FirstName, p.LastName, a.Balance
from Persons as p
inner join Accounts as a
on a.PersonId = p.Id
where a.Balance > @InitialBalance
end
go

exec GetOverBalanced 10000