use Bank
go

create function CalcNewBalance ( @Sum money, @YearlyInterest money, @Months int ) 
returns money 
as 
begin 
	declare @MonthlyInterest money
	set @MonthlyInterest = @YearlyInterest / 12
	return @Sum * (1 + @Months * @MonthlyInterest / 100)
end 
go 

select FirstName, LastName, dbo.CalcNewBalance(a.Balance, 4.5, 12) as [New Balance]
from Persons as p
inner join Accounts as a
on a.PersonId = p.Id