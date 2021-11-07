CREATE TABLE [dbo].[ProductOrdered]
(
	[Product_Id] INT NOT NULL,
	[Order_Id] INT NOT NULL,
	CONSTRAINT PK_ProductOrder PRIMARY KEY CLUSTERED ([Product_Id]ASC, [Order_Id]ASC), 
	CONSTRAINT FK_ProdOrd_Product_Id FOREIGN KEY (Product_Id) REFERENCES [Product] ([Id]),
	CONSTRAINT FK_ProdOrd_Order_Id FOREIGN KEY (Order_Id) REFERENCES [Order] ([Id])
)