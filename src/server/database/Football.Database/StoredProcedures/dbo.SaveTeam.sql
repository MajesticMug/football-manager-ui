CREATE PROCEDURE dbo.SaveTeamPlayers
(
    @TeamCode VARCHAR(20),
    @Players PlayerType READONLY
)
AS
BEGIN
    DECLARE @TeamId INT

    SELECT  @TeamId = [t].[Id]
    FROM    [dbo].[Team] t
    WHERE   [t].[Code] = @TeamCode

    --      Insert Non Existing Players
    INSERT  INTO [dbo].[Player]
    (
            [Code],
            [Name],
            [Position],
            [DateOfBirth],
            [CountryOfBirth],
            [Nationality]
    )
    SELECT  [p].[Code],
            [p].[Name],
            [p].[Position],
            [p].[DateOfBirth],
            [p].[CountryOfBirth],
            [p].[Nationality]
    FROM    @Players p

    LEFT JOIN [dbo].[Player] existingPlayer
    ON      [existingPlayer].[Code] = [p].[Code]

    WHERE   [existingPlayer].[Id] IS NULL


    --      Insert TeamPlayers
    INSERT  INTO [dbo].[TeamPlayer]
    (
            [TeamId],
            [PlayerId]
    )
    SELECT  DISTINCT
            @TeamId,
            [existingPlayer].[Id]
    FROM    @Players p

    JOIN    [dbo].[Player] existingPlayer
    ON      [existingPlayer].[Code] = [p].[Code]
END
