create database Performance
go

use Performance
go

create table Logs(EventDate datetime, EventLog text)
go

declare @Count int
set @Count = 1
while @Count <= 10000000
begin
	insert into Logs values
		 (dateadd(mi, @Count, '11-26-1983'), 'I perform event number: ' + cast(@Count as varchar(10)))
	set @Count = @Count + 1
end

-- clear the cache
dbcc freeproccache
dbcc dropcleanbuffers
go

-- search in the table by date range 
select EventDate, EventLog from Logs where EventDate between '11-26-1983' and '11-06-1986'
go

-- check the cache
SELECT usecounts, cacheobjtype, objtype, text, size_in_bytes
FROM sys.dm_exec_cached_plans 
CROSS APPLY sys.dm_exec_sql_text(plan_handle) 
WHERE usecounts > 0 AND 
			text like '%select EventDate, EventLog from Logs%'
ORDER BY usecounts DESC;
GO

-- TODO - check the speed and do speed comparison
