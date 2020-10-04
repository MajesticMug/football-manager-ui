CREATE TABLE [dbo].[Competition]
(
    [Id] INT IDENTITY(1, 1),
    [Name] VARCHAR(125) NOT NULL,
    [Code] VARCHAR(20) NOT NULL,
    [AreaName] VARCHAR(125) NULL
)
GO

ALTER TABLE [dbo].[Competition] ADD CONSTRAINT [PK_Competition_Id] PRIMARY KEY CLUSTERED ([Id])
GO

CREATE UNIQUE INDEX [udx_Code] ON [dbo].[Competition]([Code])
GO
