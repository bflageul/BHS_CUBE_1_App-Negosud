CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL IDENTITY (1,1),
	[Supplier_Id] INT NOT NULL,
	[Alcohol_Id] INT NOT NULL,
	[GrapeVariety_Id] INT NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,
	[Stock] BIT  NULL DEFAULT 0,
	[Description] TEXT NULL,
	[Medal] NVARCHAR NULL,
	[ProductionYear] Date NOT NULL,
	CONSTRAINT PK_Product_Id Primary key CLUSTERED (Id ASC),
	CONSTRAINT FK_Product_Supplier_Id FOREIGN KEY (Supplier_Id) REFERENCES [Supplier]([Id]),
	CONSTRAINT FK_Product_Alcohol_Id FOREIGN KEY (Alcohol_Id) REFERENCES [Alcohol]([Id]),
	CONSTRAINT FK_Product_GrapeVariety_Id FOREIGN KEY (GrapeVariety_Id) REFERENCES [GrapeVariety]([Id])
)
