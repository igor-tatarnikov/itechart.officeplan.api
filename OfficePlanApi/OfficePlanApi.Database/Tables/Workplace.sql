CREATE TABLE [dbo].[Workplace]
(
    [WorkplaceId]                            INT             IDENTITY(1, 1) NOT NULL,
    [RoomObjectId]                           INT             NOT NULL,
    [AssignedEmployeeId]                     INT             NULL,
    [CreatedOn]                              DATETIME        NOT NULL,
    [CreatedBy]                              INT             NOT NULL,
    [ModifiedOn]                             DATETIME        NOT NULL,
    [ModifiedBy]                             INT             NOT NULL,
    [Deleted]                                BIT             NULL,
    [DeletedOn]                              DATETIME        NULL,
    [DeletedBy]                              INT             NULL,

    CONSTRAINT [pkWorkplace] PRIMARY KEY CLUSTERED ([WorkplaceId] ASC),
    CONSTRAINT [fkWorkplace_RoomObject] FOREIGN KEY ([RoomObjectId]) REFERENCES [dbo].[RoomObject] ([RoomObjectId]),
    CONSTRAINT [fkWorkplace_Employee] FOREIGN KEY ([AssignedEmployeeId]) REFERENCES [dbo].[Employee] ([EmployeeId])
)
