use Diablo
GO

-- 9
SELECT 
	u.Username,
	g.Name as Game,
	c.Name as [Character],
	Sum(s.Strength) as Strength, 
	Sum(s.Defence) as Defence, 
	Sum(s.Speed) as Speed, 
	Sum(s.Mind) as Mind,
	Sum(s.Luck) as Luck
from Users as u
join UsersGames as ug
on ug.UserId = u.Id
JOIN games as g
on ug.GameId = g.Id
JOIN Characters as c
on ug.CharacterId = c.Id
join [Statistics] as s
on c.StatisticId = s.Id
join UserGameItems as ugi
on ugi.UserGameId = ug.Id
join Items as i
on ugi.ItemId = i.Id
GROUP by g.Name, u.Username, c.Name