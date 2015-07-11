-- 01. All Teams
SELECT TeamName 
FROM Teams
ORDER BY TeamName ASC

-- 02. Biggest Countries by Population
SELECT TOP 50 CountryName, [Population] 
FROM Countries
ORDER BY [Population] DESC, CountryName ASC

-- 03. Countries and Currency (Eurozone)
SELECT CountryName, CountryCode, (CASE CurrencyCode WHEN 'EUR' THEN 'Inside' ELSE 'Outside' END) AS Eurozone
FROM Countries 
ORDER BY CountryName ASC

-- 04. Teams Holding Numbers
SELECT TeamName AS [Team Name], CountryCode AS [Country Code]
FROM Teams
WHERE TeamName LIKE '%[0-9]%'

-- 05.	International Matches
SELECT hc.CountryName AS [Home Team], ac.CountryName AS [Away Team], im.MatchDate AS [Match Date] 
FROM InternationalMatches im
JOIN Countries hc
ON im.HomeCountryCode = hc.CountryCode
JOIN Countries ac
ON im.AwayCountryCode = ac.CountryCode
ORDER BY im.MatchDate DESC

-- 06.	*Teams with their League and League Country
SELECT t.TeamName AS [Team Name], l.LeagueName AS [League], ISNULL(c.CountryName, 'International') AS [League Country]
FROM Teams t
LEFT JOIN Leagues_Teams lt
ON lt.TeamId = t.Id
LEFT JOIN Leagues l
ON lt.LeagueId = l.Id
LEFT JOIN Countries c
on c.CountryCode = l.CountryCode
ORDER BY t.TeamName, l.LeagueName

-- 07.	* Teams with more than One Match
SELECT t.TeamName Team, COUNT(*) as [Matches Count]
FROM Teams t
LEFT JOIN TeamMatches tm
ON tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id
GROUP BY t.TeamName
HAVING COUNT(*) > 1
ORDER BY t.TeamName

-- 08.	Number of Teams and Matches in Leagues
SELECT 
	l.LeagueName [League Name], 
	COUNT(DISTINCT lt.TeamId) [Teams],
	COUNT(DISTINCT tm.Id) [Matches],
	ISNULL(AVG(tm.HomeGoals + tm.AwayGoals), 0) [Average Goals]
FROM Leagues l
LEFT JOIN Leagues_Teams lt
ON l.Id = lt.LeagueId 
LEFT JOIN TeamMatches tm
ON tm.LeagueId = l.Id
GROUP BY l.LeagueName
ORDER BY [Teams] DESC, [Matches] DESC

-- 09.	Total Goals per Team in all Matches
SELECT
	t.TeamName,
	ISNULL(SUM(CASE WHEN t.Id = tm.HomeTeamId THEN tm.HomeGoals ELSE tm.AwayGoals END), 0) [Total Goals]
FROM Teams t
LEFT JOIN TeamMatches tm
ON tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id
GROUP BY t.TeamName
ORDER BY [Total Goals] DESC, t.TeamName ASC

-- 10.	Pairs of Matches on the Same Day
SELECT fdtm.MatchDate [First Date], sdtm.MatchDate [Second Date]
FROM TeamMatches fdtm, TeamMatches sdtm
WHERE fdtm.MatchDate < sdtm.MatchDate
AND YEAR(fdtm.MatchDate) = YEAR(sdtm.MatchDate)
AND MONTH(fdtm.MatchDate) = MONTH(sdtm.MatchDate)
AND DAY(fdtm.MatchDate) = DAY(sdtm.MatchDate)
ORDER BY fdtm.MatchDate DESC, sdtm.MatchDate DESC

-- 11.	Mix of Team Names
SELECT LOWER(SUBSTRING(t1.TeamName, 1, LEN(t1.TeamName) - 1) + REVERSE(t2.TeamName)) AS Mix
FROM Teams t1, Teams t2
WHERE LOWER(RIGHT(t1.TeamName, 1)) = LOWER(LEFT(REVERSE(t2.TeamName), 1))
ORDER BY Mix ASC

-- 12.	Countries with International and Team Matches
SELECT
    c.CountryName AS [Country Name],
    COUNT(DISTINCT im.id) AS [International Matches],
    COUNT(DISTINCT tm.Id) AS [Team Matches]
FROM Countries AS c
LEFT JOIN Leagues AS l
    ON l.CountryCode = c.CountryCode
LEFT JOIN TeamMatches AS tm
    ON tm.LeagueId = l.Id
LEFT JOIN InternationalMatches AS im
    ON im.AwayCountryCode = c.CountryCode OR im.HomeCountryCode = c.CountryCode
GROUP BY c.CountryName
HAVING  COUNT(DISTINCT im.id) > 0 OR COUNT(DISTINCT tm.Id) > 0
ORDER BY [International Matches] DESC, [Team Matches] DESC, [Country Name] ASC

