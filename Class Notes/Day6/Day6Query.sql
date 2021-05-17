
--CREATE FUNCTION GetTotalEarning(@s DECIMAL(5,2), @c DECIMAL(5,2))
--RETURNs DECIMAL
--AS
--BEGIN
--DECLARE @r DECIMAL(5,2)
--	IF @c IS NULL
--		SET @r=@s
--	ELSE 
--		SET @r=@s+@c
--	RETURN @r
--END
--CREATE TABLE Product
--(
--	ProductID INT PRIMARY KEY,
--	ProductName NVARCHAR(10),
--	UnitPrice DECIMAL(5,2),
--	Qty int NOT NULL
--)
--CREATE TABLE Sale
--(
--	id INT PRIMARY KEY,
--	ProductID INT REFERENCES Product(ProductID),
--	SoldQty int NOT NULL
--)
--CREATE TRIGGER trg_after_update_sale
--ON Sale
--After update
--AS 
--BEGIN
--	DECLARE @id int, @productid int, @soldqty int, @oldqty int
--	SELECT @id = id, @productid = productid, 
--END

-- VERY IMPORTANT INDEX
-- CTE, JOIN, PROCEDURE
-- Will be ASKED at every interview
--inserted
-- deleted
/*
Create trigger trg_after_insert_sale
on Sale
after insert
as
begin 
   declare @id int, @productid int, @soldQty int
   select @id=id, @productid= productid, @soldQty= soldqty from inserted
   update product set qty = qty-@soldQty where id=@productid
end

Create trigger trg_after_delete_sale
on Sale
after delete
as
begin 
   declare @id int, @productid int, @soldQty int
   select @id=id, @productid= productid, @soldQty= soldqty from deleted
   update product set qty = qty+@soldQty where id=@productid
end

Create trigger trg_after_update_sale
on Sale
after update
as
begin 
   declare @id int, @productid int, @soldQty int, @oldQty int
   select @id=id, @productid= productid, @soldQty= soldqty from inserted
   Select @oldQty= soldQty from deleted
   update product set qty = qty+@oldQty-@soldQty where id=@productid
end


Select * from product
select * from Sale

insert into sale values (3,20)

delete from sale where id=1

update sale set soldqty=30 where id=2
INDEX is a object to fetch data faster
One of the best way to reduce Disk I/O is to use an index
Allows SQL Server to fetch data without scanning the entire table

Why is it important and how?
*/
/*CREATE TABLE AppUser 
(Id int primary key identity(1,1),
CustomerName VARCHAR(20),
Mobile varchar(10) UNIQUE
)
*/

/*
1.Clustered index is created automatically
when a primary key is created, non-clustered
	index is created when a unique constraint
	is applied
2.A table can have only one clustered index
but it can have multiple non-clustered -255
3. A clustered index will by default sort
the data in a physical order but non-clustered
index can not sort the data
*/

/*
	1. When you have multiple rows (millions)
	and you need to fetch upto 5% to 10%
	2. create index on a column which is 
	frequently used in the where clause
	3. Create index on a column which
	can contain multiple null values
	4. create index on column with foreigh key
	relationship(those column which
	participates that 
	)
*/
--CLUSTERED / nonclustered
CREATE  INDEX IX_USER_Name_AppUser on AppUser
(
  AppUserName
)

--Heap Table Storage

CREATE TABLE DEMO(ID int, DName varchar(20))
CREATE CLUSTERED INDEX IX_ID_DEMO on DEMO(ID)
SELECT * FROM DEMO

Find inverntory management se databse structure
 near the reality as possible


 sortly inventory management software,
 made easy
 for free trial
 1 to improve performance
 Databse Normalize 
 index 
 get rid of subquery , use join
 long trans to short
