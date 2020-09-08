CREATE PROCEDURE [dbo].[CreateEventArea]
	@Description nvarchar(50),
    @CoordX int,
    @CoordY int,
	@Price decimal,
    @EventId int
AS
    INSERT INTO EventAreas (Description, CoordX, CoordY, Price, EventId)
    VALUES (@Description, @CoordX, @CoordY, @Price, @EventId)
    SELECT SCOPE_IDENTITY()
