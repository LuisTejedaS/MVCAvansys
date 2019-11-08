CREATE TABLE [dbo].[Student]
(
	  [ID]               UNIQUEIDENTIFIER NOT NULL,
	  [Name]             NVARCHAR (100)   NULL,
	  [CareerID]  UNIQUEIDENTIFIER NOT NULL,
	
	CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([ID] ASC), 
	CONSTRAINT [FK_Student_Career_CareerID] FOREIGN KEY ([CareerID]) REFERENCES [dbo].[Career] ([ID])
)
