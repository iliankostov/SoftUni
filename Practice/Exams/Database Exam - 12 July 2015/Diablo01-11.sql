-- 1
SELECT Name FROM Characters
ORDER BY Name
-- 2
Select top 50 Name as Game, Format(Start, 'yyyy-MM-dd') as Start from Games
where YEAR(Start) in ('2011', '2012')
order by Start, name
-- 3
select Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) as [Email Provider] from Users
order by [Email Provider], Username
-- 4
SELECT Username, IpAddress as [IP Address] from Users
WHERE IpAddress LIKE '___.1%.%.___'
order by Username
--5
SELECT 
	Name as Game,
	(CASE 
		WHEN 
			((Convert(time, Start, 8) >= (convert(time, '00:00:00', 8))) AND (Convert(time, Start, 8) < convert(time, '12:00:00', 8)))
		THEN 'Morning'
		WHEN 
			((Convert(time, Start, 8) > (convert(time, '12:00:00', 8))) AND (Convert(time, Start, 8) < convert(time, '18:00:00', 8)))
		THEN 'Afternoon'
		WHEN 
			((Convert(time, Start, 8) > (convert(time, '18:00:00', 8))) AND (Convert(time, Start, 8) < convert(time, '23:59:59', 8)))
		THEN 'Evening'
	END) as [Part of the Day],
	(CASE 
		WHEN Duration <= 3 THEN 'Extra Short' 
		WHEN Duration in (4, 5, 6) THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END) as Duration
from Games
ORDER by Name, Duration, [Part of the Day]

-- 6
SELECT 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) as [Email Provider],
	COUNT(Id) as [Number Of Users]
from Users
GROUP by SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
ORDER by [Number Of Users] DESC

-- 7
SELECT 
	g.Name as Game,
	(SELECT Name FROM GameTypes WHERE g.GameTypeId = Id) as [Game Type],
	u.Username,
	ug.Level as [Level],
	ug.Cash,
	(SELECT Name FROM Characters WHERE ug.CharacterId = Id) as [Character]
FROM Users u
JOIN UsersGames ug
on ug.UserId = u.Id
join Games g
on g.Id = ug.GameId
ORDER By [Level] desc, u.Username, Game

-- 8
SELECT 
	u.Username,
	g.Name as Game,
	COUNT(i.Id) as [Items Count],
	sum(i.Price) as [Items Price]
FROM Users as u
JOIN UsersGames ug
on u.Id = ug.UserId
join Games as g
on ug.GameId = g.Id
JOIN UserGameItems ugi
on ugi.UserGameId = ug.Id
JOIN Items as i
on ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY COUNT(i.Id) DESC, [Items Price] DESC

-- 10 
SELECT 
	i.Name,
	i.Price,
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck, 
	s.Mind
from Items as i
join [Statistics] as s
ON i.StatisticId = s.Id
WHERE (s.Mind) > (SELECT AVG(Mind) FROM [Statistics])
AND (s.Luck) > (SELECT AVG(Luck) FROM [Statistics])
AND (s.Speed) > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY i.Name

---- 11
SELECT 
	i.Name as Item,
	i.Price, i.MinLevel,
	gt.Name as [Forbidden Game Type]
FROM Items as i
left join GameTypeForbiddenItems as gtfi
on gtfi.ItemId = i.Id
left JOIN GameTypes as gt
on gtfi.GameTypeId = gt.Id
ORDER BY gt.Name DESC, i.Name ASC
