CREATE PROCEDURE [dbo].[DeleteEvent]
		@Id int
AS
    delete from Events where Id=@Id;
	select @@ROWCOUNT;
