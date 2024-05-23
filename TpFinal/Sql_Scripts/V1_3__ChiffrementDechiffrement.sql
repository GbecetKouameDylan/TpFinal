
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'YourStrongPassword!';


CREATE CERTIFICATE IdentiteCertificate
WITH SUBJECT = 'Certificate to encrypt Identite dates';


CREATE SYMMETRIC KEY IdentiteSymmetricKey
WITH ALGORITHM = AES_256
ENCRYPTION BY CERTIFICATE IdentiteCertificate;

ALTER TABLE Heros.Identite ADD DateNaissanceChiffree varbinary(max);



OPEN SYMMETRIC KEY IdentiteSymmetricKey
DECRYPTION BY CERTIFICATE IdentiteCertificate;


INSERT INTO Heros.Identite (DateNaissance, Age, DateNaissanceChiffree)
VALUES (
    '1985-07-28',
    38,
    ENCRYPTBYKEY(KEY_GUID('IdentiteSymmetricKey'), CAST('1985-07-28' AS NVARCHAR(10)))
);


CLOSE SYMMETRIC KEY IdentiteSymmetricKey;


OPEN SYMMETRIC KEY IdentiteSymmetricKey
DECRYPTION BY CERTIFICATE IdentiteCertificate;


SELECT 
    IdentiteId,
    DateNaissance,
    Age,
    CONVERT(DATE, DECRYPTBYKEY(DateNaissanceChiffree)) AS DateNaissanceDechiffree
FROM 
    Heros.Identite;


CLOSE SYMMETRIC KEY IdentiteSymmetricKey;
