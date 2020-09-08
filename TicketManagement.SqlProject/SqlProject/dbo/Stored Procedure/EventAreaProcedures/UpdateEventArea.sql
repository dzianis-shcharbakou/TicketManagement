CREATE PROCEDURE [dbo].[UpdateEventArea]
	@Id int,
	@Description nvarchar(50),
    @CoordX int,
    @CoordY int,
	@Price decimal,
    @EventId int
AS
    UPDATE EventAreas set Description=@Description, CoordX=@CoordX, CoordY=@CoordY, Price=@Price, EventId=@EventId
	where Id = @Id
	select @@ROWCOUNT;
