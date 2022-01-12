CREATE TABLE [dbo].[Address]
(
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [StreetNumber] NVARCHAR (255)  NULL,
    [WayType]      NVARCHAR (255) NULL,
    [StreetName]   NVARCHAR (255) NOT NULL,
    [PostalCode]   VARCHAR (6)  NOT NULL,
    [City]         NVARCHAR (255) NOT NULL,
    [Country]      NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
)
