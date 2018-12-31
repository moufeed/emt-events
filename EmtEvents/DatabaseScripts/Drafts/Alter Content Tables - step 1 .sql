BEGIN TRANSACTION
GO
 
 
 
PRINT '-----------------------------------  Gallery  --------------------------------------------'
PRINT ''
ALTER TABLE CS_Galleries ADD
	Published_en bit,
	Published_ar bit,
	MetaDescription_en nvarchar(500),
	MetaDescription_ar nvarchar(500),
    SEOMarkup nvarchar(MAX)
 GO 
PRINT 'Added Columns To CS_Galleries Table'
PRINT ''
ALTER TABLE CS_Galleries
DROP COLUMN Published;
GO   
PRINT 'Remove Columns From CS_Galleries Table' 
PRINT ''
 
Update CS_Galleries SET Published_en = 'true';
GO   
ALTER TABLE [CS_Galleries] ALTER COLUMN [Published_en] bit NOT NULL;
GO   



Update CS_Galleries SET Published_ar = 'true';
GO   
ALTER TABLE [CS_Galleries] ALTER COLUMN [Published_ar] bit NOT NULL;
GO   
PRINT 'Set New Columns NOT NULL' 
PRINT ''

PRINT '----------------------------------- End Gallery Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'
 

PRINT ''
PRINT ''
PRINT ''
PRINT ''
 
 
PRINT '-----------------------------------   Page  --------------------------------------------'
 PRINT ''
ALTER TABLE CS_Pages ADD
	Published_en bit,
	Published_ar bit,
	MetaDescription_en nvarchar(500),
	MetaDescription_ar nvarchar(500),
    SEOMarkup nvarchar(MAX)
GO  
PRINT 'Added Columns To CS_Pages Table'
PRINT '' 
ALTER TABLE CS_Pages
DROP COLUMN Published;
GO   
PRINT 'Remove Columns From CS_Pages Table'

PRINT '' 

Update CS_Pages SET Published_en = 'true';
GO   
ALTER TABLE [CS_Pages] ALTER COLUMN [Published_en] bit NOT NULL;
GO   



Update CS_Pages SET Published_ar = 'true';
GO   
ALTER TABLE [CS_Pages] ALTER COLUMN [Published_ar] bit NOT NULL;
GO   
 

PRINT 'Set New Columns NOT NULL' 
PRINT ''
PRINT '----------------------------------- End Page  Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'
 

PRINT ''
PRINT ''
PRINT ''
PRINT ''
 
 
PRINT '-----------------------------------   Service  --------------------------------------------'
PRINT ''

ALTER TABLE CS_Services ADD
	Published_en bit,
	Published_ar bit,
	MetaDescription_en nvarchar(500),
	MetaDescription_ar nvarchar(500),
    SEOMarkup nvarchar(MAX)
GO   
PRINT 'Added Columns To CS_Services Table'
PRINT '' 
ALTER TABLE CS_Services
DROP COLUMN Published;
GO   
PRINT 'Remove Columns From CS_Services Table' 
PRINT ''


Update CS_Services SET Published_en = 'true';
GO   
ALTER TABLE [CS_Services] ALTER COLUMN [Published_en] bit NOT NULL;
GO   



Update CS_Services SET Published_ar = 'true';
GO   
ALTER TABLE [CS_Services] ALTER COLUMN [Published_ar] bit NOT NULL;
GO   


PRINT 'Set New Columns NOT NULL' 
PRINT ''
PRINT '----------------------------------- End Service  Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'
 

PRINT ''
PRINT ''
PRINT ''
PRINT ''
 
 
PRINT '-----------------------------------   Slider  --------------------------------------------'
PRINT ''

ALTER TABLE CS_Sliders ADD
	Published_en bit,
	Published_ar bit ,
	[Key] nvarchar(500),
	[IsEditable] bit
GO   
 PRINT 'Added Columns To CS_Sliders Table'
 PRINT '' 
 ALTER TABLE CS_Sliders	DROP COLUMN  
	Published,
	Slug_en, 
	Slug_ar,   
	MainImage_en, 
	MainImage_ar, 
	Section_en, 
	Section_ar, 
	Tags_en, 
	Tags_ar,
	Position
GO   
PRINT 'Remove Columns From CS_Sliders Table' 
PRINT ''


Update CS_Sliders SET Published_en = 'true';
GO   
ALTER TABLE [CS_Sliders] ALTER COLUMN [Published_en] bit NOT NULL;
GO   



Update CS_Sliders SET Published_ar = 'true';
GO   
ALTER TABLE [CS_Sliders] ALTER COLUMN [Published_ar] bit NOT NULL;
GO   



Update CS_Sliders SET [Key] = 'key';
GO   
ALTER TABLE [CS_Sliders] ALTER COLUMN [Key] nvarchar(500) NOT NULL;
GO   



Update CS_Sliders SET [IsEditable] = 'true';
GO   
ALTER TABLE [CS_Sliders] ALTER COLUMN [IsEditable] bit NOT NULL;
GO   
 
PRINT 'Set New Columns NOT NULL' 
PRINT ''
PRINT '----------------------------------- End Slider  Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'
 

PRINT ''
PRINT ''
PRINT ''
PRINT ''
 
 
PRINT '-----------------------------------   Menu  --------------------------------------------'
PRINT ''

ALTER TABLE CS_Menus ADD 
 Published_en bit,
 Published_ar bit
 Go
 PRINT 'Added Columns To CS_Menus Table';
 PRINT ''
ALTER TABLE CS_Menus
DROP COLUMN Published;
GO   
PRINT 'Remove Columns From CS_Menus Table' 
PRINT ''



