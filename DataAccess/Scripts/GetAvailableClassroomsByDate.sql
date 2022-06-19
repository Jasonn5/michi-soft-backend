IF OBJECT_ID('dbo.GetAvailableClassroomsByDate', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetAvailableClassroomsByDate
GO

CREATE PROCEDURE dbo.GetAvailableClassroomsByDate
@StartTime DECIMAL(10,2),
@EndTime DECIMAL(10,2),
@StartDate DATETIME,
@EndDate DATETIME,
@Capacity INT
AS
	Select cr.Id, cr.Name, cr.Capacity, cr.Type, cr.IsEnabled 
    From ClassRooms cr
    Where cr.Id NOT IN (Select c.Id
                    From ClassRooms c
                    LEFT JOIN Bookings b ON c.Id = b.ClassRoomId
                    Where (b.Date BETWEEN @StartDate AND @EndDate)
                            AND ( (b.StartTime <= @StartTime AND @StartTime< b.EndTime) 
							OR (b.EndTime >= @EndTime AND b.StartTime < @EndTime))
					) AND cr.Capacity > = @Capacity AND cr.IsEnabled = 1
GO
