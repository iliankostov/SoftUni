-- Problem 1. All Mountain Peaks
SELECT PeakName 
FROM Peaks
ORDER BY PeakName

-- Problem 2. Biggest Countries by Population
SELECT TOP 30 CountryName, Population
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC, CountryName

-- Problem 3. Countries and Currency (Euro / Not Euro)
SELECT 
  CountryName, CountryCode,
  (CASE WHEN CurrencyCode='EUR' THEN 'Euro' ELSE 'Not Euro' END) AS Currency
FROM Countries
ORDER BY CountryName

-- Problem 4. Countries Holding 'A' 3 or More Times
SELECT 
  CountryName AS [Country Name], IsoCode AS [ISO Code]
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

-- Problem 5. Peaks and Mountains
SELECT 
  PeakName, MountainRange as Mountain, Elevation
FROM 
  Peaks p 
  JOIN Mountains m ON p.MountainId = m.Id
ORDER BY Elevation DESC, PeakName

-- Problem 6. Peaks with Their Mountain, Country and Continent
SELECT 
  PeakName, MountainRange as Mountain, c.CountryName, cn.ContinentName
FROM 
  Peaks p
  JOIN Mountains m ON p.MountainId = m.Id
  JOIN MountainsCountries mc ON m.Id = mc.MountainId
  JOIN Countries c ON c.CountryCode = mc.CountryCode
  JOIN Continents cn ON cn.ContinentCode = c.ContinentCode
ORDER BY PeakName, CountryName

-- Problem 7. Rivers Passing through 3 or More Countries
SELECT 
  r.RiverName AS [River], 
  (SELECT COUNT(DISTINCT CountryCode) 
   FROM CountriesRivers 
   WHERE RiverId = r.Id) AS [Countries Count]
FROM
  Rivers r
WHERE
  (SELECT COUNT(DISTINCT CountryCode) 
   FROM CountriesRivers 
   WHERE RiverId = r.Id) >= 3
ORDER BY RiverName

-- Problem 8. Highest, Lowest and Average Peak Elevation
SELECT 
  MAX(Elevation) AS MaxElevation,
  MIN(Elevation) AS MinElevation,
  AVG(Elevation) AS AverageElevation
FROM Peaks

-- Problem 9. Rivers by Country
SELECT
  c.CountryName, ct.ContinentName,
  COUNT(r.RiverName) AS RiversCount,
  ISNULL(SUM(r.Length), 0) AS TotalLength
FROM
  Countries c
  LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
  LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
  LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY c.CountryName, ct.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, CountryName

-- Problem 10. Count of Countries by Currency
SELECT
  cur.CurrencyCode,
  MIN(cur.Description) AS Currency,
  COUNT(c.CountryName) AS NumberOfCountries
FROM
  Currencies cur
  LEFT JOIN Countries c ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode
ORDER BY NumberOfCountries DESC, Currency ASC

-- Problem 11. Population and Area by Continent
SELECT
  ct.ContinentName,
  SUM(CONVERT(numeric, c.AreaInSqKm)) AS CountriesArea,
  SUM(CONVERT(numeric, c.Population)) AS CountriesPopulation
FROM
  Countries c
  LEFT JOIN Continents ct ON ct.ContinentCode = c.ContinentCode
GROUP BY ct.ContinentName
ORDER BY CountriesPopulation DESC

-- Problem 12. Highest Peak and Longest River by Country
SELECT
  c.CountryName,
  MAX(p.Elevation) AS HighestPeakElevation,
  MAX(r.Length) AS LongestRiverLength
FROM
  Countries c
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
  LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
  LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName ASC

-- Problem 13. Mix of Peak and River Names
SELECT 
  p.PeakName, 
  r.RiverName, 
  LOWER(p.PeakName + SUBSTRING(r.RiverName, 2, LEN(r.RiverName))) AS Mix
FROM Peaks p, Rivers r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix

