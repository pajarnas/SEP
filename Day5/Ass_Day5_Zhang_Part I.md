

---
title: Day5 Assignment Part I
date: 05/10/2021
author: Shiqi Zhang

---



## What is an object in SQL?

Microsoft SQL Server provides objects and counters that can be used by System Monitor to monitor activity in computers running an instance of SQL Server. **An object is any SQL Server resource, such as a SQL Server lock or Windows process.** Each object contains one or more counters that determine various aspects of the objects to monitor. For example, the **SQL Server Locks** object contains counters called **Number of Deadlocks/sec** and **Lock Timeouts/sec**.



## What is Index? What are the advantages and disadvantages of using Indexes?

An index is an on-disk structure associated with a table or view that speeds retrieval of rows from the table or view. An index contains keys built from one or more columns in the table or view. These keys are stored in a structure (B-tree) that enables SQL Server to find the row or rows associated with the key values quickly and efficiently.

Advantages

- Speed up SELECT query
- Helps to make a row unique or without duplicates(primary,unique) 
- If index is set to fill-text index, then we can search against large string values. for example to find a word from a sentence etc.

Disadvantages

- Indexes take additional disk space.
- indexes slow down INSERT,UPDATE and DELETE, but will speed up UPDATE if the WHERE condition has an indexed field.  INSERT, UPDATE and DELETE becomes slower because on each operation the indexes must also be updated. 

## What are the types of Indexes?

| **Type**                    | **Description**                                              |
| --------------------------- | ------------------------------------------------------------ |
| Clustered                   | A clustered index sorts and stores the data rows of the table or view in order based on the index key. This type of index is implemented as a B-tree structure that supports fast retrieval of the rows, based on their key values. |
| Nonclustered                | A nonclustered index can be defined on a table or view with a clustered index or on a heap. Each row in the index contains the key value and a row locator. This locator points to the data row in the clustered index or heap having the key value. The rows in the index are stored in the order of the key values, but the data rows are not guaranteed to be in any particular order unless they are in a clustered index. |
| Unique                      | A unique index ensures that the key contains no duplicate values and therefore every row in the table or view is in some way unique. |
| Index with included columns | A nonclustered index that is extended to include nonkey columns in addition to the key columns. |
| Full-text                   | A special type of token-based functional index that is built and maintained by the Microsoft Full-Text Engine for SQL Server. It provides efficient support for sophisticated word searches in character string data. |
| Spatial                     | A spatial index provides the ability to perform certain operations more efficiently on spatial objects (*spatial data*) in a column of the **geometry** data type. The spatial index reduces the number of objects on which relatively costly spatial operations need to be applied. |
| Filtered                    | An optimized nonclustered index, especially suited to cover queries that select from a well-defined subset of data. It uses a filter predicate to index a portion of rows in the table. A well-designed filtered index can improve query performance, reduce index maintenance costs, and reduce index storage costs compared with full-table indexes. |
| XML                         | A shredded, and persisted, representation of the XML binary large objects (BLOBs) in the **xml** data type column. |

## Does SQL Server automatically create indexes when a table is created? If yes,     under which constraints?

SQL Server indexes can be created indirectly by defining the PRIMARY KEY and the UNIQUE constraint within the CREATE TABLE or ALTER TABLE statements. SQL Server will create a unique clustered index to enforce the PRIMARY KEY constraint unless you already define a clustered index on that table. Recall that we cannot create more one clustered index on each table. A unique non-clustered index will be created automatically to enforce the UNIQUE constraint. You should be granted CONTROL or ALTER permission on the table in order to be able to can create an index.

## Can a table have multiple clustered index? Why?

No. Clustered indexes sort and store the data rows in the table or view based on their key values. These are the columns included in the index definition. **There can be only one clustered index per table, because the data rows themselves can be stored in only one order.**  

The only time the data rows in a table are stored in sorted order is when the table contains a clustered index. When a table has a clustered index, the table is called a clustered table. If a table has no clustered index, its data rows are stored in an unordered structure called a heap.

1. Can an index be created on multiple columns? Is yes, is the order of columns matter?

   > you should put columns that will be the most selective at the beginning of the index declaration.

   Correct. Indexes can be composites - composed of multiple columns - and the order is important because of the leftmost principle. Reason is, that the database checks the list from left to right, and has to find a corresponding column reference matching the order defined. For example, having an index on an address table with columns:

   - Address
   - City
   - State

   Any query using the `address` column can utilize the index, but if the query only has either `city` and/or `state` references - the index can not be used. This is because the leftmost column isn't referenced. Query performance should tell you which is optimal - individual indexes, or multiple composites with different orders.

   

   

