CREATE PROCEDURE [dbo].[UpdateArea]
	@Id int,
	@Description nvarchar(50),
    @CoordX int,
    @CoordY int,
    @LayoutId int
AS
    UPDATE Areas set Description=@Description, CoordX=@CoordX, CoordY=@CoordY, LayoutId=@LayoutId
	where Id = @Id
    select @@ROWCOUNT;
