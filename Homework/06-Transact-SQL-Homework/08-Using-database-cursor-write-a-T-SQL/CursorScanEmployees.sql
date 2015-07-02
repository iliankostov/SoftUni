declare empCursor cursor read_only for 
select e.FirstName + ' ' + e.LastName, t.Name
from Employees e
inner join Addresses a
on a.AddressID = e.AddressID
inner join Towns t
on t.TownID = a.TownID

open empCursor
declare @town nvarchar(50), @fullName nvarchar(50), @currentTown nvarchar(50), @currentFullName nvarchar(50)
fetch next from empCursor into @fullName, @town
while @@fetch_status = 0
  begin
	set @currentTown = @town
	set @currentFullName = @fullName
	fetch next from empCursor into @fullName, @town

	if( @currentTown = @town)
		print @town + ': ' + @fullName + ', ' + @currentFullName
  end
close empCursor
deallocate empCursor