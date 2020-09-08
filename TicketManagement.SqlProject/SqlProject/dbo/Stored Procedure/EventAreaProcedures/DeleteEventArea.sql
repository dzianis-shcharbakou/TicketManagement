CREATE PROCEDURE [dbo].[DeleteEventArea]
	@Id int
AS
    delete from EventAreas where Id=@Id;
	select @@ROWCOUNT;
