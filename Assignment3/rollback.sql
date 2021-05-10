USE SHOP;

GO

CREATE TABLE LogTable(
Lid INT IDENTITY PRIMARY KEY,
TypeOperation VARCHAR(50),
TableOperation VARCHAR(50),
ExecutionDate DATETIME)


GO


SELECT * FROM Swords
SELECT * FROM Swords_Providers

/* provider name validator */
GO
CREATE FUNCTION uf_validate_name (@name VARCHAR(100)) RETURNS INT AS
BEGIN
DECLARE @return INT
SET @return = 0
IF(@name IN ('Lockheed Martin','Boeing','Raytheon','BAE Systems', 'Northrop Grumman'))
	SET @return = 1
RETURN @return
END


GO
/* stored procedure for adding swords */
CREATE OR ALTER PROCEDURE usp_add_swords @name VARCHAR(50), @brand_id INT, @price INT, @stars INT, @provider_name VARCHAR(50) AS
BEGIN

	BEGIN TRAN
	BEGIN TRY
	---first insert
	IF(@stars > 5 or @stars < 1)
	BEGIN
		RAISERROR('Stars must be between 1 and 5!',14,1)
	END
	INSERT INTO Swords(name, brand_id, price, stars) VALUES (@name, @brand_id, @price, @stars)
	DECLARE @sword_identity INT
	SET @sword_identity = @@IDENTITY
	INSERT INTO LogTable VALUES('add','Swords',GETDATE())
	---second insert
	IF(dbo.uf_validate_name(@provider_name) = 1)
	BEGIN
		RAISERROR('Invalid provider!',14,1)
	END
	INSERT INTO Swords_Providers(name) VALUES (@provider_name)
	DECLARE @provider_identity INT
	SET @provider_identity = @@IDENTITY
	INSERT INTO LogTable VALUES('add','Swords_Providers',GETDATE())
	---third insert
	INSERT INTO Swords__Swords_Providers__Bridge(product_id,provider_id) VALUES (@sword_identity,@provider_identity)
	INSERT INTO LogTable VALUES('add','Bridge',GETDATE())
	COMMIT TRAN
	SELECT 'The transaction completed succesfully'
	END TRY

	BEGIN CATCH
	ROLLBACK TRAN
	SELECT 'The transaction was aborted'
	END CATCH
END

---test case happy
SELECT * FROM Swords
EXEC usp_add_swords 'test',1,50,4,'test'
SELECT * FROM Swords

---test case error
SELECT * FROM Swords
EXEC usp_add_swords 'test2',1,50,4,'Boeing'
SELECT * FROM Swords

SELECT * FROM LogTable

SELECT * FROM Swords_Brand
SELECT * FROM Swords_Providers
SELECT * FROM Swords
SELECT * FROM Swords__Swords_Providers__Bridge


DELETE FROM Swords__Swords_Providers__Bridge
WHERE provider_id = 17

DELETE FROM Swords
WHERE name = 'test'

DELETE FROM Swords_Providers
WHERE name = 'test'

