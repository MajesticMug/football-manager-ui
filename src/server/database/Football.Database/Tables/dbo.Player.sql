CREATE TABLE [dbo].[Player]
(
    [Id] INT IDENTITY(1, 1),
    [Code] VARCHAR(20) NOT NULL,
    [Name] VARCHAR(125) NOT NULL,
    [Position] VARCHAR(50) NULL,
    [DateOfBirth] DATETIME NULL,
    [CountryOfBirth] VARCHAR(50) NOT NULL,
    [Nationality] VARCHAR(50) NOT NULL
)
GO

ALTER TABLE [dbo].[Player] ADD CONSTRAINT [PK_Player_Id] PRIMARY KEY CLUSTERED ([Id])
GO

CREATE UNIQUE INDEX [udx_Code] ON [dbo].[Player]([Code])
GO
