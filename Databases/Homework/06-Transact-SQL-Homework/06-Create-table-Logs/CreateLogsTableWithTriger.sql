use Bank
go

create table Logs
(
LogId int primary key identity not null,
AccountId int foreign key references Accounts(Id),
OldSum money,
NewSum money
)
go

create trigger LogUpdateAccount 
on Accounts for update
as
begin
insert into Logs (AccountId, OldSum, NewSum)
select d.Id, d.Balance, i.Balance
from inserted i
join deleted d
on d.Id = i.Id
end
go