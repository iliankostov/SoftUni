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
