USE [ItunesSearchDb]
GO

SET ANSI_NULLS ON
GO


create table SearchResultCounter (

	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TrackID] [varchar] (100) NOT NULL,
	[TrackName] [varchar] (100) NOT NULL,
	[ArtistName] [varchar] (100) NOT NULL, 
	[Category] [varchar] (100) NOT NULL,
	[ClickCount] [bigint] NOT NULL,
	[UserIP] [varchar] (100) NOT NULL,
	[UserAgent] [varchar] (500) NOT NULL,
	[RowCreateTS] [datetime] NOT NULL,
	[RowMaintainedTS] [datetime] NOT NULL,
	CONSTRAINT [pkSearchResultCounterOnId] PRIMARY KEY CLUSTERED
	(
	[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
	) ON [PRIMARY]

	GO