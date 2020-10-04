CREATE TABLE [dbo].[Team]
(
    [Id] INT IDENTITY(1, 1),
    [Code] VARCHAR(20) NOT NULL,
    [Name] VARCHAR(125) NOT NULL,
    [Tla] VARCHAR(3) NOT NULL,
    [ShortName] VARCHAR(20) NULL,
    [Email] VARCHAR(125) NULL,
    [AreaName] VARCHAR(125) NULL
)
GO

ALTER TABLE [dbo].[Team] ADD CONSTRAINT [PK_Team_Id] PRIMARY KEY CLUSTERED ([Id])
GO

CREATE UNIQUE INDEX [udx_Code] ON [dbo].[Team]([Code])
GO
