use Bank
go

create procedure PersonNewBalance (
@AccountId int,
@Interest money
)
as
begin
declare @OldBalance money select @OldBalance = Balance from Accounts as a where Id = @AccountId
declare @NewBalance money set @NewBalance = dbo.CalcNewBalance(@OldBalance, @Interest, 1)

select @NewBalance - @OldBalance as [Month interest]

end

exec PersonNewBalance 2, 4.5