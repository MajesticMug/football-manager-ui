CREATE PROCEDURE dbo.SaveCompetition
(
    @Code VARCHAR(20),
    @Name VARCHAR(125),
    @Teams TeamType READONLY,
    @Players PlayerType READONLY,
    @AreaName VARCHAR(125) = NULL,
    @CompetitionId INT OUTPUT
)
AS
BEGIN
    INSERT  INTO [dbo].[Competition]
    (
            [Name],
            [Code],
            [AreaName]
    )
    SELECT  @Name,
            @Code,
            @AreaName

    SELECT  @CompetitionId = SCOPE_IDENTITY()

    --      Insert Non Existing Teams
    INSERT  INTO [dbo].[Team]
    (
            [Code],
            [Name],
            [Tla],
            [ShortName],
            [Email],
            [AreaName]
    )
    SELECT  [t].[Code],
            [t].[Name],
            [t].[Tla],
            [t].[ShortName],
            [t].[Email],
            [t].[AreaName]
    FROM    @Teams t

    LEFT JOIN [dbo].[Team] existingTeam
    ON      [existingTeam].[Code] = [t].[Code]

    WHERE   [existingTeam].[Id] IS NULL


    --      Insert Competition Teams
    INSERT  INTO [dbo].[CompetitionTeam]
    (
            [CompetitionId],
            [TeamId]
    )
    SELECT  @CompetitionId,
            [existingTeam].[Id]
    FROM    @Teams t

    JOIN    [dbo].[Team] existingTeam
    ON      [existingTeam].[Code] = [t].[Code]


    --      Insert Players
    INSERT  INTO [dbo].[Player]
    (
            [TeamId],
            [Code],
            [Name],
            [Position],
            [DateOfBirth],
            [CountryOfBirth],
            [Nationality]
    )
    SELECT  [t].[Id],
            [p].[Code],
            [p].[Name],
            [p].[Position],
            [p].[DateOfBirth],
            [p].[CountryOfBirth],
            [p].[Nationality]
    FROM    @Players p

    JOIN    [dbo].[Team] t
    ON      [t].[Code] = p.[TeamCode]
END
