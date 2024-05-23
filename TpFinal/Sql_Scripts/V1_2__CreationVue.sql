CREATE VIEW v_HeroDetails AS
SELECT 
    h.HeroId,
    h.Nom AS HeroName,
    p.Type AS PouvoirType,
    p.Description AS PouvoirDescription,
    i.DateNaissance,
    i.Age,
    d.Nom AS DuoName,
    c.Nom AS ComicsName,
    c.Date AS ComicsDate
FROM 
    Heros.Hero h
JOIN 
    Heros.Pouvoir p ON h.PouvoirId = p.PouvoirId
JOIN 
    Heros.Identite i ON h.IdentiteId = i.IdentiteId
LEFT JOIN 
    Divers.Duo d1 ON h.HeroId = d1.Hero1Id
LEFT JOIN 
    Divers.Duo d2 ON h.HeroId = d2.Hero2Id
LEFT JOIN 
    Heros.ComicsHero ch ON h.HeroId = ch.HeroId
LEFT JOIN 
    Divers.Comics c ON ch.ComicsId = c.ComicsId
LEFT JOIN 
    Divers.Duo d ON h.HeroId = d.Hero1Id OR h.HeroId = d.Hero2Id
