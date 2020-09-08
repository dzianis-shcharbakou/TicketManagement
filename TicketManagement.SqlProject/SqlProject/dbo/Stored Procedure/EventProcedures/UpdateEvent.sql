CREATE PROCEDURE [dbo].[UpdateEvent]
	@Id int,
	@Name nvarchar(50),
    @Description nvarchar(50),
    @LayoutId int,
	@BeginDate datetime,
    @EndDate datetime
AS
    UPDATE Events set Name=@Name, Description=@Description, LayoutId=@LayoutId, BeginDate=@BeginDate, EndDate=@EndDate
	where Id = @Id
	select @@ROWCOUNT;
