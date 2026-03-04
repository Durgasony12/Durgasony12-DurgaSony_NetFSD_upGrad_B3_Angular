--CREATE DATABASE CustomerOrderDb
USE CustomerOrderDb
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Customer;
CREATE TABLE Customer
(
	CId       INT PRIMARY KEY,
	firstname varchar(20),
	lastname  varchar(20)
);

CREATE TABLE Orders
(
	O_Id INT PRIMARY KEY,
	CId INT,
	O_date DATE,
	O_status INT,
	FOREIGN KEY(CId)
	REFERENCES Customer(CId)
);

INSERT into  Customer values
(1,'Durga','Sony'),
(2,'priya','darshini'),
(3,'aishwarya','rai');

INSERT into  Orders values
(101,1,'2026-02-01',1),
(102,2,'2026-01-14',4),
(103,3,'2026-01-11',1),
(104,2,'2026-02-15',1);

SELECT C.firstname, C.lastname, O.O_Id, O.O_date,O.O_status from Customer C INNER JOIN Orders O
ON C.CId=O.CId WHERE O.O_status IN(1,4)
ORDER BY O.O_date DESC;
