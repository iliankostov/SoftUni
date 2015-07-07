use Performance
go

create index IX_Performance_Date on Logs(EventDate)
go

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
