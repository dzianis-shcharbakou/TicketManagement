CREATE PROCEDURE [dbo].[DeleteSeat]
	@Id int
AS
    delete from Seats where Id=@Id;
	select @@ROWCOUNT;
