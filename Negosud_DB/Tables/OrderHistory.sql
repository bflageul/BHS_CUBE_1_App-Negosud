CREATE TABLE [dbo].[OrderHistory]
(
	[Users_Id] INT NOT NULL,
	[Order_Id] INT NOT NULL,
	CONSTRAINT PK_OrderHistory primary key clustered (Users_Id, Order_Id),
	CONSTRAINT PK_OrderHistory_Users_Id FOREIGN key (Users_Id) REFERENCES [Users] ([Id]),
	CONSTRAINT PK_OrderHistory_Order_Id FOREIGN key (Order_Id) REFERENCES [Order] ([Id])
)
