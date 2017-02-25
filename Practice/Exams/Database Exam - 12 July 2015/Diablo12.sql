USE Diablo
GO
BEGIN TRANSACTION

DECLARE @UserId int = (SELECT Id FROM Users WHERE Username = 'Alex')

DECLARE @GameId int = (SELECT Id FROM Games WHERE Name = 'Edinburgh')

DECLARE @UsersGamesId int = (Select Id FROM UsersGames WHERE UserId = @UserId and GameId = @GameId)

Declare @Items table (ItemId int, ItemPrice money, UsersGamesId int)
Select Id, Price, @UsersGamesId as [UsersGamesId] FROM Items
WHERE Name In (
				'Blackguard', 
				'Bottomless Potion of Amplification', 
				'Eye of Etlich (Diablo III)', 
				'Gem of Efficacious Toxin',
				'Golden Gorget of Leoric', 
				'Hellfire Amulet')

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES 
(51, 235),
(71, 235),
(157, 235),
(184, 235),
(197, 235),
(223, 235)
GO

UPDATE UsersGames
set Cash = (Cash - 2957)
WHERE UserId = 5 and Id = 235
go

SELECT 
	u.Username,
	'Edinburgh' as Name,
	ug.Cash,
	(SELECT Name FROM Items WHERE Id = ugi.ItemId) as [Item Name]
FROM Users u
full JOIN UsersGames ug
on ug.UserId = u.Id
full JOIN UserGameItems ugi
on ugi.UserGameId = ug.Id
WHERE ug.GameId = 221
ORDER BY [Item Name]
go

ROLLBACK