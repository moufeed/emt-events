


--<<<<<<<<<<<<<<<<<<<<<<<<<< Start Query 1 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 
-------------  Get record from TABLE by property in JsonColumn  --------------
SELECT *
 
FROM [T2].[dbo].[CS_Galleries] c
 
CROSS APPLY OPENJSON(c.Items)
 
WITH (Id uniqueidentifier '$.id',
 
CreatorUserId nvarchar(255) '$.CreatorUserId') as jsonValues
 
WHERE jsonValues.Id = 'c3a49e84-05c0-49f0-9613-a8168282a8ce' 

--<<<<<<<<<<<<<<<<<<<<<<<<<<<<     End      >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


---------------------------------------------------------------------------------- 


--<<<<<<<<<<<<<<<<<<<<<<<<<< Start Query 2 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


 DECLARE @id uniqueidentifier
  DECLARE @counter int
   DECLARE @prop_published nvarchar(250)
      DECLARE @prop_published_ar nvarchar(250)
	     DECLARE @prop_published_en nvarchar(250)
DECLARE MY_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT  jsonValues.ItemId AS PractitionerId

						FROM [T2].[dbo].[CS_Galleries] c
 
						CROSS APPLY OPENJSON(c.Items)
 
						WITH (ItemId uniqueidentifier '$.id',
 
						CreatorUserId nvarchar(255) '$.CreatorUserId') as jsonValues  
 
 SET @counter = 0;
OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @id
WHILE @@FETCH_STATUS = 0
BEGIN  
set  @prop_published = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published';
set  @prop_published_ar = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_ar';
set  @prop_published_en = '$['+ CAST(@counter AS VARCHAR(10)) +'].Published_en';

    UPDATE CS_Galleries 
	SET
	Items =JSON_MODIFY(JSON_MODIFY(JSON_MODIFY(Items, @prop_published,NULL), @prop_published_ar,CAST(1 as BIT)), @prop_published_en,CAST(1 as BIT)) 
	 
	SET @counter = @counter + 1;
    PRINT @counter
    FETCH NEXT FROM MY_CURSOR INTO @id
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR


--<<<<<<<<<<<<<<<<<<<<<<<<<<<<     End      >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>





BEGIN TRANSACTION 
GO


 
DECLARE @id uniqueidentifier
DECLARE @counter int
DECLARE @prop_published nvarchar(250)
DECLARE @prop_published_ar nvarchar(250)
DECLARE @prop_published_en nvarchar(250) 

Begin  
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



COMMIT

--<<<<<<<<<<<<<<<<<<<<<<<<<<<<     End      >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>











--<<<<<<<<<<<<<<<<<<<<<<<<<<<<     START      >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>



BEGIN TRANSACTION 
GO


 
DECLARE @id uniqueidentifier
DECLARE @counter int
DECLARE @prop_published nvarchar(250)
DECLARE @prop_published_ar nvarchar(250)
DECLARE @prop_published_en nvarchar(250) 

Begin  
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



COMMIT








--<<<<<<<<<<<<<<<<<<<<<<<<<<<<     End      >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>