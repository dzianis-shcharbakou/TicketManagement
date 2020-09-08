CREATE TABLE [dbo].[Seats]
(
	[Id]     INT IDENTITY (1, 1) NOT NULL,
    [AreaId] INT NOT NULL,
    [Row]    INT NOT NULL,
    [Number] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Areas_Seats] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Areas] ([Id]) ON DELETE CASCADE
)
