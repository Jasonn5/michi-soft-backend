USE Michisoft
GO

IF OBJECT_ID('dbo.GetCustomizes', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetCustomizes
GO

CREATE PROCEDURE dbo.GetCustomizes
AS
	Select *
    From Customizes c
    Where c.IsEnabled = 0
GO