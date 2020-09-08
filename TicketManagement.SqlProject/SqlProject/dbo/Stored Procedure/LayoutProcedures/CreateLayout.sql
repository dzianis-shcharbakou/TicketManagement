CREATE PROCEDURE [dbo].[CreateLayout]
	@Description nvarchar(50),
    @VenueId int,
    @Name nvarchar(50)
AS
    INSERT INTO Layouts (Description, VenueId, Name)
    VALUES (@Description, @VenueId, @Name)
    SELECT SCOPE_IDENTITY()
