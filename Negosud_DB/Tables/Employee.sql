CREATE TABLE [dbo].[Employee]
(
	[Users_Id] INT NOT NULL PRIMARY KEY,
	[Position] NVARCHAR(255) NOT NULL,
	CONSTRAINT FK_Employee_User_Id FOREIGN KEY (Users_Id) REFERENCES [Users]([Id])
)
