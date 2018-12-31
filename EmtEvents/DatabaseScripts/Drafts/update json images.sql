DECLARE @id nvarchar(1000)
DECLARE @parent_id uniqueidentifier 
DECLARE @previous_parent_id uniqueidentifier
Begin  

DECLARE @counter INT 
DECLARE @prop_image_en VARCHAR(1000)
DECLARE @prop_image_ar VARCHAR(1000)
DECLARE @image_en_value VARCHAR(1000)
DECLARE @image_ar_value  VARCHAR(1000)
DECLARE @prefix VARCHAR(1000)= 'https://Ahmad';	
DECLARE @prefixAR VARCHAR(1000)= 'https://Aktaa';	
DECLARE GALLERY_CURSOR CURSOR  
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT id as row_parent_id, jsonValues.ItemId AS ITEMId,  jsonValues.item_image_en AS image_en,  jsonValues.item_image_ar AS image_ar

						FROM CS_Sliders c
 
						CROSS APPLY OPENJSON(c.Items)
 
						WITH (ItemId nvarchar(1000) '$.id',
 
						item_image_en nvarchar(1000) '$.Image_en',
						item_image_ar nvarchar(1000) '$.Image_ar') as jsonValues  
 
SET @counter = 0;
OPEN GALLERY_CURSOR
FETCH NEXT FROM GALLERY_CURSOR INTO @parent_id, @id , @image_en_value , @image_ar_value
WHILE @@FETCH_STATUS = 0
BEGIN   

IF @parent_id = @previous_parent_id
PRINT  '@counter ' + CAST(@counter AS VARCHAR(10))
ELSE
SET @counter = 0; 



set  @prop_image_en = '$['+ CAST(@counter AS VARCHAR(10)) +'].Image_en';
set  @prop_image_ar = '$['+ CAST(@counter AS VARCHAR(10)) +'].Image_ar';
    UPDATE CS_Sliders 
	SET
	Items =JSON_MODIFY(JSON_MODIFY(Items, @prop_image_en,
	CONCAT ( @prefix,  '/',SUBSTRING( @image_en_value , LEN(@image_en_value) -  CHARINDEX('/',REVERSE(@image_en_value)) + 2  , LEN(@image_en_value)  ) )),
	 @prop_image_ar,
	CONCAT ( @prefixAR,  '/',SUBSTRING( @image_ar_value , LEN(@image_ar_value) -  CHARINDEX('/',REVERSE(@image_ar_value)) + 2  , LEN(@image_ar_value)  ) ))
	where Id =  @parent_id
	 
	 SET @previous_parent_id = @parent_id;
	SET @counter = @counter + 1;
    PRINT  '<< Gallery Item >> (' +  CAST(@counter AS VARCHAR(10)) + ') id : '+ CAST(@parent_id AS VARCHAR(500))+ ' : '+ CAST(@id AS VARCHAR(500))+' -  ' +    CAST(@prop_image_en AS VARCHAR(500))  +   ':' +    CAST(@image_en_value AS VARCHAR(500))  + '  -   '+    CAST(@prop_image_ar AS VARCHAR(500))  +   ':' +    CAST(@image_ar_value AS VARCHAR(500)) 
    FETCH NEXT FROM GALLERY_CURSOR INTO @parent_id, @id, @image_en_value , @image_ar_value
END
CLOSE GALLERY_CURSOR
DEALLOCATE GALLERY_CURSOR 
END