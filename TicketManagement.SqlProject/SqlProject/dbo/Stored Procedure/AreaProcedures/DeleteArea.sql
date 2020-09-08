CREATE PROCEDURE [dbo].[DeleteArea]
	@Id int
AS
    delete from Areas where Id=@Id;
	select @@ROWCOUNT;
