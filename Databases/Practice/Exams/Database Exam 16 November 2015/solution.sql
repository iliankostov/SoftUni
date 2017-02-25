--1
SELECT
	Name,
	ISNULL([Description], 'No description') AS [Description]
FROM Albums
ORDER BY name ASC

--2
SELECT
	p.Title,
	a.Name
FROM Photographs AS p
JOIN AlbumsPhotographs AS ap
	ON p.Id = ap.PhotographId
JOIN Albums AS a
	ON a.Id = ap.AlbumId
ORDER BY a.Name ASC, p.Title DESC

--3
SELECT
	p.Title,
	p.Link,
	p.Description AS [Description],
	c.Name AS CategoryName,
	u.FullName AS Author
FROM Photographs AS p
JOIN Categories AS c
	ON p.CategoryId = c.Id
JOIN Users AS u
	ON u.Id = p.UserId
WHERE p.Description IS NOT NULL
ORDER BY p.Title ASC

-- 4
SELECT
	u.Username,
	u.FullName,
	u.BirthDate,
	ISNULL(p.Title, 'No photos') AS Photo
FROM Users AS u
LEFT JOIN Photographs AS p
	ON u.Id = p.UserId
WHERE DATEPART(MONTH, u.BirthDate) = 1
ORDER BY u.FullName ASC

-- 5
SELECT
	p.Title,
	c.Model AS CameraModel,
	l.Model AS LensModel
FROM Photographs AS p
JOIN Equipments AS e
	ON p.EquipmentId = e.Id
JOIN Cameras AS c
	ON c.Id = e.CameraId
JOIN Lenses AS l
	ON l.Id = e.LensId
ORDER BY p.Title ASC


-- 6 TODO
SELECT
	p.Title,
	cat.Name AS [Category Name],
	cam.Model,
	m.Name AS [Manufacturer Name],
	cam.Megapixels,
	cam.Price
FROM Equipments AS e
JOIN Photographs AS p
	ON e.Id = p.EquipmentId
JOIN Categories AS cat
	ON cat.Id = p.CategoryId
JOIN Cameras AS cam
	ON cam.Id = e.CameraId
JOIN Manufacturers AS m
	ON m.id = cam.ManufacturerId
ORDER BY cam.Price DESC, p.Title ASC

-- 7
SELECT
	m.Name,
	c.Model,
	c.Price
FROM Cameras AS c
JOIN Manufacturers AS m
	ON c.ManufacturerId = m.Id
WHERE c.Price > (SELECT
	AVG(Price)
FROM Cameras)
ORDER BY c.Price DESC, c.Model ASC

-- 8
SELECT
	m.Name,
	SUM(l.Price) AS [Total Price]
FROM Lenses AS l
JOIN Manufacturers AS m
	ON m.Id = l.ManufacturerId
GROUP BY m.Name
ORDER BY m.Name ASC

-- 9
SELECT
	u.FullName,
	m.Name AS Manufacturer,
	c.Model AS [Camera Model],
	c.Megapixels
FROM Users AS u
JOIN Equipments AS e
	ON e.Id = u.EquipmentId
JOIN Cameras AS c
	ON c.Id = e.CameraId
JOIN Manufacturers AS m
	ON c.ManufacturerId = m.Id
WHERE c.Year < 2015
ORDER BY u.FullName ASC

-- 10
SELECT
	l.Type,
	COUNT(l.Type) AS Count
FROM Lenses AS l
GROUP BY l.Type
ORDER BY count(l.Type) DESC, l.Type ASC

-- 11
SELECT
	Username,
	FullName
FROM Users
ORDER BY LEN(Username) + LEN(FullName) ASC, BirthDate DESC

-- 12
SELECT
	m.Name
FROM Manufacturers AS m
LEFT JOIN Cameras AS c
	ON m.Id = c.ManufacturerId
LEFT JOIN Lenses AS l
	ON m.Id = l.ManufacturerId
WHERE c.Model IS NULL
AND l.Model IS NULL
ORDER BY m.Name ASC