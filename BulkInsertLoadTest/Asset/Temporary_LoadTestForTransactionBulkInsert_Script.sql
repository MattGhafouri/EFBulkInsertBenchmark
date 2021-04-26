
create table Temporary_LoadTestForTransactionBulkInsert
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL primary key,
	[GameId] [int] NULL,
	[PlayerId] [int] NULL,
	[RoundId] [varchar](150) NULL,
	[ProviderTransactionId] [varchar](150) NOT NULL,
	[OperationType] [smallint] NOT NULL,
	[Amount] [money] NULL,
	[CurrencyId] [varchar](5) NULL,
	[SessionId] [bigint] NULL,
	[DeviceType] [int] NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[OriginalTxId] [nvarchar](150) NULL,
	[BonusId] [nvarchar](150) NULL,
	[WinType] [tinyint] NULL,
	[Rake] [decimal](10, 4) NULL,
)