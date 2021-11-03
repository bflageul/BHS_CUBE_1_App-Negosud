CREATE TABLE [dbo].[Address_Users] (
    [Users_Id]    INT NOT NULL,
    [Address_Id] INT NOT NULL,
    CONSTRAINT [PK_Address_Users] PRIMARY KEY CLUSTERED ([Address_Id] ASC, [Users_Id] ASC),
    CONSTRAINT [FK_Users_Id] FOREIGN KEY ([Users_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Address] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);