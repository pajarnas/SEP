/* =========================================
Object: Day 2 Assignment 
Author: Saige Zhang
Create date: May 6, 2021
Description: SQL: Comprehensive practice
============================================ */
/*

1.

	I Would prefer to use subqueries because it has a better performance. 

2.
	 Common Table Expressions

     a. We use it to create a recursive query.

     b. Substitute for a view when the general use of a view is not required; 
	that is, you do not have to store the definition in metadata.

     c. Using a CTE offers the advantages of improved readability and ease in
	 maintenance of complex queries**. The query can be divided into separate, 
	 simple, logical building blocks. These simple blocks can then be used to 
	 build more complex, interim CTEs until the final result set is generated. 

     d. CTEs can be defined in user-defined routines, such as functions, 
	 stored procedures, triggers, or views

3. 
	a.  Temporary tables are defined just like regular tables, only they are 
	automatically stored in the tempdb database.

	b. Local  : Local temporary tables are prefixed with a single # sign 

	c. Global: global temporary tables with a double ## sign.


	d.A local temporary table exists only for the duration of a connection or, 
	if defined inside a compound statement, for the duration of the compound statement.


	e. A global temporary table remains in the database permanently, but the rows
	exist only within a given connection. When connection is closed, the data 
	in the global temporary table disappears. However, the table definition remains
	with the database for access when database is opened next time.

	f. Temporary tables causes performance issues. 

	g. Microsoft recommends table variables as a replacement of temporary tables when the data set is not very large 

	h. A table variable is a data type that can be used within a Transact-SQL batch, stored procedure,
	or function�and is created and defined similarly to a table, only with a strictly defined lifetime scope. 

	i. Unlike regular tables or temporary tables, table variables can�t have indexes or FOREIGN KEY constraints added to them.
	Table variables do allow some constraints to be used in the table definition (PRIMARY KEY, UNIQUE, CHECK).

	j. table variable make sure in one singe block 

	k. The lifetime of the table variable only lasts for the duration of the batch, function, or stored procedure 

	l. In reality they are stored in the tempdb database like temporary tables. Like regular variables, 
	table variables are visible only within the batch where they were created. Table variables can be used for working 
	with small temporary data, for passing a list of values to stored procedures or functions, for auditing, etc.

4.  
	TRUNCATE:
	Removes all rows from a table or specified partitions of a table, without logging the individual row deletions. 
	
	DELETE:
	Removes one or more rows from a table or view in SQL Server.
	
	Difference:
	TRUNCATE TABLE is similar to the DELETE statement with no WHERE clause; however, TRUNCATE TABLE is faster and uses 
	fewer system and transaction log resources.
	Truncate reseeds identity values, whereas delete doesn't.
	Truncate removes all records and doesn't fire triggers.
	Truncate is faster compared to delete as it makes less use of the transaction log.
	Truncate is not possible when a table is referenced by a Foreign Key or tables are used in replication or with indexed views.

5. 
	The term seed refers to the internal value SQL Server uses to generate the next value in the sequence. 
	By default, an identity column's first value is 1 and each new value increments by one (1, 2, 3, 4, and so on).

	identity column generates sequential values for new records using a seed value.

	An identity column is a column in a database table 
	that is made up of values generated by the database.

	For example: 
		Create TABLE #Employee(id int IDENTITY(1,1), firstname varchar(20), PRIMARY KEY (ID))

	The DELETE will not reseed the identity value, the new inserted row will start with the identity with just deleted
	The TRUNCATE will reseed the identity value, the new inserted row will start with the inital value 1. 

6.  
	TRUNCATE Table_Name would remove all rows from Table_Name,  without logging the individual row deletions, 
	reseeds identity values. It would not work if a table is referenced by a Foreign Key or tables are used 
	in replication or with indexed views.

	DELETE FROM Table_Name removes all rows from Table_Name, would not ressed identity values, If you wish the delete to be automatic,
	you need to change your schema so that the foreign key constraint is ON DELETE CASCADE.

	*/

USE Northwind
GO

-- 1.

SELECT 
		DISTINCT c.City
		

FROM        Customers AS c 
INNER JOIN  Employees AS e
ON			c.City = e.City

-- 2.

-- a.
SELECT 
		DISTINCT c.City
		

