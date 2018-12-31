BEGIN TRANSACTION
GO

ALTER TABLE dbo.CS_Sliders ADD
	[Key] [nvarchar](500) NOT NULL,
	IsEditable [bit] NOT NULL
GO


ALTER TABLE dbo.CS_Sliders
	DROP COLUMN Slug_ar,
				Slug_en,
				MainImage_en,
				MainImage_ar,
				Section_en,
				Section_ar,
				Tags_en,
				Tags_ar
GO 

ALTER TABLE dbo.CS_Sliders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT