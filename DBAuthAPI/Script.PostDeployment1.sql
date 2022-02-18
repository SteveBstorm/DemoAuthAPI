/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO AppRole (RoleName) VALUES ('User'), ('Moderator'), ('Admin')

EXEC AppUserRegister 'admin@test.com', 'admin1234=', 'Arthur'
EXEC AppUserRegister 'moderator@test.com', 'modo1234=', 'Merlin'
EXEC AppUserRegister 'user@test.com', 'user1234=', 'Perceval'

UPDATE AppUser SET RoleId = 3 WHERE Id = 1
UPDATE AppUser SET RoleId = 2 WHERE Id = 2