-- 1.	Display the SalesOrderID, ShipDate of the SalesOrderHeader table 
--		(Sales schema) to show SalesOrders that occurred within the period �7/28/2002� and �7/29/2014�
SELECT SO.SalesOrderID, SO.ShipDate
FROM Sales.SalesOrderHeader SO
WHERE SO.ShipDate BETWEEN '7/28/2002' and '7/29/2014';

-- 2.	Display only Products(Production schema) with a StandardCost below $110.00
--		(show ProductID, Name only)
SELECT P.ProductID, P.Name , P.Weight
FROM Production.Product P
WHERE P.StandardCost < 110.00;

-- 3.	Display ProductID, Name if its weight is unknown
SELECT P.ProductID, P.Name
FROM Production.Product P
WHERE  P.Weight is null ;

-- 4.	 Display all Products with a Silver, Black, or Red Color
SELECT P.ProductID, P.Name, P.Color
FROM Production.Product P
WHERE  P.Color in ('Silver', 'Black','Red');

-- 5.	 Display any Product with a Name starting with the letter B
SELECT P.ProductID, P.Name
FROM Production.Product P
WHERE  P.Name LIKE 'B%';

-- 6.	Run the following Query
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3
--Then write a query that displays any Product description with underscore value in its description.
SELECT P.ProductID, P.Name
FROM Production.Product P join Production.ProductDescription PD
on P.ProductID = PD.ProductDescriptionID
WHERE  PD.Description LIKE '%[_]%';

-- 7.	Calculate sum of TotalDue for each OrderDate in Sales.SalesOrderHeader table for the 
--		period between  '7/1/2001' and '7/31/2014'
SELECT SUM(SOH.TotalDue)
FROM  Sales.SalesOrderHeader SOH
WHERE SOH.OrderDate Between  '7/1/2001' and '7/31/2014';

-- 8.	 Display the Employees HireDate (note no repeated values are allowed)
SELECT DISTINCT  E.HireDate
FROM HumanResources.Employee E


-- 9.	 Calculate the average of the unique ListPrices in the Product table
SELECT AVG( DISTINCT  P.ListPrice)
FROM Production.Product P


-- 10.	Display the Product Name and its ListPrice within the values of 
--		100 and 120 the list should has the following format 
--		"The [product name] is only! [List price]" (the list will be sorted according to its ListPrice value)
SELECT  CONCAT('The [',P.Name,'] is only! [',P.ListPrice,']') 
FROM Production.Product P
WHERE  P.ListPrice between 100 and 120;
-- 11.	
-- a)	 Transfer the rowguid ,Name, SalesPersonID, Demographics from Sales.
--			Store table  in a newly created table named [store_Archive]
select S.rowguid , S.Name, S.SalesPersonID, S.Demographics into store_Archive
from Sales.Store S

Drop TABLE store_Archive;

-- Note: Check your database to see the new table and how many rows in it?
-- b)	Try the previous query but without transferring the data? 
select S.rowguid , S.Name, S.SalesPersonID, S.Demographics into store_Archive2
from Sales.Store S
where 1=2 

-- 12.	Using union statement, retrieve the today�s date in different styles using convert or format funtion.
SELECT
  FORMAT(GETDATE(), '%M-%d-%y') AS date

UNION ALL
SELECT
  FORMAT(GETDATE(), '%m/%d/%y');