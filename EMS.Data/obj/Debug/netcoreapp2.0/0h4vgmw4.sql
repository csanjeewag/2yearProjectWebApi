IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [departments] (
    [DprtId] nvarchar(450) NOT NULL,
    [DprtName] nvarchar(max) NULL,
    CONSTRAINT [PK_departments] PRIMARY KEY ([DprtId])
);

GO

CREATE TABLE [positions] (
    [PId] nvarchar(450) NOT NULL,
    [PName] nvarchar(max) NULL,
    [Roles] nvarchar(max) NULL,
    CONSTRAINT [PK_positions] PRIMARY KEY ([PId])
);

GO

CREATE TABLE [emps] (
    [EmpId] nvarchar(450) NOT NULL,
    [DepartmentDprtId] nvarchar(450) NULL,
    [EmpAddress] nvarchar(max) NULL,
    [EmpContact] nvarchar(max) NULL,
    [EmpEmail] nvarchar(max) NULL,
    [EmpName] nvarchar(max) NULL,
    [EmpPassword] nvarchar(max) NULL,
    [PositionPId] nvarchar(450) NULL,
    CONSTRAINT [PK_emps] PRIMARY KEY ([EmpId]),
    CONSTRAINT [FK_emps_departments_DepartmentDprtId] FOREIGN KEY ([DepartmentDprtId]) REFERENCES [departments] ([DprtId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_emps_positions_PositionPId] FOREIGN KEY ([PositionPId]) REFERENCES [positions] ([PId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_emps_DepartmentDprtId] ON [emps] ([DepartmentDprtId]);

GO

CREATE INDEX [IX_emps_PositionPId] ON [emps] ([PositionPId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181005053552_add1', N'2.0.2-rtm-10011');

GO

