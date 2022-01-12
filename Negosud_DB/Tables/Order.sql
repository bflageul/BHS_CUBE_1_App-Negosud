CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL IDENTITY(1,1) ,
	[Product_Id] int not null,
	[OrderDate] date not null,
	[DeliveryDate] date not null,
	[Quantity] int not null,
	[Price] int not null,
	CONSTRAINT PK_Order_Id PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT FK_Order_Product_Id FOREIGN KEY (Product_Id) REFERENCES [Product] ([Id])
)
