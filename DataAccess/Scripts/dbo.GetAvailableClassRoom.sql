IF OBJECT_ID('dbo.GetAvailableClassRoom', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAvailableClassRoom
GO

CREATE PROCEDURE dbo.GetAvailableClassRoom
@StartTime DECIMAL(10,2),
@EndTime DECIMAL(10,2),
@StartDate DATETIME,
@EndDate DATETIME,
@ClassroomId INT
AS
	Select cr.Id, cr.Name, cr.Capacity, cr.Type, cr.IsEnabled 
    From ClassRooms cr
    LEFT JOIN Bookings b ON cr.Id = b.ClassRoomId
    Where (b.Date BETWEEN @StartDate AND @EndDate)
          AND ( (b.StartTime <= @StartTime AND @StartTime< b.EndTime) 
							OR (b.EndTime >= @EndTime AND b.StartTime < @EndTime))
					AND  cr.IsEnabled = 1 AND cr.Id = @ClassroomId
GO