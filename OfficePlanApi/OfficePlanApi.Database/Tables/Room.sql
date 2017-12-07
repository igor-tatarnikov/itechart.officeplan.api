CREATE TABLE [dbo].[Room]
(
    [RoomId]                                 INT             IDENTITY(1, 1) NOT NULL,
    [OfficeId]                               INT             NOT NULL,
    [ResponsibleManagerId]                   INT             NOT NULL,
    [Name]                                   NVARCHAR(100)   NOT NULL,
    [CreatedOn]                              DATETIME        NOT NULL,
    [CreatedBy]                              INT             NOT NULL,
    [ModifiedOn]                             DATETIME        NOT NULL,
    [ModifiedBy]                             INT             NOT NULL,
    [Deleted]                                BIT             NULL,
    [DeletedOn]                              DATETIME        NULL,
    [DeletedBy]                              INT             NULL,

    CONSTRAINT [pkRoom] PRIMARY KEY CLUSTERED ([RoomId] ASC),
    CONSTRAINT [fkRoom_Office] FOREIGN KEY ([OfficeId]) REFERENCES [dbo].[Office] ([OfficeId]),
    CONSTRAINT [fkRoom_Manager] FOREIGN KEY ([ResponsibleManagerId]) REFERENCES [dbo].[Manager] ([ManagerId])
)
