Create Schema Heros
Go
Create Schema Divers
Go
Create Table Heros.Hero
(
HeroId int Identity(1,1) Not Null,
Nom nvarchar (25) Not Null,
PouvoirId int Not Null,
IdentiteId int Not Null,
 Constraint Pk_Hero_HeroID Primary Key (HeroId)
)
Go
Create Table Heros.Pouvoir
(
PouvoirId int Identity(1,1) Not Null,
Type nvarchar (25) Not Null,
Description nvarchar (100) Not null,
 Constraint Pk_Hero_PouvoirID Primary Key (PouvoirId)
)
Go
Create Table Divers.Comics
(
ComicsId int Identity(1,1) Not Null,
Nom nvarchar (25) Not Null,
Date date Not Null,
 Constraint Pk_Hero_ComicsID Primary Key (ComicsId)
)
Go
Create Table Divers.Duo
(
EquipeId int Identity(1,1) Not Null,
Nom nvarchar (25) Not Null,
Hero1Id int Not Null,
Hero2Id int Not Null,
 Constraint Pk_Hero_DuoID Primary Key (EquipeId)
)
Go
Create Table Heros.Identite
(
IdentiteId int Identity(1,1) Not Null,
DateNaissance Date Not Null,
Age int Not Null,
 Constraint Pk_Hero_IdentiteID Primary Key (IdentiteId)
)
Go
Create Table Heros.ComicsHero
(
ComicsId int Not Null,
HeroId int Not Null
)
Go
Create Table Heros.ArchivesComics
(
ArchivesComicsID int Identity(1,1) Not null,
ComicsId int ,
Nom nvarchar (25) ,
Date date ,
DateDelete date 
)

Go
Alter Table Heros.Hero Add Constraint Fk_Hero_Pouvoir Foreign Key (PouvoirId) References Heros.Pouvoir(PouvoirId) On Delete Cascade
Go
Alter Table Heros.Hero Add Constraint Fk_Hero_Identite Foreign Key (IdentiteId) References Heros.Identite(IdentiteId) On Delete Cascade
Go
Alter Table Divers.Duo Add Constraint Fk_Hero_DuoHero1ID Foreign Key (Hero1Id) References Heros.Hero(HeroId)
Go
Alter Table Divers.Duo Add Constraint Fk_Hero_DuoHero2ID Foreign Key (Hero2Id) References Heros.Hero(HeroId)
Go
Alter Table Heros.ComicsHero Add Constraint Fk_Hero_HeroComicsID Foreign Key (HeroId) References Heros.Hero(HeroId)on Delete Cascade
Go
Alter Table Heros.ComicsHero Add Constraint Fk_Hero_ComiscHeroID Foreign Key (ComicsId) References Divers.Comics(ComicsId)on Delete Cascade
