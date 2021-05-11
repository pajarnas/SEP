   --Ex: List all Sales Persons and their number of orders.
WITH Sales_CTE (SalesPersonID, NumberOfOrders, MaxDate)
AS
(
    SELECT SalesPersonID, COUNT(*), MAX(OrderDate)
    FROM Sales.SalesOrderHeader
    GROUP BY SalesPersonID
)
SELECT * FROM Sales_CTE 
