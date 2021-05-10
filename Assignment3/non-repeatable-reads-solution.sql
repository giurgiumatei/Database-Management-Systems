USE SHOP;

-- different results in both selects
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
SELECT * FROM Swords
WAITFOR DELAY '00:00:15'
SELECT * FROM Swords
COMMIT TRAN

-- the solution is to set the iso to read commited so we will have only the final result in both selects, 
-- the update wil wait until the transaction finishes
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT * FROM Swords
WAITFOR DELAY '00:00:15'
SELECT * FROM Swords
COMMIT TRAN

SELECT * FROM Swords