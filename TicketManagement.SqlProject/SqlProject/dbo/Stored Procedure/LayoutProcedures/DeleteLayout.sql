CREATE PROCEDURE [dbo].[DeleteLayout]
	@Id int
AS
    delete from Layouts where Id=@Id;
	select @@ROWCOUNT;
