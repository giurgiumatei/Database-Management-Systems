USE SHOP;


--prepare database for snapshot isolation
ALTER DATABASE SHOP
SET ALLOW_SNAPSHOT_ISOLATION ON

SELECT* FROM Ninja_Weapons

--this transaction will block the other one until is committed
--under pesimistic isolation level
BEGIN TRANSACTION
UPDATE Ninja_Weapons
SET name = 'Carbon Little Spear'
WHERE id = 5
COMMIT TRANSACTION
--under optimistic isolation level at the start of
--this transaction a copy of the data will be created in the tempdb
--and all the other transactions will work on that one

--reset the value back to normal
UPDATE Ninja_Weapons
SET name = 'Carbon Spear'
WHERE id = 5