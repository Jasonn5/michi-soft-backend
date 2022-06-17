USE Michisoft
GO

IF OBJECT_ID('dbo.BookingByProffesorId', 'P') IS NOT NULL
	DROP PROCEDURE dbo.BookingByProffesorId
GO

CREATE PROCEDURE dbo.BookingByProffesorId
@ProffesorId INT
AS
	SELECT b.Id,b.Date,b.StartTime,b.EndTime, b.Reason, c.Id AS ClassRoomId, c.Name AS ClassRoomName, m.Id AS MatterId, m.Name AS MatterName, m.[Group] As MatterGroup
	FROM Bookings b
	LEFT JOIN Matters m ON b.MatterId = m.Id
	LEFT JOIN ClassRooms c ON b.ClassRoomId = c.Id
	WHERE m.UserId = @ProffesorId
GO