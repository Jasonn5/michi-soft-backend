IF OBJECT_ID('dbo.GetBookings', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetBookings
GO

CREATE PROCEDURE dbo.GetBookings
@StartDate DATETIME,
@EndDate DATETIME,
@Search NVARCHAR(MAX)
AS
	Select b.Id, c.Id AS ClassroomId, c.Name, b.Date, b.StartTime, b.EndTime, b.Reason, u.Id AS UserId, u.FirstName, u.LastName
    From Bookings b
    Left Join ClassRooms c ON c.Id = b.ClassRoomId
    Left Join Matters m ON m.Id = b.MatterId
    Left Join Users u ON u.Id = m.UserId
    Where (b.Date BETWEEN @StartDate AND @EndDate) 
         AND ((u.FirstName like '%' + @Search + '%')
	     or (u.LastName like '%' + @Search + '%'))
GO