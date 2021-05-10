USE SHOP;

BEGIN TRAN
WAITFOR DELAY '00:00:05'
INSERT INTO Swords(name, brand_id, price, stars) VALUES ('test', 1, 100, 5)
COMMIT TRAN


DELETE FROM Swords
WHERE name='test'