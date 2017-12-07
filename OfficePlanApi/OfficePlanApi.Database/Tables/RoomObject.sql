CREATE TABLE [dbo].[RoomObject]
(
    [RoomObjectId]                           INT             IDENTITY(1, 1) NOT NULL,
    [RoomId]                                 INT             NOT NULL,
    [CoordinateX]                            INT             NOT NULL,
    [CoordinateY]                            INT             NOT NULL,
    [CreatedOn]                              DATETIME        NOT NULL,
    [CreatedBy]                              INT             NOT NULL,
    [ModifiedOn]                             DATETIME        NOT NULL,
    [ModifiedBy]                             INT             NOT NULL,
    [Deleted]                                BIT             NULL,
    [DeletedOn]                              DATETIME        NULL,
    [DeletedBy]                              INT             NULL,

    CONSTRAINT [pkRoomObject] PRIMARY KEY CLUSTERED ([RoomObjectId] ASC),
    CONSTRAINT [fkRoomObject_Room] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([RoomId])
)
