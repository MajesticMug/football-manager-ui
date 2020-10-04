CREATE TABLE [dbo].[TeamPlayer]
(
    [TeamId] INT NOT NULL,
    [PlayerId] INT NOT NULL
)
GO

ALTER TABLE [dbo].[TeamPlayer] ADD CONSTRAINT [PK_TeamId_PlayerId] PRIMARY KEY CLUSTERED ([TeamId], [PlayerId])
GO

ALTER TABLE [dbo].[TeamPlayer] ADD CONSTRAINT [FK_TeamPlayer_TeamId_Team_Id] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team]([Id])
GO

ALTER TABLE [dbo].[TeamPlayer] ADD CONSTRAINT [FK_TeamPlayer_PlayerId_Player_Id] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player]([Id])
GO
