CREATE TABLE [dbo].[Furniture]
(
    [FurnitureId]                            INT             IDENTITY(1, 1) NOT NULL,
    [RoomObjectId]                           INT             NOT NULL,
    [Type]                                   TINYINT         NOT NULL,
    [Rotation]                               FLOAT           NOT NULL,
    [CreatedOn]                              DATETIME        NOT NULL,
    [CreatedBy]                              INT             NOT NULL,
    [ModifiedOn]                             DATETIME        NOT NULL,
    [ModifiedBy]                             INT             NOT NULL,
    [Deleted]                                BIT             NULL,
    [DeletedOn]                              DATETIME        NULL,
    [DeletedBy]                              INT             NULL,

    CONSTRAINT [pkFurniture] PRIMARY KEY CLUSTERED ([FurnitureId] ASC),
    CONSTRAINT [fkFurniture_RoomObject] FOREIGN KEY ([RoomObjectId]) REFERENCES [dbo].[RoomObject] ([RoomObjectId])
)