-- Problem 14. Highest Peak Name and Elevation by Country
SELECT
  c.CountryName AS [Country],
  p.PeakName AS [Highest Peak Name],
  p.Elevation AS [Highest Peak Elevation],
  m.MountainRange AS [Mountain]
FROM
  Countries c
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
WHERE p.Elevation =
  (SELECT MAX(p.Elevation)
   FROM MountainsCountries mc
     LEFT JOIN Mountains m ON m.Id = mc.MountainId
     LEFT JOIN Peaks p ON p.MountainId = m.Id
   WHERE c.CountryCode = mc.CountryCode)
UNION
SELECT
  c.CountryName AS [Country],
  '(no highest peak)' AS [Highest Peak Name],
  0 AS [Highest Peak Elevation],
  '(no mountain)' AS [Mountain]
FROM
  Countries c
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
WHERE 
  (SELECT MAX(p.Elevation)
   FROM MountainsCountries mc
     LEFT JOIN Mountains m ON m.Id = mc.MountainId
     LEFT JOIN Peaks p ON p.MountainId = m.Id
   WHERE c.CountryCode = mc.CountryCode) IS NULL
ORDER BY c.CountryName, [Highest Peak Name]


-- Problem 15. Monasteries by Country
CREATE TABLE Monasteries(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(50),
  CountryCode CHAR(2)
)
GO

ALTER TABLE Monasteries WITH CHECK ADD CONSTRAINT FK_Monasteries_Countries
FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
GO

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL
DEFAULT 0

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (
	SELECT c.CountryCode
	FROM Countries c
	  JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	  JOIN Rivers r ON r.Id = cr.RiverId
	GROUP BY c.CountryCode
	HAVING COUNT(r.Id) > 3
)

SELECT 
  m.Name AS Monastery, c.CountryName AS Country
FROM 
  Countries c
  JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name

-- Problem 16. Monasteries by Continents and Countries
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Maynmar'))

SELECT ct.ContinentName, c.CountryName, COUNT(m.Id) AS MonasteriesCount
FROM Continents ct
  LEFT JOIN Countries c ON ct.ContinentCode = c.ContinentCode
  LEFT JOIN Monasteries m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY ct.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName


-- Problem 17. Create a Stored Function
IF OBJECT_ID('fn_MountainsPeaksJSON') IS NOT NULL
  DROP FUNCTION fn_MountainsPeaksJSON
GO

CREATE FUNCTION fn_MountainsPeaksJSON()
	RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @json NVARCHAR(MAX) = '{"mountains":['

	DECLARE montainsCursor CURSOR FOR
	SELECT Id, MountainRange FROM Mountains

	OPEN montainsCursor
	DECLARE @mountainName NVARCHAR(MAX)
	DECLARE @mountainId INT
	FETCH NEXT FROM montainsCursor INTO @mountainId, @mountainName
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @json = @json + '{"name":"' + @mountainName + '","peaks":['

		DECLARE peaksCursor CURSOR FOR
		SELECT PeakName, Elevation FROM Peaks
		WHERE MountainId = @mountainId

		OPEN peaksCursor
		DECLARE @peakName NVARCHAR(MAX)
		DECLARE @elevation INT
		FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json = @json + '{"name":"' + @peakName + '",' +
				'"elevation":' + CONVERT(NVARCHAR(MAX), @elevation) + '}'
			FETCH NEXT FROM peaksCursor INTO @peakName, @elevation
			IF @@FETCH_STATUS = 0
				SET @json = @json + ','
		END
		CLOSE peaksCursor
		DEALLOCATE peaksCursor
		SET @json = @json + ']}'

		FETCH NEXT FROM montainsCursor INTO @mountainId, @mountainName
		IF @@FETCH_STATUS = 0
			SET @json = @json + ','
	END
	CLOSE montainsCursor
	DEALLOCATE montainsCursor

	SET @json = @json + ']}'
	RETURN @json
END
GO

SELECT dbo.fn_MountainsPeaksJSON()