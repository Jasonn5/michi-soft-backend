USE Michisoft
GO

IF OBJECT_ID('dbo.GetClassroomByName', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetClassroomByName
GO

CREATE PROCEDURE dbo.GetClassroomByName
@Name NVARCHAR(MAX)
AS
	SELECT *
	FROM ClassRooms c
	Where c.Name = @Name
GO