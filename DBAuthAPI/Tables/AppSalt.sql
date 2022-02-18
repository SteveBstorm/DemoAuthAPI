﻿CREATE TABLE [dbo].[AppSalt]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	SaltValue VARCHAR(100) NOT NULL,
	UserId INT NOT NULL
	CONSTRAINT FK_User_Salt FOREIGN KEY (UserId) REFERENCES AppUser(Id)
)