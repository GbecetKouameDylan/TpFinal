USE master 
GO

-- CREATION ou RECREATION de la BD
IF
EXISTS(SELECT * FROM sys.databases WHERE name='Hero')
BEGIN
	DROP DATABASE Hero
END

CREATE DATABASE Hero
GO

-- Configuration de FILESTREAM
EXEC sp_configure filestream_access_level, 2 RECONFIGURE

ALTER DATABASE Hero
ADD FILEGROUP FG_Images2164425 CONTAINS FILESTREAM;
GO

ALTER DATABASE Hero
ADD FILE (
	NAME = FG_Images2164425,
	FILENAME = 'C:\EspaceLabo\FG_Images2164425'
	
)
TO FILEGROUP FG_Images2164425
GO


