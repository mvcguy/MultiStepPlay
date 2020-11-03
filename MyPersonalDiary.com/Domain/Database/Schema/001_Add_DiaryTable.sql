IF NOT EXISTS (SELECT * FROM sys.Columns WHERE object_id = object_id(N'DiaryNote'))
BEGIN
EXEC sp_executesql N'CREATE TABLE [dbo].[DiaryNote](
		[Id] [uniqueidentifier] NOT NULL,
		[NoteTitle] [nvarchar](500) NULL,
		[Summary] [nvarchar](max) NULL,
		[Details] [nvarchar](max) NULL,
		[CreatedOn] [datetime2](7) NULL,
		[ModifiedOn] [datetime2](7) NULL,
		[CreatedBy] [uniqueidentifier] NULL,
		[ModifiedBy] [uniqueidentifier] NULL,
		[tstamp] [timestamp] NOT NULL,
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
	IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]'
END
GO

IF NOT EXISTS (SELECT * FROM sys.Columns WHERE object_id=object_id(N'DiaryNote') AND name like 'IsDraft')
BEGIN
	EXEC sp_executesql 'ALTER TABLE DiaryNote Add COL IsDraft BIT NULL'
END
GO