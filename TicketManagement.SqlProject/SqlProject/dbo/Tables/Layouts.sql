CREATE TABLE [dbo].[Layouts]
(
	[Id]          INT            IDENTITY (1, 1) NOT NULL,
    [VenueId]     INT            NOT NULL,
    [Description] NVARCHAR (120) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Venues_Layouts] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venues] ([Id]) ON DELETE CASCADE
)
