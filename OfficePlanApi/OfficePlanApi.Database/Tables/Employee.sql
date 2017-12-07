CREATE TABLE [dbo].[Employee]
(
    [EmployeeId]                             INT             IDENTITY(1, 1) NOT NULL,
    [SmgUserId]                              INT             NOT NULL,
    [FirstName]                              NVARCHAR(100)   NOT NULL,
    [LastName]                               NVARCHAR(100)   NOT NULL,
    [PhotoUrl]                               NVARCHAR(200)   NULL,
    [DepartmentId]                           INT             NOT NULL,
    [CreatedOn]                              DATETIME        NOT NULL,
    [CreatedBy]                              INT             NOT NULL,
    [ModifiedOn]                             DATETIME        NOT NULL,
    [ModifiedBy]                             INT             NOT NULL,
    [Deleted]                                BIT             NULL,
    [DeletedOn]                              DATETIME        NULL,
    [DeletedBy]                              INT             NULL,

    CONSTRAINT [pkEmployee] PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    CONSTRAINT [fkEmployee_Department] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId])
)
