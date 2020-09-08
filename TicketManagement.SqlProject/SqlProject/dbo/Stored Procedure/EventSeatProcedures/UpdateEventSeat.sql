CREATE PROCEDURE [dbo].[UpdateEventSeat]
	@Id int,
	@Row int,
    @Number int,
    @State int,
    @EventAreaId int
AS
    UPDATE EventSeats set Row=@Row, Number=@Number, State=@State, EventAreaId=@EventAreaId
	where Id = @Id
    select @@ROWCOUNT;
