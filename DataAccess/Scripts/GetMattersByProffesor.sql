USE Michisoft
GO

IF OBJECT_ID('dbo.GetMattersByProffesor', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetMattersByProffesor
GO

CREATE PROCEDURE dbo.GetMattersByProffesor
@TeacherId INT
AS
	SELECT m.Id, m.[Name], m.[NumberStudents], m.[Group], m.UserId
	FROM Matters m
	WHERE m.UserId = @TeacherId
GO