/* =========================================
Object: Day 2 Assignment 
Author: Saige Zhang
Create date: May 5, 2021
Description: SQL: Comprehensive practice
============================================ */

/* ====================================================================

Basic Concepts

1.	What is a result set?

		Result set is a set of data, could be empty or not, returned by a select statement,
		or a stored procedure, that is saved in RAM or displayed on the screen.
		A TSQL script can have 0 to multiple result sets. 
		Use the following command can export the result set into file. 
		sqlcmd -i c:\sql\myquery.sql -o c:\sql\myoutput.txt

2.	What is the difference between Union and Union All?

		Two of SET operators. 

		Union and Union All are all for combining result set (returned by a SELECT statement,  or a stored procedure) together, vertically.

		UNION removes duplicate records (where all columns in the results are the same), UNION ALL does not.
		There is a performance hit when using UNION vs UNION ALL, since the database server must do additional work to remove the duplicate rows, but usually you do not want the duplicates (especially when developing reports).
		When using Union and Union All, you need to make sure the numbers of  columns and date type of each column from all result set should be the same.


3.	What are the other Set Operators SQL Server has?

		INTERSECT	: Takes the data from both result sets which are in common only.

		EXCEPT : Takes the data from first result set, but not the second (i.e. no matching to each other)

		It both returns NULL set when there is no data meeting the condition.

4.	What is the difference between Union and Join?

		a. from diff tables or result set

		JOIN combines data from many tables based on a matched condition between them.	
		UNION combines the result-set of two or more SELECT statements, or procedures.

		b. columns or rows

		JOIN combines data into new columns.	
		UNION combines data into new rows

		c. Number of columns

		JOIN:  Number of columns selected from each table may not be same.
		UNION: Number of columns selected from each table should be same.

		*d. 

		Datatypes of corresponding columns selected from each table can be different.
		Datatypes of corresponding columns selected from each table should be same.

		*e.

		It may not return distinct columns.	
		It returns distinct rows.

5.	What is the difference between INNER JOIN and FULL JOIN?

		Inner join returns only the matching rows between both the tables, non matching rows are eliminated.
		With INNER join we only get the rows that actually match up, no holes because of joining.

		SELECT * FROM A INNER JOIN B ON AA = BB

		 AA         BB
		--------   --------
		 Item 3     Item 3
		 Item 4     Item 4

		Full Join, is also called Full Outer Join, returns all rows from both the tables (left & right tables), 
		including non-matching rows from both the tables.
		 if you want all the rows of both, you'll use a FULL join:

		 SELECT * FROM A FULL JOIN B ON AA = BB

		 AA         BB
		--------   --------
		 Item 1            <-----+
		 Item 2                  |
		 Item 3     Item 3       |
		 Item 4     Item 4       |
					Item 5       +--- empty holes are NULL's
					Item 6       |
		   ^                     |
		   |                     |
		   +---------------------+


		NATURAL join, in this syntax we don't specify which columns that match, but matches on column names. 


6.	What is difference between left join and outer join

		OUTER JOINs have three types,

		LEFT JOIN, is also called LEFT OUTER JOIN,
		RIGHT JOIN, is also called RIGHT OUTER JOIN,
		FULL JOIN, is also called FULL OUTER JOIN.

7.	What is cross join?

		A CROSS join produces a cartesian product, 
		by matching up every row from the first set with every row from the second set:

		SELECT * FROM A CROSS JOIN B

		 AA         BB
		--------   --------
		 Item 1     Item 3      ^
		 Item 1     Item 4      +--- first item from A, repeated for all items of B
		 Item 1     Item 5      |
		 Item 1     Item 6      v
		 Item 2     Item 3      ^
		 Item 2     Item 4      +--- second item from A, repeated for all items of B
		 Item 2     Item 5      |
		 Item 2     Item 6      v
		 Item 3     Item 3      ... and so on
		 Item 3     Item 4
		 Item 3     Item 5
		 Item 3     Item 6
		 Item 4     Item 3
		 Item 4     Item 4
		 Item 4     Item 5
		 Item 4     Item 6


8.	What is the difference between WHERE clause and HAVING clause?

		A WHERE clause in SQL specifies that a SQL DML statement
		should only affect rows that meet specified criteria. The criteria are expressed in the 
		form of predicates. WHERE clauses are not mandatory clauses of SQL DML statements,
		but can be used to limit the number of rows affected by a SQL DML statement or returned by a query.
		In brief SQL WHERE clause is used to extract only those results from a SQL statement, 
		such as: SELECT, INSERT, UPDATE, or DELETE statement.

		A HAVING clause in SQL specifies that an SQL SELECT statement must only return rows 
		where aggregate values meet the specified conditions.

		WHERE is taken into account at an earlier stage of 
		a query execution, filtering the rows read from the tables. If a query contains GROUP BY,
		data from the tables are grouped and aggregated. After the aggregating operation, 
		HAVING is applied, filtering out the rows that don't match the specified conditions. 
		Therefore, WHERE applies to data read from tables, and HAVING should only apply to aggregated data, 
		which are not known in the initial stage of a query.

		To view the present condition formed by the GROUP BY clause, the HAVING clause is used.


9.	Can there be multiple group by columns?

		A GROUP BY statement in SQL specifies that a SQL SELECT statement partitions 
		result rows into groups, based on their values in one or several columns. 
		Typically, grouping is used to apply some sort of aggregate function for each group.

		Group By X means put all those with the same value for X in the one group.

		Group By X, Y means put all those with the same values for both X and Y in the one group.

		Table: Subject_Selection

		+---------+----------+----------+
		| Subject | Semester | Attendee |
		+---------+----------+----------+
		| ITB001  |        1 | John     |
		| ITB001  |        1 | Bob      |
		| ITB001  |        1 | Mickey   |
		| ITB001  |        2 | Jenny    |
		| ITB001  |        2 | James    |
		| MKB114  |        1 | John     |
		| MKB114  |        1 | Erica    |
		+---------+----------+----------+

		group by Subject :

		+---------+-------+
		| Subject | Count |
		+---------+-------+
		| ITB001  |     5 |
		| MKB114  |     2 |
		+---------+-------+

		# of rows with subject = ITB001 is 5

		group by Subject, Semester:

		+---------+----------+-------+
		| Subject | Semester | Count |
		+---------+----------+-------+
		| ITB001  |        1 |     3 |
		| ITB001  |        2 |     2 |
		| MKB114  |        1 |     2 |
		+---------+----------+-------+

		# of rows with subject = ITB001 and Semester=1 is 3
		# of rows with subject = ITB001 and Semester=2 is 2

		Therefore, it is possible group by mutiple columns. 
		
	
		

======================================================================= */

