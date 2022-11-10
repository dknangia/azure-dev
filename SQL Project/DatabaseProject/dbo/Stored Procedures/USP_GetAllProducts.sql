/****** Script for SelectTopNRows command from SSMS  ******/

CREATE PROCEDURE USP_GetAllProducts
AS
BEGIN 
SELECT TOP (1000) [ProductId]
      ,[Name]
      ,[Description]
      ,[Price]
      ,[Category]
  FROM [SportsStore].[dbo].[Products]
END 