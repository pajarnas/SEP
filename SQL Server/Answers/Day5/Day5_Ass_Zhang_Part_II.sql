/* =========================================
Object: Day 5 Assignment 
Author: Saige Zhang
Create date: May 11, 2021
Description: SQL: Comprehensive practice
============================================ */

--1.
CREATE TABLE customer
  (
     cust_id INT,
     iname   VARCHAR(50)
  )

CREATE TABLE [order]
  (
     order_id   INT,
     cust_id    INT,
     amount     MONEY,
     order_date SMALLDATETIME
  ) 
BEGIN transaction
SELECT 
		c.cust_id
	   ,SUM(od.order_id)
FROM
		customer AS c
INNER JOIN 
(
	SELECT 
		 o.order_id
		,o.cust_id
	FROM
		[order] AS o
	WHERE
		o.order_date 
	BETWEEN
			'1/1/2002'
	AND		'12/31/2002'
) AS od
		
ON      c.cust_id = od.cust_id
GROUP BY
		c.cust_id
COMMIT 
--2.
CREATE TABLE customer
  (
     cust_id INT,
     iname   VARCHAR(50)
  )

CREATE TABLE [order]
  (
     order_id   INT,
     cust_id    INT,
     amount     MONEY,
     order_date SMALLDATETIME
  )

SELECT *
FROM   person
WHERE  lastname LIKE 'A%' 

--3.


SELECT 
		 e.[name]
		,COUNT(*)
FROM
		person p
LEFT JOIN 
(
		SELECT * 
		FROM   person p 
		WHERE  p.manager_id IS NULL
) AS e
ON
		p.person_id = e.manager_id
GROUP BY
e.person_id

--4.
/*
INSERT, UPDATE, or DELETE statements
CREATE, ALTER, and DROP statements, stored procedures DDL-like operations
LOGON event

SQL Server triggers are special stored procedures that are executed automatically in response to the database object,
database, and server events. 
SQL Server provides three type of triggers:

1.Data manipulation language (DML) triggers 
DML triggers run when a user tries to modify data through a data manipulation language (DML) event.
DML events are INSERT, UPDATE, or DELETE statements on a table or view. 
These triggers fire when any valid event fires, whether table rows are affected or not. 
2. Data definition language (DDL) triggers 
which fire in response to CREATE, ALTER, and DROP statements. 
These events primarily correspond to 
Transact-SQL CREATE, ALTER, and DROP statements, and certain system stored procedures 
that perform DDL-like operations.

3. Logon triggers fire in response to the LOGON event that's raised when a user's session is being established.
You can create triggers directly from Transact-SQL statements or from methods of assemblies that are created in the
Microsoft .NET Framework common language runtime (CLR) and uploaded to an instance of SQL Server. 
SQL Server lets you create multiple triggers for any specific statement.
*/
--5.

CREATE TABLE [Address]
(
	AddressID INT PRIMARY KEY,
	AddressLine1 NVARCHAR(255),
	AddressLine2 NVARCHAR(255) NULL,
	[State] NVARCHAR(20),
	City NVARCHAR(20),
	CountryName VARCHAR(20),
	PostalCode NVARCHAR(15)
)

CREATE TABLE MailBoxAddress
(
	MailBoxAddressID INT PRIMARY KEY,
	MailBoxName NVARCHAR(15),
	AddressID INT REFERENCES [Address](AddressID)
)


CREATE TABLE Company
(
    CompanyId   INT PRIMARY KEY,
    CompanyName VARCHAR(100) NOT NULL
)

CREATE TABLE Division
(
    DivisionID   INT PRIMARY KEY,
    DivisionName VARCHAR(100) NOT NULL,
	CompanyId INT REFERENCES Company(CompanyId),
	DivisionAddressID INT REFERENCES [Address](AddressID)
) 
CREATE TABLE PersonName
(
	PersonNameID INT PRIMARY KEY,
	FirstName VARCHAR(20),
	LastName VARCHAR(20),
	MiddleName VARCHAR(20) NULL
)

CREATE TABLE Contact
(
    ContactID   INT PRIMARY KEY,
    ContactNameID INT REFERENCES [PersonName](PersonNameID),
	DivisionID   INT REFERENCES Division(DivisionID),
) 

CREATE TABLE ContactAddress
(
	ContactAddressID INT PRIMARY KEY,
	ContactMailBoxAddress INT REFERENCES [MailBoxAddress](MailBoxAddressID)
)

