---- Création de la clé principale pour le chiffrement
--CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'YourStrongPassword!';

---- Création du certificat pour le chiffrement des données
--CREATE CERTIFICATE IdentiteCertificate
--WITH SUBJECT = 'Certificate to encrypt Identite dates';

---- Création de la clé symétrique pour le chiffrement des données
--CREATE SYMMETRIC KEY IdentiteSymmetricKey
--WITH ALGORITHM = AES_256
--ENCRYPTION BY CERTIFICATE IdentiteCertificate;

---- Ouverture de la clé symétrique pour le chiffrement des données
--OPEN SYMMETRIC KEY IdentiteSymmetricKey
--DECRYPTION BY CERTIFICATE IdentiteCertificate;

---- Insertion des données chiffrées dans la table Heros.Identite
--INSERT INTO Heros.Identite (DateNaissance, Age, DateNaissanceChiffree)
--VALUES (
--    '1985-07-28',
--    38,
--    ENCRYPTBYKEY(KEY_GUID('IdentiteSymmetricKey'), CAST('1985-07-28' AS NVARCHAR(10)))
--);

---- Fermeture de la clé symétrique après insertion des données
--CLOSE SYMMETRIC KEY IdentiteSymmetricKey;

---- Réouverture de la clé symétrique pour le déchiffrement des données
--OPEN SYMMETRIC KEY IdentiteSymmetricKey
--DECRYPTION BY CERTIFICATE IdentiteCertificate;

---- Sélection des données déchiffrées depuis la table Heros.Identite
--SELECT 
--    IdentiteId,
--    DateNaissance,
--    Age,
--    CONVERT(DATE, DECRYPTBYKEY(DateNaissanceChiffree)) AS DateNaissanceDechiffree
--FROM 
--    Heros.Identite;

---- Fermeture de la clé symétrique après sélection des données
--CLOSE SYMMETRIC KEY IdentiteSymmetricKey;
