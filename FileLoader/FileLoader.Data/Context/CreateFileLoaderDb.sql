
GO

/****** Object:  Table [dbo].[Counties]    Script Date: 10/24/2014 14:44:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Counties](
	[CountyCode] [nvarchar](3) NOT NULL,
	[CountyDesc] [nvarchar](25) NOT NULL
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[VotersStage]    Script Date: 10/24/2014 14:42:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VotersStage](
	[CountyCode] [nvarchar](3) NOT NULL,
	[VoterId] [int] NOT NULL,
	[LastName] [nvarchar](30) NULL,
	[SuffixName] [nvarchar](5) NULL,
	[FirstName] [nvarchar](30) NULL,
	[MiddleName] [nvarchar](30) NULL,
	[SuppressAddress] [nvarchar](1) NULL,
	[ResidenceAddress1] [nvarchar](50) NULL,
	[ResidenceAddress2] [nvarchar](50) NULL,
	[ResidenceCity] [nvarchar](50) NULL,
	[ResidenceState] [nvarchar](2) NULL,
	[ResidenceZipCode] [nvarchar](12) NULL,
	[MailingAddress1] [nvarchar](50) NULL,
	[MailingAddress2] [nvarchar](50) NULL,
	[MailingAddress3] [nvarchar](50) NULL,
	[MailingCity] [nvarchar](50) NULL,
	[MailingState] [nvarchar](2) NULL,
	[MailingZipCode] [nvarchar](12) NULL,
	[MailingCountry] [nvarchar](50) NULL,
	[Gender] [nvarchar](1) NULL,
	[Race] [nvarchar](1) NULL,
	[BirthDate] [datetime] NULL,
	[RegistrationDate] [datetime] NULL,
	[PartyAffiliation] [nvarchar](3) NULL,
	[Precinct] [nvarchar](10) NULL,
	[PrecinctGroup] [nvarchar](5) NULL,
	[PrecinctSplit] [nvarchar](10) NULL,
	[PrecinctSuffix] [nvarchar](5) NULL,
	[VoterStatus] [nvarchar](3) NULL,
	[CongressionalDistrict] [nvarchar](3) NULL,
	[HouseDistrict] [nvarchar](3) NULL,
	[SenateDistrict] [nvarchar](3) NULL,
	[CountyCommissionDistrict] [nvarchar](3) NULL,
	[SchoolBoardDistrict] [nvarchar](3) NULL,
	[DaytimeAreaCode] [nvarchar](3) NULL,
	[DaytimePhoneNumber] [nvarchar](7) NULL,
	[DaytimePhoneExtension] [nvarchar](5) NULL,
	[EmailAddress] [nvarchar](100) NULL,
 CONSTRAINT [PK_VotersStage_1] PRIMARY KEY CLUSTERED 
(
	[VoterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO

/****** Object:  Table [dbo].[Voters]    Script Date: 10/24/2014 14:42:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Voters](
	[CountyCode] [nvarchar](3) NOT NULL,
	[VoterId] [int] NOT NULL,
	[LastName] [nvarchar](30) NULL,
	[SuffixName] [nvarchar](5) NULL,
	[FirstName] [nvarchar](30) NULL,
	[MiddleName] [nvarchar](30) NULL,
	[SuppressAddress] [nvarchar](1) NULL,
	[ResidenceAddress1] [nvarchar](50) NULL,
	[ResidenceAddress2] [nvarchar](50) NULL,
	[ResidenceCity] [nvarchar](50) NULL,
	[ResidenceState] [nvarchar](2) NULL,
	[ResidenceZipCode] [nvarchar](12) NULL,
	[MailingAddress1] [nvarchar](50) NULL,
	[MailingAddress2] [nvarchar](50) NULL,
	[MailingAddress3] [nvarchar](50) NULL,
	[MailingCity] [nvarchar](50) NULL,
	[MailingState] [nvarchar](2) NULL,
	[MailingZipCode] [nvarchar](12) NULL,
	[MailingCountry] [nvarchar](50) NULL,
	[Gender] [nvarchar](1) NULL,
	[Race] [nvarchar](1) NULL,
	[BirthDate] [datetime] NULL,
	[RegistrationDate] [datetime] NULL,
	[PartyAffiliation] [nvarchar](3) NULL,
	[Precinct] [nvarchar](10) NULL,
	[PrecinctGroup] [nvarchar](5) NULL,
	[PrecinctSplit] [nvarchar](10) NULL,
	[PrecinctSuffix] [nvarchar](5) NULL,
	[VoterStatus] [nvarchar](3) NULL,
	[CongressionalDistrict] [nvarchar](3) NULL,
	[HouseDistrict] [nvarchar](3) NULL,
	[SenateDistrict] [nvarchar](3) NULL,
	[CountyCommissionDistrict] [nvarchar](3) NULL,
	[SchoolBoardDistrict] [nvarchar](3) NULL,
	[DaytimeAreaCode] [nvarchar](3) NULL,
	[DaytimePhoneNumber] [nvarchar](7) NULL,
	[DaytimePhoneExtension] [nvarchar](5) NULL,
	[EmailAddress] [nvarchar](100) NULL,
 CONSTRAINT [PK_Voters] PRIMARY KEY CLUSTERED 
(
	[VoterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

insert into Counties Values ('ALA','Alachua')
insert into Counties Values ('BAK','Baker')
insert into Counties Values ('BAY','Bay')
insert into Counties Values ('BRA','Bradford')
insert into Counties Values ('BRE','Brevard')
insert into Counties Values ('BRO','Broward')
insert into Counties Values ('CAL','Calhoun')
insert into Counties Values ('CHA','Charlotte')
insert into Counties Values ('CIT','Citrus')
insert into Counties Values ('CLA','Clay')
insert into Counties Values ('CLL','Collier')
insert into Counties Values ('CLM','Columbia')
insert into Counties Values ('DAD','Miami-Dade')
insert into Counties Values ('DES','DeSoto')
insert into Counties Values ('DIX','Dixie')
insert into Counties Values ('DUV','Duval')
insert into Counties Values ('ESC','Escambia')
insert into Counties Values ('FLA','Flagler')
insert into Counties Values ('FRA','Franklin')
insert into Counties Values ('GAD','Gadsden')
insert into Counties Values ('GIL','Gilchrist')
insert into Counties Values ('GLA','Glades')
insert into Counties Values ('GUL','Gulf')
insert into Counties Values ('HAM','Hamilton')
insert into Counties Values ('HAR','Hardee')
insert into Counties Values ('HEN','Hendry')
insert into Counties Values ('HER','Hernando')
insert into Counties Values ('HIG','Highlands')
insert into Counties Values ('HIL','Hillsborough')
insert into Counties Values ('HOL','Holmes')
insert into Counties Values ('IND','Indian River')
insert into Counties Values ('JAC','Jackson')
insert into Counties Values ('JEF','Jefferson')
insert into Counties Values ('LAF','Lafayette')
insert into Counties Values ('LAK','Lake')
insert into Counties Values ('LEE','Lee')
insert into Counties Values ('LEO','Leon')
insert into Counties Values ('LEV','Levy')
insert into Counties Values ('LIB','Liberty')
insert into Counties Values ('MAD','Madison')
insert into Counties Values ('MAN','Manatee')
insert into Counties Values ('MON','Monroe')
insert into Counties Values ('MRN','Marion')
insert into Counties Values ('MRT','Martin')
insert into Counties Values ('NAS','Nassau')
insert into Counties Values ('OKA','Okaloosa')
insert into Counties Values ('OKE','Okeechobee')
insert into Counties Values ('ORA','Orange')
insert into Counties Values ('OSC','Osceola')
insert into Counties Values ('PAL','Palm Beach')
insert into Counties Values ('PAS','Pasco')
insert into Counties Values ('PIN','Pinellas')
insert into Counties Values ('POL','Polk')
insert into Counties Values ('PUT','Putnam')
insert into Counties Values ('SAN','Santa Rosa')
insert into Counties Values ('SAR','Sarasota')
insert into Counties Values ('SEM','Seminole')
insert into Counties Values ('STJ','St. Johns')
insert into Counties Values ('STL','St. Lucie')
insert into Counties Values ('SUM','Sumter')
insert into Counties Values ('SUW','Suwannee')
insert into Counties Values ('TAY','Taylor')
insert into Counties Values ('UNI','Union')
insert into Counties Values ('VOL','Volusia')
insert into Counties Values ('WAK','Wakulla')
insert into Counties Values ('WAL','Walton')
insert into Counties Values ('WAS','Washington')
