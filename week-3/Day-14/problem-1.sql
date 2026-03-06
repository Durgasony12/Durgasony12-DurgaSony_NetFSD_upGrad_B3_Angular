--CREATE DATABASE AutomobileretailDb
USE AutomobileretailDb
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Category;
CREATE TABLE Category
(
	c_id INT PRIMARY KEY,
	c_name VARCHAR(15)
);

CREATE TABLE Products
(
	p_id INT PRIMARY KEY,
	p_name VARCHAR(15),
	c_id INT,
	model_year INT,
	list_price DECIMAL(10,2),
	FOREIGN KEY(c_id) REFERENCES Category(c_id)
);

INSERT INTO Category VALUES
(1,'cars'),
(2,'bikes');

INSERT INTO Products VALUES
(1,'Honda City',1,1996,85000),
(2,'Duke',2,2020,95000),
(3,'Creta',1,2023,100000),
(4,'Yamaha',2,2021,95000);

SELECT CONCAT(p.p_name,' (',p.model_year,')') AS product,
p.p_name, p.model_year,
p.list_price FROM Products p
WHERE p.list_price > (SELECT AVG(p2.list_price)  FROM Products p2 WHERE p2.c_id=p.c_id)
ORDER BY p.list_price DESC;
