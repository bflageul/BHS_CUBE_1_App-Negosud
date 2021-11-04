CREATE TABLE [dbo].[Order_History]
(
	[Users_Id] INT NOT NULL,
	[Order_Id] INT NOT NULL,
	CONSTRAINT PK_Order_History primary key clustered (Users_Id, Order_Id),
	CONSTRAINT PK_Order_History_Users_Id FOREIGN key (Users_Id) REFERENCES [Users] ([Id]),
	CONSTRAINT PK_Order_History_Order_Id FOREIGN key (Order_Id) REFERENCES [Order] ([Id])
)
