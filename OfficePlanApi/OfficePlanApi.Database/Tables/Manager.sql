CREATE TABLE [dbo].[Manager]
(
    [ManagerId]                              INT             IDENTITY(1, 1) NOT NULL,
    [EmployeeId]                             INT             NOT NULL,
    [ControlledDepartmentId]                 INT             NOT NULL,
    [CreatedOn]                              DATETIME        NOT NULL,
    [CreatedBy]                              INT             NOT NULL,
    [ModifiedOn]                             DATETIME        NOT NULL,
    [ModifiedBy]                             INT             NOT NULL,
    [Deleted]                                BIT             NULL,
    [DeletedOn]                              DATETIME        NULL,
    [DeletedBy]                              INT             NULL,

    CONSTRAINT [pkManager] PRIMARY KEY CLUSTERED ([ManagerId] ASC),
    CONSTRAINT [fkManager_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([EmployeeId]),
    CONSTRAINT [fkManager_Department] FOREIGN KEY ([ControlledDepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId])
)
