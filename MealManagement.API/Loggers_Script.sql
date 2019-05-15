 CREATE TABLE [dbo].[Log] (
	  [Id] [int] IDENTITY(1,1) NOT NULL,
	  [Logged] [datetime] NOT NULL,
	  [Level] [nvarchar](50) NOT NULL,
	  [Message] [nvarchar](max) NOT NULL,
	  [Username] [nvarchar](250) NULL,
	  [Url] [nvarchar](250) NULL,
	  [Exception] [nvarchar](max) NULL);

