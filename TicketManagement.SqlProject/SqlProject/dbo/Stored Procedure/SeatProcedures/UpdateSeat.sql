CREATE PROCEDURE [dbo].[UpdateSeat]
	@Id int,
	@Row nvarchar(50),
    @Number int,
    @AreaId int
AS
    UPDATE Seats set Row=@Row, Number=@Number, AreaId=@AreaId
	where Id = @Id
	select @@ROWCOUNT;
