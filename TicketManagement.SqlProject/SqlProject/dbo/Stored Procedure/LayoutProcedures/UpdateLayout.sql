CREATE PROCEDURE [dbo].[UpdateLayout]
	@Id int,
	@Description nvarchar(50),
    @VenueId int,
	@Name nvarchar(50)
AS
    UPDATE Layouts set Description=@Description, VenueId=@VenueId, Name=@Name
	where Id = @Id
	select @@ROWCOUNT;
