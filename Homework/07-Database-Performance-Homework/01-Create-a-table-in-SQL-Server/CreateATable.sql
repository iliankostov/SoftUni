create database Performance
go

use Performance
go

create table Logs(Id int primary key identity, Date datetime, EventLog text)
go

declare @Count int
set @Count = 1
while @Count <= 10000000
begin
	insert into Logs values
		 (dateadd(mi, @Count, '11-26-1983'), 'I perform event number: ' + cast(@Count as varchar(10)))
	set @Count = @Count + 1
end

-- TODO: Search in the table by date range. Check the speed (without caching).