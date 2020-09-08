CREATE TABLE [dbo].[EventAreas]
(
	[Id]          INT            IDENTITY (1, 1) NOT NULL,
    [EventId]     INT            NOT NULL,
    [Description] NVARCHAR (200) NOT NULL,
    [CoordX]      INT            NOT NULL,
    [CoordY]      INT            NOT NULL,
    [Price]       DECIMAL (18, 2)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Events_EventAreas] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id]) ON DELETE CASCADE
)