## Can indexes be created on views?

Yes. The first index created on a view must be a unique clustered index. After the unique clustered index has been created, you can create more nonclustered indexes. Creating a unique clustered index on a view improves query performance because the view is stored in the database in the same way a table with a clustered index is stored. The query optimizer may use indexed views to speed up the query execution. The view does not have to be referenced in the query for the optimizer to consider that view for a substitution.

## What is normalization? What are the steps (normal forms) to achieve normalization?

1. WHAT

   Database normalization is a process used for data modelling or database creation, where you organise your data and tables so it can be added and updated efficiently. 

2. WHO

   It’s something a person does manually, as opposed to a system or a tool doing it. It’s commonly done by database developers and database administrators.

3. WHERE

   It can be done on any relational database, where data is stored in tables which are linked to each other. This means that normalization in a DBMS can be done in Oracle, Microsoft SQL Server, MySQL, PostgreSQL and any other type of database.

4. HOW

   a. Use Normal Forms. 

   The process of normalization involves **applying rules to a set of data**. Each of these rules transforms the data to a certain structure, called a **normal form**. 

   There are **three main normal forms** that you should consider.

   Whenever **the first rule** is applied, the data is in “**first normal form**“. Then, the **second rule** is applied and the data is in “**second normal form**“. The **third rule** is then applied and the data is in “**third normal form**“.

   Fourth and fifth normal forms are then achieved from their specific rules.

   b. **First Normal Form**

   Ask two questions, 

    	1. Does the combination of all columns make a unique row every single time?
    	2. What field can be used to uniquely identify the row?
   First normal form enforces these criteria:

       - Every column/attribute must be unique in each table
       - Create a separate table for each set of related data
       - All entries must be single-valued and atomic

   c. **Second Normal Form**

   ```
   1. Fulfil the requirements of first normal form 
   2. Each non-key attribute must be functionally dependent on the primary key
   ```

   It means that the first normal form rules have been applied. It also means that **each field that is not the primary key is determined by that primary key**, so it is specific to that record. This is what “**functional dependency**” means.

   d. **third normal form**

   Third normal form is the final stage of the most common normalization process. The rule for this is:

   ```
   1. Fulfils the requirements of second normal form 
   2. Has no transitive functional dependency 
   ```

   It means that **every attribute that is not the primary key must depend on the primary key and the primary key only**. 

   For example:

   - Column A determines column B
   - Column B determines column C
   - Therefore, column A determines C

   This means that *column A determines column B which determines column C*. This is a **transitive functional dependency**, and it should be removed. Column C should be in a separate table.

5. WHY

   - Make the database more **efficient**
   - Prevent the same data from being stored in **more than one place** (called an “insert anomaly”)
   - Prevent updates being made to **some data but not others** (called an “update anomaly”)
   - Prevent data not being deleted when it is supposed to be, or from data being lost when it is not supposed to be (called a “delete anomaly”)
   - Ensure the data is **accurate**
   - Reduce the **storage space** that a database takes up
   - Ensure the **queries** on a database run as fast as possible

## What is denormalization and under which scenarios can it be preferable?

**Denormalization** is a **database optimization technique** in which we **add redundant data to one or more tables**. This can help us **avoid costly joins** in a relational database. Note that **denormalization does not mean not doing normalization**. It is an optimization **technique that is applied after doing normalization**. 

In a traditional normalized database, we store data in separate logical tables and attempt to minimize redundant data. We may strive to have only one copy of each piece of data in database. 

For example, in a normalized database, we might have a Courses table and a Teachers table. Each entry in Courses would store the teacherID for a Course but not the teacherName. When we need to retrieve a list of all Courses with the Teacher name, we would do a join between these two tables. 

In some ways, this is great; if a teacher changes his or her name, we only have to update the name in one place. 
The drawback is that **if tables are large, we may spend an unnecessarily long time doing joins on tables.** 
Denormalization, then, strikes a different compromise. **Under denormalization, we decide that we’re okay with some redundancy and some extra effort to update the database in order to get the efficiency advantages of fewer joins.** 

**Pros of Denormalization:-** 

1. Retrieving data is faster since we do fewer joins
2. Queries to retrieve can be simpler(and therefore less likely to have bugs), 
   since we need to look at fewer tables.

