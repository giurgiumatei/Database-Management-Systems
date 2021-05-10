USE SHOP;



--try to update and rollback after a 10 seconds delay
BEGIN TRAN
UPDATE Swords SET price=1000
WHERE id=5
WAITFOR DELAY '00:00:10'
ROLLBACK TRAN

-- dirty readhappens because we can read uncommited data
