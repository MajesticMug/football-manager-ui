CREATE TABLE [dbo].[Player]
(
    [Id] INT IDENTITY(1, 1),
    [TeamId] INT NOT NULL,
    [Code] VARCHAR(20) NOT NULL,
    [Position] VARCHAR(50) NOT NULL,
    [DateOfBirth] DATETIME NOT NULL,
    [CountryOfBirth] VARCHAR(50) NOT NULL,
    [Nationality] VARCHAR(50) NOT NULL
)
GO

ALTER TABLE [dbo].[Player] ADD CONSTRAINT [PK_Player_Id] PRIMARY KEY CLUSTERED ([Id])
GO

ALTER TABLE [dbo].[Player] ADD CONSTRAINT [FK_Player_TeamId_Team_Id] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team]([Id])
GO

CREATE UNIQUE INDEX [udx_Code] ON [dbo].[Player]([Code])
GO
