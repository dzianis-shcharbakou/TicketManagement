CREATE TABLE [dbo].[EventSeats]
(
	[Id]          INT IDENTITY (1, 1) NOT NULL,
    [EventAreaId] INT NOT NULL,
    [Row]         INT NOT NULL,
    [Number]      INT NOT NULL,
    [State]       INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Areas_EventSeats] FOREIGN KEY ([EventAreaId]) REFERENCES [dbo].[EventAreas] ([Id]) ON DELETE CASCADE
)
