CREATE TABLE [dbo].[Events]
(
	[Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (120) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [LayoutId]    INT            NOT NULL,
    [BeginDate]   DATETIME       NOT NULL,
    [EndDate]     DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Layouts_Events] FOREIGN KEY ([LayoutId]) REFERENCES [dbo].[Layouts] ([Id]) ON DELETE CASCADE
)
