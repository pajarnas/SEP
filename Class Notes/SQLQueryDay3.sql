USE Northwind
GO

-- find the customer who have never placed any order

-- SELECT * FROM Customers WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM ORDERS)

-- Co related sub query

--SELECT c.ContactName, 
--(SELECT COUNT(orderid) FROM orders o where o.CustomerID = c.CustomerID)
--FROM Customers c

---- This is a better performance

--SELECT 
--	c.ContactName, COUNT(o.OrderID) AS TotalOrders
--FROM Customers c LEFT JOIN Orders o 
--ON  c.CustomerID = o.CustomerID
--GROUP BY c.ContactName

--WITH customerCTE
--AS
--(
--	SELECT COUNT(CustomerID) TotalCustomer, city FROM CUSTOMERS GROUP BY CITY
--)
---- Make sure used in the next select
--SELECT * FROM customerCTE

--WITH empHerirarchyCTE
--AS
--(
--	SELECT EmployeeID, FirstName, ReportsTo, 1 'lvl' FROM Employees WHERE ReportsTo IS NULL
--	UNION ALL
--	SELECT e.EmployeeID, e.FirstName, e.ReportsTo, c.lvl + 1
--	FROM Employees e LEFT JOIN empHerirarchyCTE c on e.ReportsTo = c.employeeID
--)
--SELECT * FROM empHerirarchyCTE

/*
SELECT * FROM Employees


WITH empHerirarchyCTE
AS
(
	SELECT EmployeeID, FirstName, ReportsTo, 1 'lvl' FROM Employees WHERE ReportsTo IS NULL
	UNION ALL
	SELECT e.EmployeeID, e.FirstName, e.ReportsTo, c.lvl + 1
	FROM Employees e INNER JOIN empHerirarchyCTE c on e.ReportsTo = c.employeeID
)
SELECT * FROM empHerirarchyCTE*/
/*
SELECT 
		c.CustomerID,
		c.ContactName,
		c.City,
		c.Phone,
		c.Country,
		COUNT(o.OrderID)
FROM Customers c LEFT JOIN Orders o ON
c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.ContactName, c.City, c.Phone, c.Country
*/
/*
WITH customeOrderCountCTE
AS
(
	SELECT CustomerID, COUNT(OrderID) Total FROM Orders
	GROUP BY CustomerID
)
SELECT c.CustomerID,
		c.ContactName,
		c.City,
		c.Phone,
		c.Country,
		co.total
FROM Customers c LEFT JOIN customeOrderCountCTE co 
ON c.CustomerID = co.CustomerID
WITH customeOrderCountCTE
AS
(
	SELECT CustomerID, COUNT(OrderID) Total FROM Orders
	GROUP BY CustomerID
)
SELECT * FROM customeOrderCountCTE*/

-- # means local temp db LOCAL tempory table ## means Global temp table
--Create TABLE #Employee(id int, firstname varchar(20))

-- make sure in one singe block
-- use variable to imporve performance, use when result set not too large
DECLARE @empCollection TABLE (id int, firstname nvarchar(10))

INSERT @empCollection(id, firstname)
SELECT EmployeeID, FirstName
FROM Employees

SELECT * FROM @empCollection
BEGIN TRANSACTION
DELETE FROM @empCollection
GO
ROLLBACK TRANSACTION

SELECT * from @empCollection

DROP TABLE  #Employee

Create TABLE #Employee(id int IDENTITY(1,1), firstname varchar(20), PRIMARY KEY (ID))

INSERT #Employee( firstname)
SELECT  FirstName
FROM Employees
SELECT * FROM #Employee


DELETE FROM #Employee
SELECT * from #Employee




SELECT * from #Employee

truncate  Table #Employee
SELECT * from #Employee

INSERT #Employee('123132')

SELECT * from #Employee
/*
Well scoped. The lifetime of the table variable only lasts for the duration of the batch, function, or stored procedure 
Shorter locking periods (because of the tighter scope).
Less recompilation when used in stored procedures 
Table variable performance suffers when the result set becomes too large 
*/

-- RANK fuction or RANK window fuction
SELECT TOP 1 * FROM
(SELECT TOP 11
	ProductID,
	ProductName,
	UnitPrice
FROM Products
ORDER BY unitprice DESC) dt
ORDER BY dt.Unitprice asc

-- SAME price, there should be two records
SELECT * FROM
(SELECT 
	ProductID,
	ProductName,
	UnitPrice,
	RANK() OVER(ORDER BY unitprice DESC) rnk
FROM Products) dt
WHERE dt.rnk = 11
 
-- RANK problem if no.11 rank = no.12 rank, tank = 12 is disapeared

SELECT * FROM
(SELECT 
	ProductID,
	ProductName,
	UnitPrice,
	DENSE_RANK() OVER(ORDER BY unitprice DESC) rnk
FROM Products) dt
WHERE dt.rnk = 12

--  top 3 customers from every city who have placed maximum number of orders


WITH custoerOrderCountCTE
AS
(
	SELECT customerID, Count(OrderID) totalOrder FROM Orders GROUP BY CustomerID
) ,
customerRankCTE
AS
(
	SELECT c.customerID, c.ContactName, c.City, ct.totalOrder,
	DENSE_RANK() OVER (PARTITION BY c.city ORDER BY ct.totalOrder  DESC) rnk
	FROM Customers c INNER JOIN custoerOrderCountCTE ct 
	ON c.CustomerID = ct.CustomerID
	
)
-- The diff between PARTITION and GROUP BY
SELECT * FROM customerRankCTE 

 WITH custoerOrderCountCTE
AS
(
	SELECT customerID, Count(OrderID) totalOrder FROM Orders GROUP BY CustomerID
) ,
customerRankCTE
AS
(
	SELECT c.customerID, c.ContactName, c.City, ct.totalOrder,
	DENSE_RANK() OVER (ORDER BY ct.totalOrder  DESC) rnk
	FROM Customers c INNER JOIN custoerOrderCountCTE ct 
	ON c.CustomerID = ct.CustomerID
	
)
-- USE PARTITION to find top 3 in every city
SELECT * FROM customerRankCTE 
