USE SHOP;
ALTER DATABASE SHOP
SET ALLOW_SNAPSHOT_ISOLATION ON

--under the serializable isolation level this transaction will be blocked untill the other one is committed
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION
SELECT name FROM Ninja_Weapons
WHERE id = 5
COMMIT TRANSACTION

--the solution is to set the transaction isolation level to snapshot
--the transaction will not be blocked, instead will work on a past version of the data
SET TRANSACTION ISOLATION LEVEL SNAPSHOT
BEGIN TRANSACTION
SELECT name FROM Ninja_Weapons
WHERE id = 5
COMMIT TRANSACTION
--if for example here we would try to update the same piece of data as the other transaction
--this one will be blocked until the other one commits, then we will get an error



SET TRANSACTION ISOLATION LEVEL SNAPSHOT
BEGIN TRANSACTION
SELECT name FROM Ninja_Weapons
WHERE id = 5
--the value will be carbon spear because the other transaction hasn t reached the update statement
WAITFOR DELAY '00:00:10'
SELECT * FROM Ninja_Weapons
WHERE id = 5
-- the following statement will be blocked and then an error will be thrown
UPDATE Ninja_Weapons
SET name = 'Spear'
WHERE id = 5
COMMIT TRAN













