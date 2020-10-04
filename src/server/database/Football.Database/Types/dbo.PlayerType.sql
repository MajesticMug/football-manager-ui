CREATE TYPE [dbo].[PlayerType] AS TABLE
(
    [Code] VARCHAR(20) NOT NULL,
    [Name] VARCHAR(125) NOT NULL,
    [Position] VARCHAR(50) NULL,
    [DateOfBirth] DATETIME NULL,
    [CountryOfBirth] VARCHAR(50) NOT NULL,
    [Nationality] VARCHAR(50) NOT NULL
)
