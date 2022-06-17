USE Michisoft
GO

IF OBJECT_ID('dbo.GetActualCustom', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetActualCustom
GO

CREATE PROCEDURE dbo.GetActualCustom
AS
	Select *
    From Customizes c
    Where c.IsEnabled = 1
GO