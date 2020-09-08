SET IDENTITY_INSERT [dbo].[Venues] ON
GO

INSERT INTO [dbo].[Venues] ([Id], [Description], [Address], [Phone], [Name]) VALUES (1, N'First venue', N'First venue address', N'123 45 678 90 12', N'first')
GO

INSERT INTO [dbo].[Venues] ([Id], [Description], [Address], [Phone], [Name]) VALUES (2, N'Second venue', N'Second venue address', N'123 45 678 90 12', N'second')
GO

SET IDENTITY_INSERT [dbo].[Venues] OFF
GO

SET IDENTITY_INSERT [dbo].[Layouts] ON
GO

INSERT INTO [dbo].[Layouts] ([Id], [VenueId], [Description], [Name]) VALUES (1, 1, N'First layout', N'first')
GO

INSERT INTO [dbo].[Layouts] ([Id], [VenueId], [Description], [Name]) VALUES (2, 1, N'Second layout', N'second')
GO

INSERT INTO [dbo].[Layouts] ([Id], [VenueId], [Description], [Name]) VALUES (3, 2, N'First layout', N'third')
GO

INSERT INTO [dbo].[Layouts] ([Id], [VenueId], [Description], [Name]) VALUES (4, 2, N'Second layout', N'forth')
GO

SET IDENTITY_INSERT [dbo].[Layouts] OFF
GO

SET IDENTITY_INSERT [dbo].[Areas] ON
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (1, 1, N'First area of first layout', 1, 1)
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (2, 1, N'Second area of first layout', 2, 2)
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (3, 2, N'First area of second layout', 3, 3)
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (4, 2, N'Second area of second layout', 4, 4)
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (5, 3, N'First area of third layout', 1, 1)
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (6, 3, N'Second area of third layout', 2, 2)
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (7, 4, N'First area of fourth layout', 3, 3)
GO

INSERT INTO [dbo].[Areas] ([Id], [LayoutId], [Description], [CoordX], [CoordY]) VALUES (8, 4, N'Second area of fourth layout', 4, 4)
GO

SET IDENTITY_INSERT [dbo].[Areas] OFF
GO

SET IDENTITY_INSERT [dbo].[Seats] ON
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (1, 1, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (2, 1, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (3, 1, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4, 1, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (5, 1, 1, 5)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (6, 2, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (7, 2, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (8, 2, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (9, 2, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (10, 2, 1, 5)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (11, 3, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (12, 3, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (13, 3, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (14, 3, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (15, 3, 1, 5)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (16, 4, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (17, 4, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (18, 4, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (19, 4, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (20, 4, 1, 5)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (21, 5, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (22, 5, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (23, 5, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (24, 5, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4007, 5, 1, 5)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4008, 6, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4009, 6, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4010, 6, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4011, 6, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4012, 6, 1, 5)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4014, 7, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4015, 7, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4016, 7, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4017, 7, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4018, 7, 1, 5)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4019, 8, 1, 1)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4020, 8, 1, 2)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4021, 8, 1, 3)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4022, 8, 1, 4)
GO

INSERT INTO [dbo].[Seats] ([Id], [AreaId], [Row], [Number]) VALUES (4023, 8, 1, 5)
GO

SET IDENTITY_INSERT [dbo].[Seats] OFF
GO

SET IDENTITY_INSERT [dbo].[Events] ON
GO

INSERT INTO [dbo].[Events] ([Id], [Name], [Description], [LayoutId], [BeginDate], [EndDate]) VALUES (1, N'First event', N'First', 1, N'2025-12-12 12:00:00', N'2025-12-12 13:00:00')
GO

INSERT INTO [dbo].[Events] ([Id], [Name], [Description], [LayoutId], [BeginDate], [EndDate]) VALUES (2, N'Second event', N'Second', 2, N'2025-12-12 12:00:00', N'2025-12-12 13:00:00')
GO

SET IDENTITY_INSERT [dbo].[Events] OFF
GO

SET IDENTITY_INSERT [dbo].[EventAreas] ON
GO

INSERT INTO [dbo].[EventAreas] ([Id], [Description], [EventId], [CoordX], [CoordY], [Price]) VALUES (1, N'First area of first layout', 1, 1, 1, 100)
GO

INSERT INTO [dbo].[EventAreas] ([Id], [Description], [EventId], [CoordX], [CoordY], [Price]) VALUES (2, N'Second area of first layout', 1, 1, 1, 100)
GO

INSERT INTO [dbo].[EventAreas] ([Id], [Description], [EventId], [CoordX], [CoordY], [Price]) VALUES (3, N'First area of second layout', 2, 2, 2, 200)
GO

INSERT INTO [dbo].[EventAreas] ([Id], [Description], [EventId], [CoordX], [CoordY], [Price]) VALUES (4, N'Second area of second layout', 2, 2, 2, 200)
GO

SET IDENTITY_INSERT [dbo].[EventAreas] OFF
GO

SET IDENTITY_INSERT [dbo].[EventSeats] ON
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (1, 0, 1, 1, 1)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (2, 0, 1, 1, 2)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (3, 0, 1, 1, 3)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (4, 0, 1, 1, 4)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (5, 0, 1, 1, 5)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (6, 0, 2, 1, 1)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (7, 0, 2, 1, 2)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (8, 0, 2, 1, 3)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (9, 0, 2, 1, 4)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (10, 0, 2, 1, 5)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (11, 0, 3, 1, 1)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (12, 0, 3, 1, 2)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (13, 0, 3, 1, 3)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (14, 0, 3, 1, 4)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (15, 0, 3, 1, 5)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (16, 0, 4, 1, 1)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (17, 0, 4, 1, 2)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (18, 0, 4, 1, 3)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (19, 0, 4, 1, 4)
GO

INSERT INTO [dbo].[EventSeats] ([Id], [State], [EventAreaId], [Row], [Number]) VALUES (20, 0, 4, 1, 5)
GO

SET IDENTITY_INSERT [dbo].[EventSeats] OFF
GO
