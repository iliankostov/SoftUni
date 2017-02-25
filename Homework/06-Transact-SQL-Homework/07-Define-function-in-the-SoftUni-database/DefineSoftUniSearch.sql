use SoftUni
go

create function Search(@input nvarchar(50), @word nvarchar(50))
returns int
begin
	declare @char nvarchar(1), @wcount int, @index int, @len int
	set @wcount = 0
	set @index = 1
	set @len = len(@word)

	while @index <= @len
	begin
		set @char = substring(@word, @index, 1)
		if charindex(@char, @input) = 0
		begin
			return 0
		end

		set @index = @index + 1
	end

	return 1
end
go

select FirstName from Employees
where dbo.Search('oistmiahf', FirstName) = 1
union
select MiddleName from Employees
where dbo.Search('oistmiahf', MiddleName) = 1
union
select LastName from Employees
where dbo.Search('oistmiahf', LastName) = 1
union 
select Name from Towns
where dbo.Search('oistmiahf', Name) = 1