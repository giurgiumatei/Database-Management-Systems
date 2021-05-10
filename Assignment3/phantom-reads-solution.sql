USE SHOP;

--with repeatable read iso level we should see a phantom row
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT * FROM Swords
WAITFOR DELAY '00:00:05'
SELECT * FROM Swords
COMMIT TRAN

-- the solution is to set the ISO level to serializable so both of the selects will show the state before the insert
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRAN
SELECT * FROM Swords
WAITFOR DELAY '00:00:05'
SELECT * FROM Swords
COMMIT TRAN

SELECT * FROM Swords