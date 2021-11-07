CREATE TABLE [dbo].[Users]
(
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (255)  NOT NULL,
    [Firstname]    NVARCHAR (255)  NOT NULL,
    [Lastname]     NVARCHAR (255)  NOT NULL,
    [HashPassword] VARBINARY (255) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
)