USE SHOP;

-- update a field, the other transactie gets to read the data
-- before the update is made

BEGIN TRAN
WAITFOR DELAY '00:00:10'
UPDATE Swords SET price=1000
WHERE id=5
COMMIT TRAN


-- undo
UPDATE Swords SET price=200
WHERE id=5

SELECT * FROM Swords