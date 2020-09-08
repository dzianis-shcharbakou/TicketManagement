CREATE PROCEDURE [dbo].[CreateVenue]
	@Description nvarchar(50),
    @Address nvarchar(50),
    @Phone nvarchar(50),
    @Name nvarchar(50)
AS
    INSERT INTO Venues (Description, Address, Phone, Name)
    VALUES (@Description, @Address, @Phone, @Name)
    SELECT SCOPE_IDENTITY()