**Cons of Denormalization:-** 

1. Updates and inserts are more expensive.
2. Denormalization can make update and insert code harder to write.
3. Data may be inconsistent . Which is the “correct” value for a piece of data?
4. Data redundancy necessitates more storage.

## How do you achieve Data Integrity in SQL Server?

1. Data Integrity is used to maintain accuracy and consistency of data in a table.

2. **Classification of Data Integrity**

   1. System/Pre Defined Integrity

   2. User-Defined Integrity

      ![Classification of Data Integrity](https://csharpcorner.azureedge.net/article/data-integrityin-sql-server/Images/diagram1.PNG)

3. System/Pre Defined Integrity

   We can implement this using constraints. This is divided into three categories.

   ![System/Pre Defined Integrity](https://csharpcorner.azureedge.net/article/data-integrityin-sql-server/Images/daigram2.PNG)

   **Entity Integrity**
   Entity integrity ensures **each row in a table is a uniquely identifiable entity**. We can **apply Entity integrity to the Table by specifying a primary key**, **unique key**, and **not null**.

   **Referential Integrity**
   Referential integrity ensures **the relationship between the Tables.**

   We can apply this using a **Foreign Key constraint**.

   **Domain Integrity**
   Domain integrity **ensures the data values in a database follow defined rules for values, range, and format.** A database can enforce these rules using **Check** and **Default** **constraints**.

   **Constraints**

   Constraints are used for enforcing, validating, or restricting data.

   Constraints are used to restrict data in a Table.

   **Check**

   It is used to verify or check the values with the user-defined conditions on a column.

   It can apply on any datatypes.

   A Table can contain any number of Not Null constraints.

   **Example**

   ```
   Create table demo4(id int, Age int check(Age between 18 and 24)) 
   ```

   **Three types of relationships**:

   **One to one**
   A row in a Table associated with a row in the other Table is known as one to one relationship.

   **One to many or many to one**
   A row in a Table associated with any number of rows in the other Table is known as a one-to-many relationship.

   **Many to many relationship**
   Many rows in a table are associated with many rows in the other Table. This is called a many to many relationship

## What are the different kinds of constraint do SQL Server have?

**Default, Unique, Not Null, Check, PrimaryKey, ForeignKey**

### Default

Default Constraint is used to assign the default value to the particular column in the Table.

By using this constraint we can avoid the system-defined value from a column while the user inserts values in the Table.

A Table can contain any number of default constraints.

Default constraints can be applied on any datatypes.

**Example**

```sql
Create table Demo(Id int,name varchar(50),Salary int default 15000) 
```



### **Unique**

Unique constraints are used to avoid duplicate data in a column but accept null values in the column. 

It also applies to any datatypes.

A Table can contain any number of unique constraints.

```
Create table demo1(id int unique,name varchar(50),price int unique) 
```

### **Not Null**

It avoids null values from column-accepted duplicate values.

It can apply on any datatype.

A Table can contain any number of not null constraints.

**Example**

```
Create table Demo2(id int not null, age int) 
```

**Important Points to Remember**

Unique and Not Null constraints have their own disadvantage, that is **accepting null and duplicate values into the Table**. So to overcome the above drawbacks we write the combination of Unique and Not Null on a column.

**Check**

t is used to verify or check the values with the user-defined conditions on a column.

It can apply on any datatypes.

A Table can contain any number of Not Null constraints.

**Example**

```
Create table demo4(id int, Age int check(Age between 18 and 24)) 
```



### **Primary key**

Primary key adds features of unique and not null constraints.

By using primary key we can avoid duplicate and null values for the column.

It can apply on any datatype like int, char, etc.

A table can contain one primary key only.

**Example**

```
Create table demo5(id int primary key, salary money) 
```

**Composite primary key**
If a primary key is created on multiple columns the composite key can apply to a maximum of 16 columns in a table.

**Example**

```
create table demo6(id int,name varchar(50),primary key(id,name)) 
```

Important points to remember,

1. We can apply **only a single primary key** in a Table.
2. We can apply the primary key constraint on multiple columns in a Table.
3. The primary key is also called the composite key and candidate key.

### **Foreign Key**

Most important part of the database is to create the relationship between the database Table.

The relationship provides a method for link data stored in two or more Tables so that we can retrieve data in an efficient way and verify the dependency of one table data in other Table.

**Important Rules to Create Foreign Key constraint**

In order to create a relation between multiple tables, we must specify a Foreign key in a Table that references a column in another Table which is the primary key column.

We require two tables for binding with each other and those two tables have a common column name and those columns should be the same datatype.

- If a table contains a primary key then it can be called parent Table.
- If a Table contains a foreign key reference then it can be called a Child Table.

We can apply the foreign key reference on any datatypes.

By default foreign key accepts duplicate and null values.

We can apply a maximum of 253 foreign keys on a single table.

**Example**

Step 1

```
Create table employee(id int primary key,name varchar(50),age int) 
```

Step 2

```
Create table company(email varchar(50),address varchar(50),id int primary key foreign references employee(id)) 
```

Now, check the relation between the two tables. Click the database name, click database diagrams, click on new database diagrams, and select table employee and company and see the relation between these tables.

![Relation Between Tables](https://csharpcorner.azureedge.net/article/data-integrityin-sql-server/Images/f1.PNG) 

If we want to delete or update the record in the foreign key child table then we need to follow some rules.

### **For delete**

It is used to delete key values in the parent table which is referenced by the foreign key in other tables. All rows that contain those foreign key in child table are deleted.

### **For Update**

It is used to update a key value in the parent table which is referenced by the foreign key in another table. All rows that contain the foreign keys in the child table are also updated.

## What is the difference between Primary Key and Unique Key?

**Primary Key** is a column that is used **to uniquely identify each tuple of the table**.

It is used to **add integrity constraints to the table**. Only one primary key is allowed to be used in a table. Duplicate and NULL (empty) values are not valid in the case of the primary key. Primary keys can be used as foreign keys for other tables too.

**Unique key** is a constraint that is used **to uniquely identify a tuple in a table**.

Multiple unique keys can present in a table. NULL values are allowed in case of a unique key. These can also be used as foreign keys for another table.

## What is foreign key?

A **foreign key** is a column or group of **columns** in a relational database table that **provides a link between data in two tables**. It acts as a cross-reference between tables because **it references the primary key of another table**, thereby establishing a link between them.

The majority of tables in a relational database system adhere to the foreign key concept. In complex databases and data warehouses, data in a domain must be added across multiple tables, thus maintaining a relationship between them. The concept of referential integrity is derived from foreign key theory.



## Can a table have multiple foreign keys?

Yes. But too many foreign keys would add complexity and lower readability. 

## Does a foreign key have to be unique? Can it be null?

No. There are many relationships like OneToMany, ManyToMany. It is likely to have the same foreign keys in one single table.

Yes. If the related record was not generated, it will be the Null on a foreign key. 

## Can we create indexes on Table Variables or Temporary Tables?

 \#table will create a temporary table that you need to drop or it will persist in your database. @table is a table variable that will not persist longer than your script.

You can create indexes on both type of tables.

```sql
DECLARE @RDTABLE TABLE (TLCDE VARCHAR(12), TLTYP VARCHAR(2), TLEFFDAT DATETIME, TLRATFCT DECIMAL(29,6), INDEX [index_name] [NONCLUSTERED/CLUSTERED](column_name))
```

## What is Transaction? What types of transaction levels are there in SQL Server?

### Transactions by definition are **a logical unit of work Transaction is a single recoverable unit of work that executes eithe**r:

–Completely (COMMIT)

–Not at all (ROLLBACK)

A logical unit of work is a SQL operation or a set of SQL statements executed against a database

–Usually include **at least one statement**

–**Changes the database from one consistent state to another**

After a transaction is committed, it can not be undone

When a transaction is rolled back, all modifications of the transaction are undone

### Transaction must exhibit ACID Properties

Atomicity

Consistency

Isolation

Durability

### Transaction isolation levels control the following

- Whether locks are taken when data is read, and what type of locks are requested.
- How long the read locks are held.
- Whether a read operation referencing rows modified by another transaction:
  - Block until the exclusive lock on the row is freed.
  - Retrieve the committed version of the row that existed at the time the statement or transaction started.
  - Read the uncommitted data modification.

| Isolation Level  | Dirty Read | Non Repeatable Read | Phantom |
| :--------------- | :--------- | :------------------ | :------ |
| Read uncommitted | Yes        | Yes                 | Yes     |
| Read committed   | No         | Yes                 | Yes     |
| Repeatable read  | No         | No                  | Yes     |
| Snapshot         | No         | No                  | No      |
| Serializable     | No         | No                  | No      |