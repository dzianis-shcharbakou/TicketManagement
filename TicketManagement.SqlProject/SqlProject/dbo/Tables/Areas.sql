CREATE TABLE [dbo].[Areas]
(
	[Id]          INT            IDENTITY (1, 1) NOT NULL,
    [LayoutId]    INT            NOT NULL,
    [Description] NVARCHAR (200) NOT NULL,
    [CoordX]      INT            NOT NULL,
    [CoordY]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Layouts_Areas] FOREIGN KEY ([LayoutId]) REFERENCES [dbo].[Layouts] ([Id]) ON DELETE CASCADE
)
