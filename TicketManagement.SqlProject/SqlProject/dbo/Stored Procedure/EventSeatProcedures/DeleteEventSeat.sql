CREATE PROCEDURE [dbo].[DeleteEventSeat]
	@Id int
AS
    delete from EventSeats where Id=@Id;
	select @@ROWCOUNT;
