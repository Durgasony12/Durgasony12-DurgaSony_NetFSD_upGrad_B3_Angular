USE AutomobileretailDb
DROP TABLE IF EXISTS Order_Items;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Stocks;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Stores;
CREATE TABLE Stores(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);
CREATE TABLE Products(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
list_price DECIMAL(10,2)
);

CREATE TABLE Orders(
order_id INT PRIMARY KEY,
store_id INT,
order_date DATE,
FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

CREATE TABLE Order_Items(
order_id INT,
product_id INT,
quantity INT,
discount DECIMAL(4,2),
FOREIGN KEY (order_id) REFERENCES Orders(order_id),
FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Stocks(
store_id INT,
product_id INT,
quantity INT,
FOREIGN KEY (store_id) REFERENCES Stores(store_id),
FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Stores VALUES
(1,'Hyderabad Store'),
(2,'Chennai Store');

INSERT INTO Products VALUES
(101,'Laptop',60000),
(102,'Mobile',20000),
(103,'Headphones',2000);

INSERT INTO Orders VALUES
(1,1,'2024-02-01'),
(2,1,'2024-02-05'),
(3,2,'2024-02-10');

INSERT INTO Order_Items VALUES
(1,101,2,0.10),
(1,102,3,0.05),
(2,103,5,0),
(3,101,1,0.15);

INSERT INTO Stocks VALUES
(1,101,5),
(1,102,0),
(1,103,0),
(2,101,3),
(2,102,4),
(2,103,1);

--1 IDENTIFY PRODUCTS SOLD IN EACH STORE
-- (Nested Query)
SELECT DISTINCT store_id, product_id
FROM
(
    SELECT o.store_id, oi.product_id
    FROM Orders o
    JOIN Order_Items oi
    ON o.order_id = oi.order_id
) AS SoldProducts;

-- 2 PRODUCTS SOLD BUT CURRENTLY OUT OF STOCK
-- USING INTERSECT
------------------------------------------------

SELECT o.store_id, oi.product_id
FROM Orders o
JOIN Order_Items oi
ON o.order_id = oi.order_id

INTERSECT

SELECT store_id, product_id
FROM Stocks
WHERE quantity = 0;

-- 3 SOLD PRODUCTS EXCEPT AVAILABLE STOCK
------------------------------------------------

SELECT o.store_id, oi.product_id
FROM Orders o
JOIN Order_Items oi
ON o.order_id = oi.order_id

EXCEPT

SELECT store_id, product_id
FROM Stocks
WHERE quantity > 0;

-- 4 DISPLAY STORE NAME, PRODUCT NAME,
-- TOTAL QUANTITY SOLD
------------------------------------------------

SELECT 
s.store_name,
p.product_name,
SUM(oi.quantity) AS total_quantity_sold
FROM Stores s
JOIN Orders o
ON s.store_id = o.store_id
JOIN Order_Items oi
ON o.order_id = oi.order_id
JOIN Products p
ON oi.product_id = p.product_id
GROUP BY s.store_name,p.product_name;

------------------------------------------------
-- 5 CALCULATE TOTAL REVENUE
-- (quantity × list_price × (1-discount))
------------------------------------------------

SELECT 
s.store_name,
p.product_name,
SUM(oi.quantity * p.list_price * (1-oi.discount)) AS total_revenue
FROM Stores s
JOIN Orders o
ON s.store_id = o.store_id
JOIN Order_Items oi
ON o.order_id = oi.order_id
JOIN Products p
ON oi.product_id = p.product_id
GROUP BY s.store_name,p.product_name;

------------------------------------------------
-- 6 UPDATE STOCK TO 0 FOR DISCONTINUED PRODUCTS
------------------------------------------------

UPDATE Stocks
SET quantity = 0
WHERE product_id IN
(
SELECT product_id
FROM Order_Items
);

------------------------------------------------
-- VERIFY STOCK
------------------------------------------------

SELECT * FROM Stocks;