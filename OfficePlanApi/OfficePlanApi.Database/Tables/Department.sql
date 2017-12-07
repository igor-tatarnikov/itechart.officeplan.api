CREATE TABLE [dbo].[Department]
(
    [DepartmentId]                           INT             IDENTITY(1, 1) NOT NULL,
    [Name]                                   NVARCHAR(100)   NULL,
    [CreatedOn]                              DATETIME        NOT NULL,
    [CreatedBy]                              INT             NOT NULL,
    [ModifiedOn]                             DATETIME        NOT NULL,
    [ModifiedBy]                             INT             NOT NULL,
    [Deleted]                                BIT             NULL,
    [DeletedOn]                              DATETIME        NULL,
    [DeletedBy]                              INT             NULL,

    CONSTRAINT [pkDepartment] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
)
