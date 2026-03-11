USE EventDb;
DROP TABLE IF EXISTS order_items;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS stocks;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS stores;

-- Create Stores table
CREATE TABLE stores(
store_id INT PRIMARY KEY,
store_name VARCHAR(50)
);

-- Create Products table
CREATE TABLE products(
product_id INT PRIMARY KEY,
product_name VARCHAR(50),
list_price DECIMAL(10,2)
);

-- Create Stocks table
CREATE TABLE stocks(
store_id INT,
product_id INT,
quantity INT,
PRIMARY KEY(store_id,product_id),
FOREIGN KEY(store_id) REFERENCES stores(store_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
);

-- Create Orders table
CREATE TABLE orders(
order_id INT PRIMARY KEY,
store_id INT,
order_date DATE,
order_status INT,
FOREIGN KEY(store_id) REFERENCES stores(store_id)
);

-- Create Order Items table
CREATE TABLE order_items(
order_id INT,
item_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
PRIMARY KEY(order_id,item_id),
FOREIGN KEY(order_id) REFERENCES orders(order_id),
FOREIGN KEY(product_id) REFERENCES products(product_id)
);

-- Insert Stores
INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Bangalore Store');

-- Insert Products
INSERT INTO products VALUES
(101,'Car Battery',5000),
(102,'Brake Pad',2000),
(103,'Engine Oil',800);

-- Insert Stocks
INSERT INTO stocks VALUES
(1,101,10),
(1,102,5),
(1,103,20),
(2,101,15),
(2,102,10);

-- Insert Order
INSERT INTO orders VALUES
(1,1,GETDATE(),1);

-- Insert Order Items
INSERT INTO order_items VALUES
(1,1,101,2,5000),
(1,2,102,1,2000);

-- Reduce stock manually to simulate order placement
UPDATE stocks
SET quantity = quantity - 2
WHERE store_id=1 AND product_id=101;

UPDATE stocks
SET quantity = quantity - 1
WHERE store_id=1 AND product_id=102;

-------------------------------------------------------
-- Atomic Order Cancellation using SAVEPOINT
-------------------------------------------------------

BEGIN TRANSACTION;

BEGIN TRY

-- Savepoint before restoring stock
SAVE TRANSACTION BeforeStockRestore;

-- Restore stock
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi
ON s.product_id = oi.product_id
JOIN orders o
ON o.order_id = oi.order_id
AND s.store_id = o.store_id
WHERE o.order_id = 1;

-- Validate restoration
IF EXISTS (SELECT 1 FROM stocks WHERE quantity < 0)
BEGIN
RAISERROR('Stock restoration failed',16,1);
END

-- Update order status
UPDATE orders
SET order_status = 3
WHERE order_id = 1;

COMMIT TRANSACTION;

PRINT 'Order Cancelled Successfully';

END TRY

BEGIN CATCH

PRINT ERROR_MESSAGE();

IF @@TRANCOUNT > 0
ROLLBACK TRANSACTION;

END CATCH;

SELECT * FROM orders;

SELECT * FROM order_items;

SELECT * FROM stocks;