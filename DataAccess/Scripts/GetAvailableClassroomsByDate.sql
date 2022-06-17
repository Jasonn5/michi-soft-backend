USE Michisoft
GO

IF OBJECT_ID('dbo.GetAvailableClassroomsByDate', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAvailableClassroomsByDate
GO

CREATE PROCEDURE dbo.GetAvailableClassroomsByDate
AS
	SELECT c.Id, c.Name, c.Type, c.Capacity, c.IsEnabled
	FROM ClassRooms c
GO