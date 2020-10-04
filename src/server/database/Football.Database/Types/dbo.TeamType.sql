CREATE TYPE [dbo].[TeamType] AS TABLE
(
    [Code] VARCHAR(20) NOT NULL,
    [Name] VARCHAR(125) NOT NULL,
    [Tla] VARCHAR(3) NOT NULL,
    [ShortName] VARCHAR(20) NULL,
    [Email] VARCHAR(125) NULL,
    [AreaName] VARCHAR(125) NULL
)
