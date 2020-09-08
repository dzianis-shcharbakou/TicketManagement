CREATE PROCEDURE [dbo].[UpdateVenue]
	@Id int,
	@Description nvarchar(50),
    @Address nvarchar(50),
    @Phone nvarchar(50),
	@Name nvarchar(50)
AS
    UPDATE Venues set Description=@Description, Address=@Address, Phone=@Phone, Name=@Name
	where Id = @Id
	select @@ROWCOUNT;