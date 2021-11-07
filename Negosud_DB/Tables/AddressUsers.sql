CREATE TABLE [dbo].[AddressUsers] (
    [Users_Id]    INT NOT NULL,
    [Address_Id] INT NOT NULL,
    CONSTRAINT [PK_AddressUsers] PRIMARY KEY CLUSTERED ([Address_Id] ASC, [Users_Id] ASC),
    CONSTRAINT [FK_AddressUsers_Users_Id] FOREIGN KEY ([Users_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_AddressUsers_Address_Id] FOREIGN KEY ([Address_Id]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);