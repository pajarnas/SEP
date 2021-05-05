
/* =========================================
Object: Day 1 Assignment 
Author: Saige Zhang
Create date: May 4, 2021
Description: SQL: Comprehensive practice
============================================ */

USE AdventureWorks2019
GO

-- No. 1 

SELECT
    [ProductId]
  , [Name]
  , [Color]
  , [ListPrice]
FROM [Production].[Product]   
GO

-- No. 2 

SELECT
    [ProductId]
  , [Name]
  , [Color]
  , [ListPrice]
FROM [Production].[Product]   
WHERE
    [ListPrice] = 0

GO                                                      

-- No. 3 

SELECT
    [ProductId]
  , [Name]
  , [Color]
  , [ListPrice]
FROM [Production].[Product]   
WHERE
    [Color] IS NULL

GO    

-- No. 4 

SELECT
    [ProductId]
  , [Name]
  , [Color]
  , [ListPrice]
FROM [Production].[Product]   
WHERE
    [Color] IS NOT NULL

GO    

-- No. 5

SELECT
    [ProductId]
  , [Name]
  , [Color]
  , [ListPrice]
FROM [Production].[Product]   
WHERE
      [Product].[Color] IS NOT NULL
  AND [Product].[ListPrice] > 0

GO    

-- No. 6

SELECT
    'NAME:' 
  + [Name]
  + '-- COLOR:' 
  + [Color]
AS
  'Name and Color'
FROM [Production].[Product]   
WHERE
      [Product].[Color] IS NOT NULL

GO    

-- No. 7

SELECT
    'NAME: ' 
  + [Name]
  + '-- COLOR: ' 
  + [Color]
AS
  'Name And Color'
FROM [Production].[Product]   
WHERE
     [Product].[Name] like '%Crankarm' 
 OR  [Product].[Name] like 'Chainring%' 
ORDER BY [Product].[ProductID]
GO    


-- No. 8

SELECT
    [ProductId]
  , [Name]
FROM [Production].[Product]   
WHERE
      [Product].[ProductId] >= 400
  AND [Product].[ListPrice] <= 500
GO    

-- No. 9 

SELECT
    [ProductId]
  , [Name]
  , [Color]
FROM [Production].[Product]   
WHERE
    [Color] IN ('Black','Blue')
GO    

-- No. 10

SELECT 
  'NAME: ' 
  + [Name]
  + ' -- PRODUCT ID: ' 
  + CAST([ProductId] as varchar(10))
AS
  'Products that begins with the letter S'
FROM [Production].[Product]   
WHERE
     [Product].[Name] like 'S%' 
ORDER BY [Product].[ProductID]
GO    

-- No. 11

SELECT 
    [Name]
  , [ListPrice]
FROM [Production].[Product]   
ORDER BY [Product].[Name]
GO    


-- No. 12

SELECT 
    [Name]
  , [ListPrice]
FROM [Production].[Product]   
WHERE
    [Product].[Name] like 'S%'
 OR [Product].[Name] like 'A%' 
ORDER BY [Product].[Name]
GO    

-- No. 13

SELECT 
    [Name]
FROM [Production].[Product]   
WHERE
    [Product].[Name] like 'SPO[^K]%'
ORDER BY [Product].[Name]
GO    

-- No. 14

SELECT 
    DISTINCT [Color]
FROM [Production].[Product]   
ORDER BY [COLOR] DESC
GO    

-- No.15

SELECT 
     DISTINCT 
	 [Color]
   , [ProductSubcategoryID]
FROM [Production].[Product]   
WHERE 
      [Color] IS NOT NULL
  AND [ProductSubcategoryID] IS NOT NULL
GO    

-- No. 16

SELECT 
		ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice 
FROM Production.Product
WHERE 
	      [Color] IN ('Red','Black') 
	  AND [ProductSubCategoryID] = 1
      OR  [ListPrice] BETWEEN 1000 AND 2000 
ORDER BY ProductID



-- No. 17

SELECT 
		[ProductSubCategoryID]
      , [Name]
      , [Color]
	  , [ListPrice] 
FROM Production.Product
WHERE 
	   [ProductSubCategoryID] IS NOT NULL
   AND [ProductSubCategoryID] < 15
   AND [ListPrice] > 500
   AND [Color] IS NOT NULL
   AND [Name] LIKE 'HL Road Frame - Red%'
	OR [Name] = 'HL Road Frame - Black, 58'           
    OR [Name] LIKE 'HL Mountain Frame - Silver%'
	OR [Name] LIKE 'Road-350-W Yellow%'
	OR [Name] LIKE 'Mountain-500 Black%'
ORDER BY 
		  [ProductSubCategoryID] DESC
		