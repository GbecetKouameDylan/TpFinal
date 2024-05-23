Create Table Heros.Image(
ImageID int IDENTITY(1,1),
Nom nvarchar(100) Not null,
Identifiant uniqueidentifier not  null rowguidcol,
constraint PK_Image_ImageID primary key (ImageID)
);
GO

Alter TAble Heros.Image add constraint UC_Image_identifiant 
Unique(Identifiant);
Go

Alter table Heros.Image add constraint DF_Image_identifiant
Default newid() For Identifiant;
Go

Alter Table Heros.Image add 
FichierImage varbinary(max) Filestream Null;
Go