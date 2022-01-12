﻿CREATE TABLE [dbo].[GrapeVariety]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Color] NVARCHAR(255) NOT NULL,
	[GrapeName] NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_GrapeVariety_Id PRIMARY KEY CLUSTERED (Id ASC)
)
