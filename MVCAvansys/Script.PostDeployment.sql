/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



DECLARE @Career_Table TABLE(
  ID uniqueidentifier, 
  Name NVARCHAR (100)
  )  

INSERT @Career_Table ([ID], [Name])
 VALUES 
  ('8caa91e0-601c-4ece-9e94-ee3ebc7e0f2f', 'Default career2' )
   
BEGIN TRANSACTION;

BEGIN TRY

PRINT 'Insertando career'
 MERGE [Career] AS TARGET
 USING @Career_Table as SOURCE
 ON (TARGET.ID = SOURCE.ID)
 WHEN NOT MATCHED BY TARGET THEN
  INSERT(ID, NAME)
  VALUES(SOURCE.ID, SOURCE.NAME)
 WHEN MATCHED THEN
  UPDATE SET TARGET.NAME = SOURCE.NAME;

COMMIT TRANSACTION
END TRY
BEGIN CATCH
 SELECT  ERROR_NUMBER() AS ErrorNumber
 ,ERROR_MESSAGE() AS ErrorMessage;
 Print ERROR_MESSAGE()
      ROLLBACK TRANSACTION
END CATCH
