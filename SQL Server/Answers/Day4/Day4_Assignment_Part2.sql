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


--5.
USE Northwind
Go

-- conditionally drop a stored proc
IF object_id('dbo.sp_product_order_quantity_zhang') is not null 
     DROP PROC dbo.sp_product_order_quantity_zhang
GO
 
CREATE PROC dbo.sp_product_order_quantity_zhang
   @ProductID INT
  ,@TotalQuantity SMALLINT OUTPUT
AS
SELECT  
   @TotalQuantity = SUM(Quantity)
FROM
   [Order Details]
GROUP BY ProductID
HAVING ProductID = @ProductID

GO



--*6.

IF object_id('dbo.sp_product_order_city_zhang') is not null 
     DROP PROC dbo.sp_product_order_city_zhang
GO
CREATE PROC sp_product_order_city_zhang
		(@ProductName nvarchar(40)
		,@TopCity NVARCHAR(15) OUTPUT
		,@TotalProducts int OUTPUT
		)
AS
BEGIN
SELECT
 TOP 5 o.ShipCity AS City, SUM(od.Quantity) AS ProductQuantityFromCity
FROM [Order Details] AS od
LEFT JOIN Orders AS o
ON od.OrderID = o.OrderID
GROUP BY o.ShipCity
ORDER BY SUM(od.Quantity) DESC
END

--7.

IF object_id('dbo.sp_move_employees_zhang') is not null 
     DROP PROC dbo.sp_move_employees_zhang
GO
CREATE PROC sp_move_employees_zhang 
 @ToryEmployee NVARCHAR(40) = 'Tory'
 AS
IF EXISTS
(
	SELECT 
					 e.EmployeeID
					,COUNT(t.TerritoryDescription) 
	FROM	Territories t 
		JOIN employeeterritories et 
	ON		t.TerritoryID=et.TerritoryID 
		JOIN Employees e
	ON 
			et.EmployeeID=e.EmployeeID
	WHERE TerritoryDescription=@ToryEmployee 
	GROUP BY e.EmployeeID
	HAVING 
		COUNT(t.TerritoryDescription)>0 
)
BEGIN
INSERT INTO Territories(TerritoryID,TerritoryDescription,RegionID) 
VALUES
(98432,'Stevens Point',11)
INSERT INTO Region(RegionID,RegionDescription) 
VALUES
(11,'North')
END
GO

--8.
CREATE TRIGGER trg_move_Troy_zhang
ON Territories
FOR UPDATE
AS
    IF EXISTS(SELECT e.EmployeeID,
                     Count(t.TerritoryDescription)
              FROM   Territories t
                     JOIN EmployeeTerritories et
                       ON t.TerritoryID = et.Territoryid
                     JOIN Employees e
                       ON et.EmployeeID = e.EmployeeID
              WHERE  t.TerritoryDescription = 'Stevens Point'
              GROUP  BY e.EmployeeID
              HAVING Count(t.TerritoryDescription) > 100)
      BEGIN
          UPDATE Territories
          SET    TerritoryDescription = 'Troy'
          WHERE  TerritoryDescription = 'Stevens Point'
      END

    DROP TRIGGER trg_move_Troy_zhang 

--9.
CREATE TABLE people_zhang
  (
     id     INT,
     NAME   CHAR(20),
     cityid INT
  )

CREATE TABLE city_zhang
  (
     cityid INT,
     city   CHAR(20)
  )

INSERT INTO people_zhang
            (id,
             NAME,
             cityid)
VALUES     (1,
            'Aaron Rodgers',
            2)

INSERT INTO people_zhang
            (id,
             NAME,
             cityid)
VALUES     (2,
            'Russell Wilson',
            1)

INSERT INTO people_zhang
            (id,
             NAME,
             cityid)
VALUES     (3,
            'Jody Nelson',
            2)

INSERT INTO city_zhang
            (cityid,
             city)
VALUES     (1,
            'Settle')

INSERT INTO city_zhang
            (cityid,
             city)
VALUES     (2,
            'Green Bay')

CREATE VIEW packers_shiqi_zhang
AS
  SELECT *
  FROM   people_zhang p
         JOIN city_zhang c
           ON p.cityid = c.cityid
  WHERE  c.city = 'Green bay'

BEGIN TRAN

ROLLBACK

DROP TABLE people_zhang

DROP TABLE city_zhang

DROP VIEW packers_shiqi_zhang 

--10.
CREATE PROC sp_birthday_employees_zhang
AS
  BEGIN
      SELECT employeeid,
             lastname,
             firstname,
             title,
             titleofcourtesy,
             birthdate,
             hiredate,
             photo
      INTO   birthday_employees_zhang
      FROM   employees
      WHERE  Month(birthdate) = 2
  END

DROP TABLE birthday_employees_zhang 
--11.

CREATE PROC sp_zhang_1
AS
    SELECT c.city,
           Count(c.customerid)
    FROM   customers c
           INNER JOIN (SELECT x.customerid,
                              Count(x.customerid) xx
                       FROM   (SELECT DISTINCT c.customerid,
                                               p.productid
                               FROM   products p
                                      JOIN [order details] od
                                        ON p.productid = od.productid
                                      JOIN orders o
                                        ON od.orderid = o.orderid
                                      JOIN customers c
                                        ON o.customerid = c.customerid) x
                       GROUP  BY x.customerid
                       HAVING Count(x.customerid) < 2) s
                   ON c.customerid = s.customerid
    GROUP  BY city
    HAVING Count(c.customerid) > 1


--12.
SELECT * FROM Table1
UNION
SELECT * FROM Table2
--14.
DECLARE @FullName VARCHAR(60)
DECLARE @FirstName VARCHAR(20)
DECLARE @LastName VARCHAR(20)
DECLARE @MiddleName VARCHAR(20)
SELECT 
	 @FirstName = [First Name]
	,@LastName + [Last Name]
	,@MiddleName = [Middle Name]
FROM People 
IF @MiddleName IS NULL
	SET @MiddleName = @MiddleName 
ELSE
	SET @MiddleName = @MiddleName + '.'
SET @FullName = @FirstName + @LastName + @MiddleName
PRINT @FullName
--15.
DECLARE @Marks INT
SET @Marks = (
SELECT TOP 1 Marks
FROM Students 
WHERE Sex='F'
ORDER BY Marks DESC)
PRINT @Marks
--16
DECLARE @student VARCHAR(20) 
DECLARE @marks INT 
SET @student 
SET @marks= 
(
SELECT 
	max(marks) 
FROM student 
ORDER BY sex
) 
print @student 