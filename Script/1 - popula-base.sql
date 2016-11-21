USE Beerino
GO



INSERT INTO [USER] (Name, Email, CreationDate, Active)
	VALUES ('Marcos Koch', 'marcoskch@gmail.com', GETDATE(), 1);

INSERT INTO Beer (Name, [Description], Revenue, [Public], UserID, Active)
	VALUES ('Beerino IPA', 'Ale � um tipo de cerveja', '- Malte Ch�teau Pilsen	5,0 Kg', 1, 1, 1);

INSERT INTO TaskBeer ([Time], Temperature, [Order], BeerID, Active)
	VALUES (10, 20, 1, 1, 1);

INSERT INTO TaskBeer ([Time], Temperature, [Order], BeerID, Active)
	VALUES (10, 30, 2, 1, 1);

INSERT INTO TaskBeer ([Time], Temperature, [Order], BeerID, Active)
	VALUES (20, 50, 3, 1, 1);

INSERT INTO BeerinoUser (Name, UserID, BeerID, Active)
	VALUES ('Garagem', 1, 1, 1);