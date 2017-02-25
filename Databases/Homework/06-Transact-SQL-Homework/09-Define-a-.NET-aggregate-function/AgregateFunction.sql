-- 1.FirstStep
-- Turning on CLR functionality
-- By default, CLR is disabled in SQL Server so to turn it on
-- we need to run this command against our database
exec sp_configure 'clr enabled', 1
go

reconfigure
go

-- 2. SecondStep
-- Creating the SQL assembly and linking it to the C# library DLL
create assembly ConcatenateStrings
authorization dbo
from 'C:\ConcatenateStrings.dll' --- Please be sure that the dll file is here
with permission_set = safe
go
 
-- 3. ThirdStep
create aggregate dbo.StrConcat (@value nvarchar(MAX)) returns nvarchar(MAX)
external name ConcatenateStrings.[ConcatenateStrings.StringConcatenator]
go

-- 4. FourStep 
-- Use aggregate function dbo.StrConcat
use SoftUni
select dbo.StrConcat(FirstName + ' ' + LastName)
from Employees

/*
DROP AGGREGATE dbo.StrConcat
DROP ASSEMBLY ConcatenateStrings
*/