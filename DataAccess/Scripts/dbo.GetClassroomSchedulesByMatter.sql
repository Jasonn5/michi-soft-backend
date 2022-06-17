USE Michisoft
GO

IF OBJECT_ID('dbo.GetClassroomSchedulesByMatter', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetClassroomSchedulesByMatter
GO

CREATE PROCEDURE dbo.GetClassroomSchedulesByMatter
@MatterId INT
AS
	SELECT  c.Id AS ClassroomId,c.Name as ClassroomName,cs.Id, cs.Day, cs.StartHour, cs.EndHour
	FROM ClassroomSchedules cs
	LEFT JOIN Matters m ON m.Id = cs.MatterId
	LEFT JOIN ClassRooms c ON cs.ClassRoomId = c.Id
	WHERE m.Id = @MatterId
GO