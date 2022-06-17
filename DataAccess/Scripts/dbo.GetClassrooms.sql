USE Michisoft
GO

IF OBJECT_ID('dbo.GetClassrooms', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetClassrooms
GO

CREATE PROCEDURE dbo.GetClassrooms
@Search NVARCHAR(MAX),
@Active INT
AS
	SELECT *
	FROM ClassRooms c
	Where (c.Name like '%' + @Search + '%') AND c.IsEnabled = @Active
GO