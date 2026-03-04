--CREATE DATABASE ProductpriceDb
USE ProductpriceDb
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS categories;
DROP TABLE IF EXISTS Brand;
CREATE TABLE Brand
(
	brand_id INT PRIMARY KEY,
	brand_name VARCHAR(15),

);

CREATE TABLE categories
(
	c_id INT PRIMARY KEY,
	category_name VARCHAR(15)
);

CREATE TABLE Products
(
	p_id INT PRIMARY KEY,
	p_name VARCHAR(15),
	brand_id INT,
	c_id INT,
	model_year INT,
	list_price INT,
	FOREIGN KEY(brand_id) REFERENCES Brand(brand_id),
	FOREIGN KEY(C_id) REFERENCES categories(C_id),

);

INSERT INTO Brand VALUES 
(1,'zara'),
(2,'H&M');
INSERT INTO categories VALUES
(1,'Jeans'),
(2,'T-shirt');

INSERT INTO Products VALUES
(1,'wide-leg',1,1,2022,1200),
(2,'Skin-fit',2,2,2023,1100),
(3,'Full Hands',2,2,2020,900);


SELECT p.p_name, b.brand_name, c.category_name,p.model_year,p.list_price
from Products p INNER JOIN Brand b ON b.brand_id = p.brand_id
INNER JOIN categories c ON c.c_id= p.c_id where p.list_price > 500 
ORDER BY p.list_price ASC;
