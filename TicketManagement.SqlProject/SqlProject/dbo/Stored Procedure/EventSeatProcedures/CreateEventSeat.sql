CREATE PROCEDURE [dbo].[CreateEventSeat]
    @Row int,
    @Number int,
    @State int,
    @EventAreaId int
AS
    INSERT INTO EventSeats (Row, Number, State, EventAreaId)
    VALUES (@Row, @Number, @State, @EventAreaId)
    SELECT SCOPE_IDENTITY()
