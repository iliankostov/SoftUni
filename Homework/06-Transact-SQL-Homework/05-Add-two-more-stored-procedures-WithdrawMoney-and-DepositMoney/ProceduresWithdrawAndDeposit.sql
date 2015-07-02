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

select @NewBalance as [Balance after withdraw]

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

select @NewBalance as [Balance after withdraw]

end

exec DepositMoney 2, 2500