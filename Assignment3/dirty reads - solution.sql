USE SHOP;

-- the dirty read will happen because we can read uncommitted changes
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRAN
	SELECT * FROM Swords
	WAITFOR DELAY '00:00:15'
	SELECT * FROM Swords
COMMIT TRAN

-- the solution is to set the iso to read commited
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
	SELECT * FROM Swords
	WAITFOR DELAY '00:00:15'
	SELECT * FROM Swords
COMMIT TRAN

