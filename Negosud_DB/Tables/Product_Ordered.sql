CREATE TABLE [dbo].[Product_Ordered]
(
	[Product_Id] INT NOT NULL,
	[Order_Id] INT NOT NULL,
	CONSTRAINT PK_Product_Order PRIMARY KEY CLUSTERED ([Product_Id]ASC, [Order_Id]ASC), 
	CONSTRAINT FK_Prod_Ord_Product_Id FOREIGN KEY (Product_Id) REFERENCES [Product] ([Id]),
	CONSTRAINT FK_Prod_Ord_Order_Id FOREIGN KEY (Order_Id) REFERENCES [Order] ([Id])
)