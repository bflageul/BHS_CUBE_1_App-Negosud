CREATE TABLE [dbo].[GrapeRate]
(
	[Product_Id] INT NOT NULL,
	[GrapeVariety_Id] INT NOT NULL,
	[Rate] INT  NULL,
	CONSTRAINT PK_GrapeRate PRIMARY KEY CLUSTERED ([Product_Id] ASC, [GrapeVariety_Id] ASC),
	CONSTRAINT FK_GrapeRate_Product_Id FOREIGN KEY (Product_Id) REFERENCES [Product]([Id]),
	CONSTRAINT FK_GrapeRate_GraepVariety_Id FOREIGN KEY (GrapeVariety_Id) REFERENCES [GrapeVariety]([Id])
)
