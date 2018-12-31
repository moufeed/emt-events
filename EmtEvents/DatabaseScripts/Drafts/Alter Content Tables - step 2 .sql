

Update CS_Galleries SET Published_en = 'true';
ALTER TABLE [CS_Galleries] ALTER COLUMN [Published_en] bit NOT NULL;



Update CS_Galleries SET Published_ar = 'true';
ALTER TABLE [CS_Galleries] ALTER COLUMN [Published_ar] bit NOT NULL;



Update CS_Pages SET Published_en = 'true';
ALTER TABLE [CS_Pages] ALTER COLUMN [Published_en] bit NOT NULL;



Update CS_Pages SET Published_ar = 'true';
ALTER TABLE [CS_Pages] ALTER COLUMN [Published_ar] bit NOT NULL;



Update CS_Services SET Published_en = 'true';
ALTER TABLE [CS_Services] ALTER COLUMN [Published_en] bit NOT NULL;



Update CS_Services SET Published_ar = 'true';
ALTER TABLE [CS_Services] ALTER COLUMN [Published_ar] bit NOT NULL;



Update CS_Menus SET Published_en = 'true';
ALTER TABLE [CS_Menus] ALTER COLUMN [Published_en] bit NOT NULL;



Update CS_Menus SET Published_ar = 'true';
ALTER TABLE [CS_Menus] ALTER COLUMN [Published_ar] bit NOT NULL;



Update CS_Sliders SET Published_en = 'true';
ALTER TABLE [CS_Sliders] ALTER COLUMN [Published_en] bit NOT NULL;



Update CS_Sliders SET Published_ar = 'true';
ALTER TABLE [CS_Sliders] ALTER COLUMN [Published_ar] bit NOT NULL;



Update CS_Sliders SET [Key] = 'key';
ALTER TABLE [CS_Sliders] ALTER COLUMN [Key] nvarchar(500) NOT NULL;



Update CS_Sliders SET [IsEditable] = 'true';
ALTER TABLE [CS_Sliders] ALTER COLUMN [IsEditable] bit NOT NULL;

 