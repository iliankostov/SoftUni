use Performance
go

-- create index
create index IX_Performance_Date on Logs(EventDate)
go

-- clear the cache
dbcc freeproccache
dbcc dropcleanbuffers
go

-- search in the table by date range 
select Id, EventDate from Logs 
where EventDate between '01-01-1990' and '01-01-2000'
go