FROM   Customers AS c 
WHERE c.City NOT IN
(
SELECT 
		DISTINCT e.City
FROM   Employees AS e
)
-- b.
SELECT 
		DISTINCT c.City
FROM   Customers AS c 
FULL OUTER JOIN 
		Employees AS e
ON      c.City = e.City
WHERE e.City IS NULL 

-- 3. 


SELECT -- Get all products have been ordered 
		  ProductID
		, SUM(Quantity) AS TotalOrderQuantities
			
FROM [Order Details]
GROUP BY ProductID

UNION 

SELECT -- Get all products have not been ordered 

		  ProductID
		, 0 AS TotalOrderQuantities
			
FROM [Products] 
WHERE ProductID NOT IN 
(
SELECT 
		  ProductID
FROM [Order Details]
)

-- 4.

SELECT 
		 o.ShipCity
		,SUM(od.Quantity) AS ProductOrdered
FROM Orders as o
LEFT JOIN [Order Details] as od
ON o.OrderID = od.OrderID
WHERE  -- exclude city Colchester
	o.ShipCity IN
(
SELECT 
		DISTINCT City
FROM Customers
)
GROUP BY o.ShipCity

-- 5.
--a.

SELECT 
	City
FROM   
	Customers
GROUP  BY City
HAVING Count(CustomerID) = 2
UNION
SELECT City
FROM   Customers
GROUP  BY City
HAVING Count(CustomerID) > 2; 

--b. 
SELECT
	DISTINCT  city
FROM Customers
WHERE city IN (SELECT
  city
FROM Customers
GROUP BY city
HAVING COUNT(customerid) >= 2)
-- 6

SELECT
  c.city,
  COUNT(DISTINCT p.ProductID) TotalProducts
FROM Products p
INNER JOIN [Order Details] od
  ON p.ProductID = od.ProductID
INNER JOIN Orders o
  ON od.OrderID = o.OrderID
INNER JOIN dbo.Customers c
  ON c.CustomerID = o.CustomerID
GROUP BY c.City
HAVING COUNT(DISTINCT p.productid) >= 2

-- 7

SELECT DISTINCT
    c.ContactName
  , c.City
  , o.ShipCity
FROM Orders              o
    INNER JOIN Customers c
        ON o.CustomerID = c.CustomerID
WHERE c.City <> o.ShipCity

-- 8.

SELECT TOP 5 b.ProductName
	,avg(b.UnitPrice) AveragepPrice
	,d.City
FROM Products b
INNER JOIN [Order Details] a ON a.ProductID = b.ProductID
INNER JOIN Orders c ON c.OrderID = a.OrderID
INNER JOIN Customers d ON d.CustomerID = c.CustomerID
GROUP BY b.ProductName
	,d.City
ORDER BY sum(a.Quantity) DESC;

-- 9. 
-- a.
SELECT DISTINCT City 
FROM Employees
WHERE City NOT IN (
		SELECT ShipCity
		FROM  Orders)
-- b. 
SELECT DISTINCT City 
FROM Employees e 
LEFT JOIN Orders o
ON e.City = o.ShipCity
WHERE ShipCity IS NULL

-- 10.


SELECT DISTINCT b.city
FROM orders a
INNER JOIN customers b ON a.CustomerID = b.CustomerID
WHERE b.city IN (
		SELECT TOP 1 d.city
		FROM dbo.Products b
		INNER JOIN dbo.[Order Details] a ON a.ProductID = b.ProductID
		INNER JOIN dbo.Orders c ON c.OrderID = a.OrderID
		INNER JOIN dbo.Customers d ON d.CustomerID = c.CustomerID
		GROUP BY d.City
		ORDER BY count(c.orderid) DESC
		)
	AND b.city IN (
		SELECT *
		FROM dbo.Products b
		INNER JOIN dbo.[Order Details] a ON a.ProductID = b.ProductID
		INNER JOIN dbo.Orders c ON c.OrderID = a.OrderID
		INNER JOIN dbo.Customers d ON d.CustomerID = c.CustomerID
		GROUP BY d.City
		ORDER BY count(a.ProductID) DESC
		)

-- 11.
/*

Use RANK() or ROW_NUMBER() function with PARTITION BY clause. The PARTITION BY clause prepares a subset of data
for the specified columns and gives rank for that partition. Then remove the rows having a rank greater than one.



*/