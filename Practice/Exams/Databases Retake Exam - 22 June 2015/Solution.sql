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