-- 13.	Non-international Matches
USE Football 
GO

CREATE TABLE FriendlyMatches(
    Id INT IDENTITY PRIMARY KEY,
    HomeTeamID INT NOT NULL FOREIGN KEY REFERENCES Teams(Id),
    AwayTeamID INT NOT NULL FOREIGN KEY REFERENCES Teams(Id),
    MatchDate DATETIME NOT NULL)

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')
GO

SELECT
	ht.TeamName AS [Home Team],
	at.TeamName AS [Away Team],
	m.MatchDate AS [Match Date]
FROM 
	(SELECT fm.HomeTeamID, fm.AwayTeamId, fm.MatchDate FROM FriendlyMatches AS fm
	UNION
	SELECT tm.HomeTeamId, tm.AwayTeamId, tm.MatchDate FROM TeamMatches AS tm) AS m
JOIN Teams AS ht
ON m.HomeTeamID = ht.Id
JOIN Teams AS at
ON m.AwayTeamId = at.Id
ORDER BY [Match Date] DESC
GO

-- 14.	Seasonal Matches
USE Football
GO

ALTER TABLE Leagues ADD IsSeasonal BIT NOT NULL DEFAULT 0
GO

DECLARE @league INT = (SELECT l.Id FROM Leagues AS l WHERE l.LeagueName = 'Italian Serie A')

INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId) VALUES
    ((SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'Empoli'),
    (SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'Parma'),
    2,
    2,
    '19-Apr-2015 16:00',
    @league),
    ((SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'Internazionale'),
    (SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'AC Milan'),
    0,
    0,
    '19-Apr-2015 21:45',
    @league)
GO

UPDATE Leagues
SET IsSeasonal = 1
WHERE Id IN (SELECT DISTINCT LeagueId FROM TeamMatches WHERE LeagueId IS NOT NULL)
GO

SELECT 
    ht.TeamName AS [Home Team],
    tm.HomeGoals AS [Home Goals],
    at.TeamName  AS [Away Team],
    tm.AwayGoals  AS [Away Goals],
    l.LeagueName  AS [League Name]
FROM Leagues AS l
JOIN TeamMatches AS tm
    ON l.Id = tm.LeagueId
JOIN Teams AS ht
    ON tm.HomeTeamId = ht.Id
JOIN Teams AS at
    ON tm.AwayTeamId = at.Id
WHERE l.IsSeasonal = 1 AND tm.MatchDate > '10-APR-2015'
ORDER BY [League Name] ASC, [Home Goals] DESC, [Away Goals] DESC
GO

-- 15.	Stored Function: Bulgarian Teams with Matches
USE Football
GO

CREATE VIEW [Bulgarian Teams]
AS    
    SELECT
        t.TeamName AS Name,
        tm1.TeamName AS HomeTeam,
        tm.HomeGoals AS HomeGoals,
        tm2.TeamName AS AwayTeam,
        tm.AwayGoals AS AwayGoals,
        tm.MatchDate
    FROM Teams AS t 
    LEFT JOIN TeamMatches AS tm
        ON t.Id = tm.HomeTeamId OR t.Id = tm.AwayTeamId
    LEFT JOIN Teams AS tm1
        ON tm.HomeTeamId = tm1.Id
    LEFT JOIN Teams AS tm2
        ON tm.AwayTeamId = tm2.Id
    WHERE t.CountryCode = 'BG'
GO

CREATE FUNCTION fn_TeamsJSON() RETURNS NVARCHAR(MAX)
AS
    BEGIN
        DECLARE @json NVARCHAR(MAX)

        SET @json = '{"teams":[' + 
		STUFF((
			SELECT 
				',{"name":"' + t1.Name
				+ '","matches":' + ISNULL(t1.Matches, '[]') + '}'
			FROM 		
				(SELECT
					t.Name AS name,
					'[{' + 
					STUFF(ISNULL(
						(SELECT 
							',{"'+ x.HomeTeam +'":' + CAST(x.HomeGoals AS NVARCHAR(MAX)) +
							',"' + x.AwayTeam + '":' + CAST(x.AwayGoals AS NVARCHAR(MAX)) + 
							',"date":' + CONVERT(NVARCHAR(10), x.MatchDate, 103) + '}'
						FROM [Bulgarian Teams] x
						WHERE x.Name = t.Name
						GROUP BY x.Name, x.HomeTeam, x.HomeGoals, x.AwayTeam, x.AwayGoals, x.MatchDate
                        ORDER BY x.MatchDate DESC
						FOR XML PATH (''), TYPE).value('.','NVARCHAR(max)'), ''), 1, 2, '') + 
					']' AS [Matches]
				FROM [Bulgarian Teams] t
				GROUP BY t.Name) AS t1
			FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(max)'), 1, 1, '')
	 + ']}'

        RETURN @json
    END
GO

SELECT dbo.fn_TeamsJSON()
GO