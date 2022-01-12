CREATE TABLE [dbo].[Client]
(
	[Users_Id] INT NOT NULL PRIMARY KEY,
	[Address_Id] INT NOT NULL,
	[Email] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Client_User_Id FOREIGN KEY (Users_Id) REFERENCES [Users]([Id]),
	CONSTRAINT FK_Client_Address_Id FOREIGN KEY (Address_Id) REFERENCES [Address]([Id]),
)