USE AdventureWorks2019
GO

-- 1. 504

SELECT COUNT(1) 
FROM [Production].[Product]

-- 2. 

SELECT COUNT(1) 
FROM [Production].[Product]
WHERE [ProductSubcategoryID] IS NOT NULL

-- 3. 

SELECT 
		 [ProductSubcategoryID]
		,COUNT(ProductID) AS CountedProducts 
FROM [Production].[Product]
WHERE [ProductSubcategoryID] IS NOT NULL
GROUP BY [ProductSubcategoryID]

-- 4. 

SELECT 
	COUNT(1) 
FROM [Production].[Product]
WHERE [ProductSubcategoryID] IS NULL
GROUP BY [ProductSubcategoryID]

-- 5. 

SELECT 
	SUM(Quantity)
FROM [Production].[ProductInventory] 
GROUP BY [ProductID]

-- 6. 

SELECT 
		 [ProductID]
		,SUM(Quantity) AS TheSum
FROM [Production].[ProductInventory] 
WHERE [LocationID] = 40
GROUP BY [ProductID]
HAVING SUM(Quantity) < 100

-- 7. 

SELECT 
		 [Shelf]
		,[ProductID]
		,SUM(Quantity) AS TheSum
FROM [Production].[ProductInventory] 
WHERE [LocationID] = 40
GROUP BY 
		[ProductID], 
		[Shelf]

HAVING SUM(Quantity) < 100

-- 8. 

SELECT 
		AVG(Quantity) AS TheAvg
FROM [Production].[ProductInventory] 
WHERE [LocationID] = 10


-- 9. 

SELECT 
		 [Shelf]

		,AVG(Quantity) AS TheAvg
FROM [Production].[ProductInventory] 
GROUP BY 
	
		 [Shelf]
		


-- 10. 

