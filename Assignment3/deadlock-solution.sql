USE SHOP;

-- the two updates will cause a deadlock with the ones from the other query
-- since each one wil be waiting for the other one to free the resource
BEGIN TRAN
UPDATE Ninja_Weapons SET name='test2' WHERE id=5
WAITFOR DELAY '00:00:10'
UPDATE Swords SET name='test2' WHERE id=5
COMMIT TRAN

-- the solution is to give this transaction a higher priority so that the other one is chosen as a victim
SET DEADLOCK_PRIORITY HIGH
BEGIN TRAN
UPDATE Ninja_Weapons SET name='test2' WHERE id=5
WAITFOR DELAY '00:00:10'
UPDATE Swords SET name='test2' WHERE id=5
COMMIT TRAN