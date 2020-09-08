CREATE PROCEDURE [dbo].[DeleteVenue]
		@Id int
AS
    delete from Venues where Id=@Id;
	select @@ROWCOUNT;