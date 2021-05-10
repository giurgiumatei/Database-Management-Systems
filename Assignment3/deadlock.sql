USE SHOP;

-- the two updates will cause a deadlock with the ones from the other query
-- since each one wil be waiting for the other one to free the resource
--SET DEADLOCK_PRIORITY HIGH
BEGIN TRAN
UPDATE Swords SET name='test1' WHERE id=5
WAITFOR DELAY '00:00:10'
UPDATE Ninja_Weapons SET name='test1' WHERE id=5
COMMIT TRAN


SELECT * FROM Swords
SELECT * FROM Ninja_Weapons

UPDATE Swords SET name='Mirkwood Infantry Sword'
WHERE id=5

UPDATE Ninja_Weapons SET name='Carbon Spear'
WHERE id=5