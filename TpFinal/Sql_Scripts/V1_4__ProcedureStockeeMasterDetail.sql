GO
CREATE PROCEDURE AjouterHeroAComic
    @HeroId INT,
    @ComicsId INT,
    @DateAjout DATE
AS
BEGIN
    -- V�rifier si le h�ros existe
    IF NOT EXISTS (SELECT 1 FROM Heros.Hero WHERE HeroId = @HeroId)
    BEGIN
        RAISERROR('Le h�ros sp�cifi� n''existe pas.', 16, 1);
        RETURN;
    END

    -- V�rifier si le comic existe
    IF NOT EXISTS (SELECT 1 FROM Divers.Comics WHERE ComicsId = @ComicsId)
    BEGIN
        RAISERROR('Le comic sp�cifi� n''existe pas.', 16, 1);
        RETURN;
    END

    -- V�rifier si le h�ros est d�j� associ� � ce comic
    IF EXISTS (SELECT 1 FROM Heros.ComicsHero WHERE HeroId = @HeroId AND ComicsId = @ComicsId)
    BEGIN
        RAISERROR('Le h�ros est d�j� associ� � ce comic.', 16, 1);
        RETURN;
    END

    -- Ajouter l'association du h�ros au comic
    INSERT INTO Heros.ComicsHero (HeroId, ComicsId)
    VALUES (@HeroId, @ComicsId);

    -- Ins�rer dans les archives
    INSERT INTO Heros.ArchivesComics (ComicsId, Nom, Date, DateDelete)
    SELECT ComicsId, Nom, Date, @DateAjout
    FROM Divers.Comics
    WHERE ComicsId = @ComicsId;
END
GO

