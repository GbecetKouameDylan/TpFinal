GO
CREATE PROCEDURE AjouterHeroAComic
    @HeroId INT,
    @ComicsId INT,
    @DateAjout DATE
AS
BEGIN
    -- Vérifier si le héros existe
    IF NOT EXISTS (SELECT 1 FROM Heros.Hero WHERE HeroId = @HeroId)
    BEGIN
        RAISERROR('Le héros spécifié n''existe pas.', 16, 1);
        RETURN;
    END

    -- Vérifier si le comic existe
    IF NOT EXISTS (SELECT 1 FROM Divers.Comics WHERE ComicsId = @ComicsId)
    BEGIN
        RAISERROR('Le comic spécifié n''existe pas.', 16, 1);
        RETURN;
    END

    -- Vérifier si le héros est déjà associé à ce comic
    IF EXISTS (SELECT 1 FROM Heros.ComicsHero WHERE HeroId = @HeroId AND ComicsId = @ComicsId)
    BEGIN
        RAISERROR('Le héros est déjà associé à ce comic.', 16, 1);
        RETURN;
    END

    -- Ajouter l'association du héros au comic
    INSERT INTO Heros.ComicsHero (HeroId, ComicsId)
    VALUES (@HeroId, @ComicsId);

    -- Insérer dans les archives
    INSERT INTO Heros.ArchivesComics (ComicsId, Nom, Date, DateDelete)
    SELECT ComicsId, Nom, Date, @DateAjout
    FROM Divers.Comics
    WHERE ComicsId = @ComicsId;
END
GO

