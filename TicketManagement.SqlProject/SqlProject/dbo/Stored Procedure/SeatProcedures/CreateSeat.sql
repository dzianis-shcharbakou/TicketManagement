CREATE PROCEDURE [dbo].[CreateSeat]
	@Row int,
    @Number int,
    @AreaId int
AS
    INSERT INTO Seats (Row, Number, AreaId)
    VALUES (@Row, @Number, @AreaId)
    SELECT SCOPE_IDENTITY()
