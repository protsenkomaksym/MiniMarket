USE [MiniMarket]
GO
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_Items_Categories]
GO
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF_Items_created]
GO
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF_Categories_created]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 12/5/2022 17:17:43 ******/
DROP TABLE [dbo].[Items]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/5/2022 17:17:43 ******/
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/5/2022 17:17:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 12/5/2022 17:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
	[idCategory] [int] NOT NULL,
	[created] [datetime] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_created]  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_created]  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories] FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories]
GO
