BEGIN TRAN  
USE 
Northwind
Go



BEGIN TRAN


--1.
SELECT 
	* 
FROM  
	Region
WITH(HOLDLOCK);
SELECT 
	* 
FROM  
	Territories
WITH(HOLDLOCK);
SELECT 
	* 
FROM  
	EmployeeTerritories
WITH(HOLDLOCK);
SELECT 
	* 
FROM  
	Employees
WITH(HOLDLOCK);

INSERT INTO 
	Region (RegionID,RegionDescription) 
	VALUES (5,'Middle Earth')

INSERT INTO 
	Territories 
	(TerritoryID,RegionID,TerritoryDescription) 
VALUES 
	(12345,5,'Gondor')

INSERT INTO 
	Employees 
	(FirstName,LastName) 
VALUES 
	('Aragorn','King')

INSERT INTO 
	EmployeeTerritories (EmployeeID,TerritoryID) 
		SELECT 
						EmployeeID, 12345 
		FROM 
			Employees 
		WHERE 
			FirstName = 'Aragorn' and LastName = 'King'

--2.

UPDATE Territories
SET TerritoryDescription = 'Arnor'
WHERE TerritoryDescription = 'Gondor'

--3.
DELETE FROM EmployeeTerritories
WHERE TerritoryID = (SELECT TerritoryID FROM Territories WHERE RegionID = (SELECT RegionID FROM Region WHERE RegionDescription =  'Middle Earth'))

DELETE FROM Territories
WHERE RegionID = (SELECT RegionID FROM Region WHERE RegionDescription =  'Middle Earth')


DELETE FROM Region
WHERE RegionDescription = 'Middle Earth'
ROLLBACK
--4.

CREATE VIEW view_product_order_shiqi_zhang AS
		SELECT 
				 p.ProductID
				,p.ProductName
				,SUM(od.Quantity) AS TotalOrderedQuality
		FROM 
				Products AS p
			INNER JOIN	
				[Order Details] AS od
			ON
				p.ProductID = od.ProductID
		GROUP BY 
				 p.ProductID
			    ,p.ProductName






