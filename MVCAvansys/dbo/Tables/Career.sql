CREATE TABLE [dbo].[Career]
(
	  [ID]               UNIQUEIDENTIFIER NOT NULL,
	  [Name]             NVARCHAR (100)   NULL, 

	CONSTRAINT [PK_Career] PRIMARY KEY CLUSTERED ([ID] ASC), 

)
