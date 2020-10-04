CREATE PROCEDURE dbo.SaveCompetition
(
    @Code VARCHAR(20),
    @Name VARCHAR(125),
    @Teams TeamType READONLY,
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
    SELECT  DISTINCT
            @CompetitionId,
            [existingTeam].[Id]
    FROM    @Teams t

    JOIN    [dbo].[Team] existingTeam
    ON      [existingTeam].[Code] = [t].[Code]
END
