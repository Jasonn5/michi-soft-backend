IF OBJECT_ID('dbo.GetProffesors', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetProffesors
GO

CREATE PROCEDURE dbo.GetProffesors
AS
	SELECT *
	FROM Users u
	WHERE (u.Id > 1) AND u.IsEnabled = 1
GO