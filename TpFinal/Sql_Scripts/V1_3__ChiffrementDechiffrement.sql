---- Cr�ation de la cl� principale pour le chiffrement
--CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'YourStrongPassword!';

---- Cr�ation du certificat pour le chiffrement des donn�es
--CREATE CERTIFICATE IdentiteCertificate
--WITH SUBJECT = 'Certificate to encrypt Identite dates';

---- Cr�ation de la cl� sym�trique pour le chiffrement des donn�es
--CREATE SYMMETRIC KEY IdentiteSymmetricKey
--WITH ALGORITHM = AES_256
--ENCRYPTION BY CERTIFICATE IdentiteCertificate;

---- Ouverture de la cl� sym�trique pour le chiffrement des donn�es
--OPEN SYMMETRIC KEY IdentiteSymmetricKey
--DECRYPTION BY CERTIFICATE IdentiteCertificate;

---- Insertion des donn�es chiffr�es dans la table Heros.Identite
--INSERT INTO Heros.Identite (DateNaissance, Age, DateNaissanceChiffree)
--VALUES (
--    '1985-07-28',
--    38,
--    ENCRYPTBYKEY(KEY_GUID('IdentiteSymmetricKey'), CAST('1985-07-28' AS NVARCHAR(10)))
--);

---- Fermeture de la cl� sym�trique apr�s insertion des donn�es
--CLOSE SYMMETRIC KEY IdentiteSymmetricKey;

---- R�ouverture de la cl� sym�trique pour le d�chiffrement des donn�es
--OPEN SYMMETRIC KEY IdentiteSymmetricKey
--DECRYPTION BY CERTIFICATE IdentiteCertificate;

---- S�lection des donn�es d�chiffr�es depuis la table Heros.Identite
--SELECT 
--    IdentiteId,
--    DateNaissance,
--    Age,
--    CONVERT(DATE, DECRYPTBYKEY(DateNaissanceChiffree)) AS DateNaissanceDechiffree
--FROM 
--    Heros.Identite;

---- Fermeture de la cl� sym�trique apr�s s�lection des donn�es
--CLOSE SYMMETRIC KEY IdentiteSymmetricKey;
