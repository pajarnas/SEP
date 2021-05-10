---
title: SEP Assignment IV: Concept of View, Stored Procedure, Function, Trigger
date: 05/09/2021
Author: Shiqi Zhang

---

## What is View? What are the benefits of using views?



View is a virtual table whose contents (columns and rows) are defined by a query.

In a database, a **view** is the **result set** of a *stored* query on the data, which the [database](https://en.wikipedia.org/wiki/Database) users can query just as they would in a persistent database collection object. This pre-established query command is kept in the database dictionary. Unlike ordinary *base tables* in a [relational database](https://en.wikipedia.org/wiki/Relational_database), a view does not form part of the [physical schema](https://en.wikipedia.org/wiki/Database_design): as a result set, it is a virtual table computed or collated dynamically from data in the database when access to that view is requested. Changes applied to the data in a relevant *underlying table* are reflected in the data shown in subsequent invocations of the view. In some [NoSQL](https://en.wikipedia.org/wiki/NoSQL) databases, views are the only way to query data[*[how?](https://en.wikipedia.org/wiki/Wikipedia:Please_clarify)*].

Views can provide advantages over tables:

- Views can **represent a subset of the data** contained in a table. Consequently, **a view can limit the degree of exposure of the underlying tables to the outer world:** a given user may have permission to query the view, while denied access to the rest of the base table.
- Views can [join](https://en.wikipedia.org/wiki/Join_(SQL)) and simplify multiple tables into a single virtual table.
- Views can act as aggregated tables, where the [database engine](https://en.wikipedia.org/wiki/Database_engine) aggregates data ([sum](https://en.wikipedia.org/wiki/Summation), [average](https://en.wikipedia.org/wiki/Average), etc.) and presents the calculated results as part of the data.
- Views can **hide the complexity of data**. For example, a view could appear as Sales2000 or Sales2001, transparently [partitioning](https://en.wikipedia.org/wiki/Partition_(database)) the actual underlying table.
- Views **take very little space to store**; the database contains **only the definition of a view**, not a copy of all the data that it presents.
- Depending on the [SQL](https://en.wikipedia.org/wiki/SQL) engine used, views can provide extra security.

## Can data be modified through views?

You can modify the data of an underlying base table through a view, as long as the following conditions are true:

- Any modifications, including UPDATE, INSERT, and DELETE statements, must reference columns from only one base table.
- The columns being modified in the view must directly reference the underlying data in the table columns. The columns cannot be derived in any other way, such as through the following:
  - An aggregate function: AVG, COUNT, SUM, MIN, MAX, GROUPING, STDEV, STDEVP, VAR, and VARP.
  - A computation. The column cannot be computed from an expression that uses other columns. Columns that are formed by using the set operators UNION, UNION ALL, CROSSJOIN, EXCEPT, and INTERSECT amount to a computation and are also not updatable.
- The columns being modified are not affected by GROUP BY, HAVING, or DISTINCT clauses.
- TOP is not used anywhere in the *select_statement* of the view together with the WITH CHECK OPTION clause.

## What is stored procedure and what are the benefits of using it?

Definition：

A stored procedure is a set of precompiled SQL statements that are used to perform a special task. 

A stored procedure (also termed proc, storp, sproc, StoPro, StoredProc, StoreProc, sp, or SP) is a subroutine available to applications that access a relational database management system (RDBMS).

A stored procedure in SQL Server is a group of one or more Transact-SQL statements or a reference to a Microsoft .NET Framework common runtime language (CLR) method. Procedures resemble constructs in other programming languages because they can:

- Accept input parameters and return multiple values in the form of output parameters to the calling program.
- Contain programming statements that perform operations in the database. These include calling other procedures.
- Return a status value to a calling program to indicate success or failure (and the reason for failure).

##  

Types of Stored Procedures:

**User-defined**
A user-defined procedure can be created in a user-defined database or in all system databases except the **Resource** database. The procedure can be developed in either Transact-SQL or as a reference to a Microsoft .NET Framework common runtime language (CLR) method.

**Temporary**
Temporary procedures are a form of user-defined procedures. The temporary procedures are like a permanent procedure, except temporary procedures are stored in **tempdb**. There are two types of temporary procedures: local and global. They differ from each other in their names, their visibility, and their availability. Local temporary procedures have a single number sign (#) as the first character of their names; they are visible only to the current user connection, and they are deleted when the connection is closed. Global temporary procedures have two number signs (##) as the first two characters of their names; they are visible to any user after they are created, and they are deleted at the end of the last session using the procedure.

**System**
System procedures are included with SQL Server. They are physically stored in the internal, hidden **Resource** database and logically appear in the **sys** schema of every system- and user-defined database. In addition, the **msdb** database also contains system stored procedures in the **dbo** schema that are used for scheduling alerts and jobs. Because system procedures start with the prefix **sp_**, we recommend that you do not use this prefix when naming user-defined procedures. 

**Extended User-Defined**
Extended procedures enable creating external routines in a programming language such as C. These procedures are DLLs that an instance of SQL Server can dynamically load and run.

Benefits:

 1. Reduced server/client network traffic. 

    The commands in a procedure are executed as a single batch of code. This can significantly reduce network traffic between the server and client because **only the call to execute the procedure is sent across the network**. Without the code encapsulation provided by a procedure, every individual line of code would have to cross the network.

 2. Stronger security
    Multiple users and client programs can perform operations on underlying database objects through a procedure, even if the users and programs do not have direct permissions on those underlying objects. The procedure controls what processes and activities are performed and protects the underlying database objects. This eliminates the requirement to grant permissions at the individual object level and simplifies the security layers.

 3. Reuse of code
    The code for any repetitious database operation is the perfect candidate for encapsulation in procedures. This eliminates needless rewrites of the same code, decreases code inconsistency, and allows the code to be accessed and executed by any user or application possessing the necessary permissions.

 4. Easier maintenance
    When client applications call procedures and keep database operations in the data tier, only the procedures must be updated for any changes in the underlying database. The application tier remains separate and does not have to know how about any changes to database layouts, relationships, or processes.

 5. Improved performance
    By default, a procedure compiles the first time it is executed and creates an execution plan that is reused for subsequent executions. Since the query processor does not have to create a new plan, it typically takes less time to process the procedure.

## What is the difference between view and stored procedure?

A view represents a **virtual** table. You can join multiple tables in a view and use the view to present the data as if the data were coming from a single table. 

A stored procedure uses parameters to do a function... whether it is updating and inserting data, or returning single values or data sets.

A view is a shortcut to an sql statement. I can create view x which might represent

select * from table a join table b where a.key = b.key join table c on a.key = c.key

Now to call that much more complex query all I have to do is say select * from x. Because x is an alias or a view on the query underneath.

A procedure is something completely different. A procedure is a piece of PLSQL that performs some action. You can view a procedure as a piece of code that you can call from within your sql, or database to do some action.

In a practical sense a view is an alias to an sql statement where as a procedure is a set of code that can perform more actions than any single piece of SQL. You create procedures to do programmatic actions within your database. You create views to alias more complex pieces of sql to simplify your sql.

| **S.No.** | **View**                                                     | **Stored Procedure**                                         |
| --------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| 1         | Does not accepts **parameters**                              | Accept **parameters**                                        |
| 2         | Can be used as a building block in large query.              | Can not be used as a building block in large query.          |
| 3         | Can contain only **one single Select query**.                | Can contain **several statement** like if, else, loop etc.   |
| 4         | Can not perform modification to any table.                   | Can perform modification to one or several tables.           |
| 5         | Can be used (sometimes) as the target for Insert, update, delete queries. | Can not be used as the target for Insert, update, delete queries. |

## What is the difference between stored procedure and functions?

Stored Procedures are pre-compiled objects which are compiled for the first time and its compiled format is saved, which executes (compiled code) whenever it is called. 

A function is compiled and executed every time whenever it is called. A function must return a value and cannot modify the data received as parameters. 

A user-defined function is a Transact-SQL or common language runtime (CLR) routine that **accepts parameters**, **performs an action**, such as a complex calculation, **and returns the result of that action as a value**. The return value can either be **a scalar (single) value or a table**. Use this statement to create a reusable routine that can be used in these ways:

- In Transact-SQL statements such as SELECT
- In applications calling the function
- In the definition of another user-defined function
- To parameterize a view or improve the functionality of an indexed view
- To define a column in a table
- To define a CHECK constraint on a column
- To replace a stored procedure
- Use an inline function as a filter predicate for a security policy

|                   Functions (user defined)                   |                      Stored Procedures                       |
| :----------------------------------------------------------: | :----------------------------------------------------------: |
| A function has a **return type** and  **must return a single value** (which may be a scalar or a table). | A procedure has only integer return data type as indicate success or failure, it can return. But it returns any data type **using the OUT parameters**. |
| You cannot use a function **with** **Data Manipulation queries**. Only Select queries are allowed in functions. | allows **SELECT** as well as DML(I**NSERT/UPDATE/DELETE**) statement in it |
|                    Only input parameter.                     |                   input/output parameter.                    |
|           We **can't** use **transaction** in UDF.           |                We can use transaction in SP.                 |
|               **can't call SP** from function.               |              We **can call function** from SP.               |
|      We can use UDF in SELECT/ WHERE/ HAVING statement.      |     We can't use SP in SELECT/ WHERE/ HAVING statement.      |
|             We can't use Try-Catch block in UDF.             |  We can use exception handling using Try-Catch block in SP.  |





## Can stored procedure return multiple result sets?

Yes. For example,

```sql
CREATE PROC Production.ProductList @ProdName NVARCHAR(50),

-- in this case we return two results, but there is no limit

-- but each result needs to be saved in an output parameter

@FirstResult NVARCHAR(MAX) OUT, @SecondResult NVARCHAR(MAX) OUT

AS

 BEGIN

  -- First result set saved as JSON in an output variable 

  SELECT @FirstResult =

   (

   SELECT Product.ProductID, Product.Name, Product.ListPrice

    FROM Production.Product

    WHERE Product.Name LIKE @ProdName

   FOR JSON AUTO

   );

  -- Second result set saved as JSON in an output variable  

  SELECT @SecondResult =

   (

   SELECT P.Name, Count(S.ProductID) AS NumberOfOrders

    FROM Production.Product AS P

     JOIN Sales.SalesOrderDetail AS S

      ON P.ProductID = S.ProductID

    WHERE P.Name LIKE @ProdName

    GROUP BY P.Name

   FOR JSON AUTO

   );

 END;

GO
```



## Can stored procedure be executed as part of SELECT Statement? Why?

No. A stored procedure is a module of code. It does 'something' and may or may not return anything. It may also return multiple data sets. So really you can't select from it, because it isn't an object that you can select from. You can return the results of a stored procedure into a table, and then select from th

## What is Trigger? What types of Triggers are there?

A trigger is a special type of stored procedure that automatically runs when an event occurs in the database server. 

Two main types of triggers based on DDL or DML events: 

The **DML** Triggers and the **DDL** triggers. The DDL triggers will be fired in response to different Data Definition Language (DDL) events, such as executing CREATE, ALTER, DROP, GRANT, DENY, and REVOKE T-SQL statements. 

The **DDL** trigger can respond to the DDL actions by preventing these changes from affecting the database, perform another action in response to these DDL actions or recording these changes that are executed against the database.

Two main types of triggers based on timing of events: After or For trigger and Instead of trigger

If the trigger is fired, a special type of virtual tables called **Inserted** and **Deleted** tables will be used to keep the data values before and after the modification. The trigger statement will work under the scope of the same transaction that fires that trigger. This means that the transaction will not be committed completely until the trigger statement is completed successfully. On the other hand, the transaction will be rolled back if the trigger statement fails.



## What are the scenarios to use Triggers?

1. When you need to build a decent audit solution.
2. When you need to validate inserted or updated data in batches instead of row by row.
3. When you need to  use triggers to implement referential integrity across databases. 
4. When you need to be sure that certain events always happen when data is inserted, updated or deleted. 
5. When you need recursion.



## What is the difference between Trigger and Stored Procedure?



**TRIGGER:-**

- Trigger executes **implicitly**. Whenever an event INSERT, UPDATE, and DELETE occurs it executed automatically.
- We **cannot define a trigger inside another trigger**.
- **Transaction statements** are not allowed in the trigger.
- We **cannot return value** in a trigger.

**STORED PROCEDURE:-**

- A Procedure executed explicitly when the user using statements such as exec, EXECUTE, etc.
- We can define procedures inside another procedure. Also, we can use functions inside the stored procedure.
- Transaction statements such as COMMIT, ROLLBACK, and SAVEPOINT are allowed in the procedure.
- Stored procedures return a zero or N value. However, we can pass values as parameters.
- Return keyword used to exit the procedure.

