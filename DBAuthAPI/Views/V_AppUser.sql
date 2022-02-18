CREATE VIEW [dbo].[V_AppUser]
	AS SELECT u.Id, u.Email, u.NickName, r.RoleName AS Role FROM AppUser u 
	JOIN AppRole r ON r.Id = u.RoleId
