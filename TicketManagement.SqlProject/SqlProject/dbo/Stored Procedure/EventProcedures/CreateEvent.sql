CREATE PROCEDURE [dbo].[CreateEvent]
	@Name nvarchar(50),
    @Description nvarchar(50),
    @LayoutId int,
    @BeginDate datetime,
    @EndDate datetime
AS
    INSERT INTO Events (Name, Description, LayoutId, BeginDate, EndDate)
    VALUES (@Name, @Description, @LayoutId, @BeginDate, @EndDate)
    SELECT SCOPE_IDENTITY()
