CREATE TABLE [dbo].[TopicTable] (
    [TopicId]      CHAR (4)       NOT NULL,
    [Title]        NVARCHAR (100) NULL,
    [Detail]       NVARCHAR (MAX) NULL,
    [InsertUserId] INT            NULL,
    [InsertDate]   DATE           NULL,
    PRIMARY KEY CLUSTERED ([TopicId] ASC)
);

