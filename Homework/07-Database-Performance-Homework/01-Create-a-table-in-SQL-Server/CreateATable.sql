create database Performance
go

alter database Performance
modify file(name=Performance_log, size=5000mb, filegrowth=1000mb)
go

alter database Performance
modify file(name=Performance, size=5000mb, filegrowth=1000mb)
go

use Performance
go

create table Logs(Id int primary key identity, EventDate datetime, EventLog text)
go

-- fill 10 000 000 rows
declare @Count int
set @Count = 1
while @Count <= 10000000
begin
	insert into Logs values
		 (dateadd(mi, @Count, '01-01-1990'), 'Event number: ' + cast(@Count as varchar(10)))
	set @Count = @Count + 1
end
go

-- clear the cache
dbcc freeproccache
dbcc dropcleanbuffers
go

-- search in the table by date range 
select Id, EventDate from Logs 
where EventDate between '01-01-1990' and '01-01-2000'
go