SELECT 
		 [Shelf]
	
		,AVG(Quantity) AS TheAvg
FROM [Production].[ProductInventory] 
GROUP BY 
		 
		 [Shelf]
HAVING Shelf <> 'N/A'	

-- 11. 

SELECT 
		 [Color]
		,[Class]
		,COUNT(Color) AS TheCount
		,AVG(ListPrice) AS TheAvg
FROM [Production].[Product] 
WHERE 
		[Color] IS NOT NULL
	OR  [Class] IS NOT NULL
GROUP BY 
	     [Color]
		,[Class]

-- 12. 

SELECT 
		  [c].[Name] AS Country                        
		 ,[s].[Name] AS Province
FROM 
		 [Person].[CountryRegion] AS c
	JOIN
		 [Person].[StateProvince] AS s
ON
		 c.CountryRegionCode = s.CountryRegionCode

-- 13. 

SELECT 
		  [c].[Name] AS Country                        
		 ,[s].[Name] AS Province
FROM 
		 [Person].[CountryRegion] AS c
	JOIN
		 [Person].[StateProvince] AS s
ON
		 c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name = 'Germany' OR c.Name = 'Canada'

-- Using Northwnd Database

USE Northwind
GO

-- 14.


SELECT 
		  [ProductID]
		 ,SUM(Quantity)	
FROM 
			[Order Details] AS od
INNER JOIN	[Orders] AS o
ON   od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
AND o.OrderDate < DATEADD(year,-20,GETDATE())
GROUP BY [ProductID]
HAVING SUM(Quantity) > 0


		

-- 15.

SELECT 
		 TOP 5 o.ShipPostalCode
		,SUM(Quantity)	
FROM 
			[Order Details] AS od
INNER JOIN	[Orders] AS o
ON   od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
GROUP BY [ShipPostalCode]
ORDER BY SUM(Quantity)	 DESC


-- 16.

SELECT 
		 TOP 5 o.ShipPostalCode
		,SUM(Quantity)	
FROM 
			[Order Details] AS od
INNER JOIN	[Orders] AS o
ON   od.OrderID = o.OrderID
WHERE o.ShipPostalCode IS NOT NULL
AND o.OrderDate < DATEADD(year,-20,GETDATE())
GROUP BY [ShipPostalCode]
ORDER BY SUM(Quantity)	 DESC

-- 17.

SELECT 
		 c.City
		,COUNT(CustomerID)	
FROM 
			[Customers] AS c
GROUP BY [City]

-- 18.

SELECT 
		 c.City
		,COUNT(CustomerID) AS CountOfCustomers	
FROM 
			[Customers] AS c
GROUP BY [City]
HAVING COUNT(CustomerID) > 10

-- 19.

SELECT 
		 c.[ContactName]	
FROM 
			[Customers] AS c
RIGHT JOIN	[Orders] AS o
ON   o.[CustomerID] = c.CustomerID
WHERE o.OrderDate > '1/1/98 '
GROUP BY c.[ContactName]

-- 20. 

SELECT 
		 DISTINCT c.[ContactName]	
		 ,o.OrderDate 
FROM 
			[Customers] AS c
RIGHT JOIN	[Orders] AS o
ON   o.[CustomerID] = c.CustomerID
ORDER BY o.OrderDate DESC

-- 21.

SELECT 
		  c.[ContactName]	
		 ,COUNT(o.OrderID) AS NumberOfBought
FROM 
			[Customers] AS c
LEFT JOIN	[Orders] AS o
ON   o.[CustomerID] = c.CustomerID
GROUP BY c.[ContactName]

-- 22.


SELECT 
		  c.[CustomerID]	
		 ,COUNT(o.OrderID) AS NumberOfBought
FROM 
			[Customers] AS c
LEFT JOIN	[Orders] AS o
ON   o.[CustomerID] = c.CustomerID
GROUP BY  c.[CustomerID]
HAVING COUNT(o.OrderID) > 100

-- 23.


SELECT 
		  c.[CustomerID]	
		 ,COUNT(o.OrderID) AS NumberOfBought
FROM 
			[Customers] AS c
LEFT JOIN	[Orders] AS o
ON   o.[CustomerID] = c.CustomerID
GROUP BY  c.[CustomerID]
HAVING COUNT(o.OrderID) > 100