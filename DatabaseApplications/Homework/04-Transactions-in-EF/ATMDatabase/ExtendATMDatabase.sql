USE ATM
GO

CREATE TABLE TransactionHistory(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CardNumberId INT NOT NULL,
	TransactionDate DATE NOT NULL,
	Amount MONEY NOT NULL
)