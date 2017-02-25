use Bank
go

create procedure WithdrawMoney(
@AccountId int,
@Money money
)
as
begin
declare @OldBalance money select @OldBalance = Balance from Accounts as a where Id = @AccountId
declare @NewBalance money set @NewBalance = @OldBalance - @Money

update Accounts
set Balance = @NewBalance
where Id = @AccountId
select Balance from Accounts where Id = @AccountId
end

exec WithdrawMoney 2, 2500
go

create procedure DepositMoney(
@AccountId int,
@Money money
)
as
begin
declare @OldBalance money select @OldBalance = Balance from Accounts as a where Id = @AccountId
declare @NewBalance money set @NewBalance = @OldBalance + @Money

update Accounts
set Balance = @NewBalance
where Id = @AccountId
select Balance from Accounts where Id = @AccountId
end

exec DepositMoney 2, 2500