Update CS_Menus SET Published_en = 'true';
GO   
ALTER TABLE [CS_Menus] ALTER COLUMN [Published_en] bit NOT NULL;
GO   



Update CS_Menus SET Published_ar = 'true';
GO   
ALTER TABLE [CS_Menus] ALTER COLUMN [Published_ar] bit NOT NULL;
GO   

PRINT 'Set New Columns NOT NULL' 
PRINT ''
PRINT '----------------------------------- End Menu  Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'

 
-----------------------------------------------------------------------------------------------------------------


-------------------------------------------------------------------


BEGIN


 
DECLARE @id uniqueidentifier
DECLARE @counter int
DECLARE @prop_published nvarchar(250)
DECLARE @prop_published_ar nvarchar(250)
DECLARE @prop_published_en nvarchar(250) 

BEGIN  
PRINT '-----------------------------------   Gallery items  --------------------------------------------'
DECLARE GALLERY_CURSOR CURSOR  
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT  jsonValues.ItemId AS ITEMId

						FROM CS_Galleries  c
 
						CROSS APPLY OPENJSON(c.Items)
 
						WITH (ItemId uniqueidentifier '$.id',
 
						CreatorUserId nvarchar(255) '$.CreatorUserId') as jsonValues  
 
SET @counter = 0;
OPEN GALLERY_CURSOR
FETCH NEXT FROM GALLERY_CURSOR INTO @id
WHILE @@FETCH_STATUS = 0
BEGIN  
set  @prop_published = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published';
set  @prop_published_ar = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_ar';
set  @prop_published_en = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_en';

    UPDATE CS_Galleries 
	SET
	Items =JSON_MODIFY(JSON_MODIFY(JSON_MODIFY(Items, @prop_published,NULL), @prop_published_ar,CAST(1 as BIT)), @prop_published_en,CAST(1 as BIT)) 
	 
	SET @counter = @counter + 1;
    PRINT  '<< Gallery Item >> (' +  CAST(@counter AS VARCHAR(10)) + ')  id : ' +    CAST(@id AS VARCHAR(50)) 
    FETCH NEXT FROM GALLERY_CURSOR INTO @id
END
CLOSE GALLERY_CURSOR
DEALLOCATE GALLERY_CURSOR
PRINT '----------------------------------- End Gallery items Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'
END

PRINT ''
PRINT ''
PRINT ''
PRINT ''
 
Begin  
PRINT '-----------------------------------   Menu items  --------------------------------------------'
DECLARE @slug nvarchar(1000)
DECLARE MENU_CURSOR CURSOR  
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT  jsonValues.Slug AS Slug

						FROM CS_Menus  c
 
						CROSS APPLY OPENJSON(c.MenuItems)
 
						WITH (Slug uniqueidentifier '$.Slug',
 
						Title nvarchar(255) '$.Title_en') as jsonValues  
 
SET @counter = 0;
OPEN MENU_CURSOR
FETCH NEXT FROM MENU_CURSOR INTO @slug
WHILE @@FETCH_STATUS = 0
BEGIN  
set  @prop_published = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published';
set  @prop_published_ar = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_ar';
set  @prop_published_en = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_en';

    UPDATE CS_Menus 
	SET
	MenuItems =JSON_MODIFY(JSON_MODIFY(JSON_MODIFY(MenuItems, @prop_published,NULL), @prop_published_ar,CAST(1 as BIT)), @prop_published_en,CAST(1 as BIT)) 
	 
	SET @counter = @counter + 1;
  PRINT  '<< Menu Item >> (' +  CAST(@counter AS VARCHAR(10)) + ')  slug : ' +    CAST(@slug AS VARCHAR(50)) 
    FETCH NEXT FROM MENU_CURSOR INTO @slug
END
CLOSE MENU_CURSOR
DEALLOCATE MENU_CURSOR
PRINT '----------------------------------- End Menu items Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'
END

PRINT ''
PRINT ''
PRINT ''
PRINT ''
 
Begin  
PRINT '-----------------------------------   Slider items  --------------------------------------------'
DECLARE SLIDER_CURSOR CURSOR  
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT  jsonValues.ItemId AS ITEMId

						FROM CS_Sliders c
 
						CROSS APPLY OPENJSON(c.Items)
 
						WITH (ItemId uniqueidentifier '$.id',
 
						Title nvarchar(255) '$.Title_en') as jsonValues  
 
SET @counter = 0;
OPEN SLIDER_CURSOR
FETCH NEXT FROM SLIDER_CURSOR INTO @id
WHILE @@FETCH_STATUS = 0
BEGIN  
set  @prop_published = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published';
set  @prop_published_ar = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_ar';
set  @prop_published_en = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_en';

    UPDATE CS_Sliders 
	SET
	Items =JSON_MODIFY(JSON_MODIFY(JSON_MODIFY(Items, @prop_published,NULL), @prop_published_ar,CAST(1 as BIT)), @prop_published_en,CAST(1 as BIT)) 
	 
	SET @counter = @counter + 1;
    PRINT  '<< Slider Item >> (' +  CAST(@counter AS VARCHAR(10)) + ')  id : ' +    CAST(@id AS VARCHAR(50)) 
    FETCH NEXT FROM SLIDER_CURSOR INTO @id
END
CLOSE SLIDER_CURSOR
DEALLOCATE SLIDER_CURSOR
PRINT '----------------------------------- End Slider items Block  --------------------------------------------'
PRINT '     ----------------------------------------------------------------------------------------'
PRINT '            --------------------------------------------------------------------------'
END


END




COMMIT TRANSACTION