CREATE PROCEDURE [dbo].[CreateArea]
	@Description nvarchar(50),
    @CoordX int,
    @CoordY int,
    @LayoutId int
AS
    INSERT INTO Areas (Description, CoordX, CoordY, LayoutId)
    VALUES (@Description, @CoordX, @CoordY, @LayoutId)
    SELECT SCOPE_IDENTITY()
