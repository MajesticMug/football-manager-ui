CREATE TABLE [dbo].[CompetitionTeam]
(
    [CompetitionId] INT NOT NULL,
    [TeamId] INT NOT NULL
)
GO

ALTER TABLE [dbo].[CompetitionTeam] ADD CONSTRAINT [PK_CompetitionTeam_CompetitionId_TeamId] PRIMARY KEY CLUSTERED ([CompetitionId], [TeamId])
GO

ALTER TABLE [dbo].[CompetitionTeam] ADD CONSTRAINT [FK_CompetitionTeam_CompetitionId] FOREIGN KEY ([CompetitionId]) REFERENCES [dbo].[Competition]([Id])
GO

ALTER TABLE [dbo].[CompetitionTeam] ADD CONSTRAINT [FK_CompetitionTeam_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team]([Id])
GO
