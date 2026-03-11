USE EventDb;
DROP TABLE IF EXISTS order_items;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS stocks;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS stores;
-- Stores
CREATE TABLE stores(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);

-- Products
CREATE TABLE products(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
list_price DECIMAL(10,2)
);

-- Stock Table
CREATE TABLE stocks(
store_id INT,
product_id INT,
quantity INT,
PRIMARY KEY(store_id, product_id),
FOREIGN KEY(store_id) REFERENCES stores(store_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
);

-- Orders Table
CREATE TABLE orders(
order_id INT PRIMARY KEY,
store_id INT,
order_date DATE,
FOREIGN KEY(store_id) REFERENCES stores(store_id)
);

-- Order Items Table
CREATE TABLE order_items(
order_id INT,
item_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
PRIMARY KEY(order_id, item_id),
FOREIGN KEY(order_id) REFERENCES orders(order_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
);

INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Bangalore Store');

INSERT INTO products VALUES
(101,'Car Battery',5000),
(102,'Brake Pad',2000),
(103,'Engine Oil',800);

INSERT INTO stocks VALUES
(1,101,10),
(1,102,5),
(1,103,20),
(2,101,15),
(2,102,10);

CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS
BEGIN

UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id
JOIN orders o
ON o.order_id = i.order_id
AND o.store_id = s.store_id;

-- Prevent negative stock
IF EXISTS(
SELECT 1
FROM stocks
WHERE quantity < 0
)
BEGIN
RAISERROR('Stock cannot be negative',16,1);
ROLLBACK TRANSACTION;
END

END

--Transaction to Place Order
BEGIN TRANSACTION;

BEGIN TRY

-- Check stock availability
IF EXISTS (
SELECT 1
FROM stocks
WHERE store_id = 1
AND product_id = 101
AND quantity < 2
)
BEGIN
RAISERROR('Insufficient stock',16,1);
ROLLBACK TRANSACTION;
RETURN;
END

-- Insert Order
INSERT INTO orders
VALUES (1,1,GETDATE());

-- Insert Order Items
INSERT INTO order_items
VALUES
(1,1,101,2,5000),
(1,2,102,1,2000);

COMMIT TRANSACTION;

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;
PRINT 'Transaction Failed';

END CATCH;

SELECT * FROM orders;
SELECT * FROM order_items;
SELECT * FROM stocks;