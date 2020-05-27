CREATE TABLE [dbo].[Questions]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Id_Answers] INT NOT NULL, 
    [Id_Exams] INT NOT NULL, 
    [Label] VARCHAR(MAX) NULL, 
    [Type] INT NULL, 
)

CREATE TABLE [dbo].[Answers] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Correct]    VARCHAR (MAX) DEFAULT ((0)) NOT NULL,
    [Statements] VARCHAR (MAX) DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50)  NOT NULL,
    [Firstname] VARCHAR (50)  NOT NULL,
    [Roles]     BIT           NOT NULL,
    [Email]     VARCHAR (MAX) NOT NULL,
    [Password]  VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users_Exams]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [User] INT NOT NULL, 
    [Exams] INT NOT NULL, 
    [Score] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Tries] INT NOT NULL
)

CREATE TABLE [dbo].[Exams] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Label]        VARCHAR (50) NOT NULL,
    [NbrQuestions] INT          NOT NULL,
    [Time]         INT          NOT NULL,
    [End_Date]     DATETIME         NOT NULL,
    [Tries]        INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);