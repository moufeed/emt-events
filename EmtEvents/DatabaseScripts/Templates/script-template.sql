


/****************************************************************************************************************************************************/
 -- ALTER COLUMN
ALTER TABLE [TABLE_NAME] ALTER COLUMN [COLUMN_NAME] DATA_TYPE NOT NULL;

/****************************************************************************************************************************************************/
 -- DROP COLUMN
ALTER TABLE [TABLE_NAME]	DROP COLUMN  
										[COLUMN_NAME_1],
														[COLUMN_NAME_2],  
																		[COLUMN_NAME_3]
/****************************************************************************************************************************************************/
-- DROP COLUMN
ALTER TABLE [TABLE_NAME] ADD 
							[COLUMN_NAME_1] DATA_TYPE,
											[COLUMN_NAME_2] DATA_TYPE,  
															[COLUMN_NAME_3] DATA_TYPE
/****************************************************************************************************************************************************/
 -- TRANSACTION 

BEGIN TRANSACTION
GO
 
-------------------------------------------------------------------

 --   <<<<  execute all your statements code here  >>>>

--------------------------------------------------------------------- 


 
------------------------------------------------------------------- 
 --   <<<< optional -  display custom error after spcific statement[s]  >>>>
 IF @@ERROR != 0   PRINT 'Errors Found - Custom Error : <<<<   write custom error here  >>>>>'; 
 raiserror('Script failed', 20, -1) with log
GO
--------------------------------------------------------------------- 
 
IF @@ERROR != 0   PRINT 'Errors Found ... Rolling back' 
ELSE              PRINT 'Successfuly ... Committing changes'
COMMIT TRANSACTION

 /****************************************************************************************************************************************************/
 