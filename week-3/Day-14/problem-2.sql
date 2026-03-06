USE AutomobileretailDb
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Customers;
CREATE TABLE Customers
(
	c_id INT PRIMARY KEY,
	first_name VARCHAR(30),
	last_name VARCHAR(20)
);

CREATE TABLE Orders
(
	o_id INT PRIMARY KEY,
	c_id INT,
	o_amount DECIMAL(10,2),
	FOREIGN KEY(c_id) REFERENCES Customers(c_id)
);

INSERT INTO Customers VALUES
(1,'John','Cena'),
(2,'durga','sony'),
(3,'sai','sri');

INSERT INTO Orders VALUES
(1,2,5000),
(2,3,3500),
(3,2,4500);

SELECT CONCAT(c.first_name,' ',c.last_name) AS Full_Name,
SUM(o.o_amount) AS Total,
CASE
WHEN SUM(o.o_amount) > 10000 THEN 'Premium'
WHEN SUM(o.o_amount) BETWEEN 5000 AND 10000 THEN 'Regular'
ELSE 'Basic'
END AS Customer_Type
FROM Customers c
JOIN Orders o ON c.c_id = o.c_id
GROUP BY c.c_id, c.first_name, c.last_name
UNION
SELECT CONCAT(c.first_name,' ',c.last_name) AS Full_Name, 
NULL AS Total,
'No Orders' AS Customer_Type
FROM Customers c
WHERE c_id NOT IN (SELECT c_id FROM Orders);
