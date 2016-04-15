CREATE TABLE [dbo].[CommentTable] (
    [TopicId]      CHAR (4)       NOT NULL,
    [No]           INT            NOT NULL,
    [Comment]      NVARCHAR (300) NULL,
    [InsertUserId] INT            NULL,
    [InsertDate]   DATE           NULL,
    PRIMARY KEY CLUSTERED ([TopicId] ASC, [No] ASC)
);

