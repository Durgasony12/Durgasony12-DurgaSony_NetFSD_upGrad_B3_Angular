USE EcommDb
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS staffs;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS customers;
DROP TABLE IF EXISTS stores;
DROP TABLE IF EXISTS brands;
DROP TABLE IF EXISTS categories;
CREATE TABLE categories
(
category_id INT PRIMARY KEY,
category_name VARCHAR(50) NOT NULL
);

CREATE TABLE brands
(
brand_id INT PRIMARY KEY,
brand_name VARCHAR(50) NOT NULL
);

CREATE TABLE products
(
product_id INT PRIMARY KEY,
product_name VARCHAR(100) NOT NULL,
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2),

FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers
(
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
phone VARCHAR(20),
email VARCHAR(100),
city VARCHAR(50),
state VARCHAR(50)
);

CREATE TABLE stores
(
store_id INT PRIMARY KEY,
store_name VARCHAR(50),
city VARCHAR(50),
state VARCHAR(50)
);

CREATE TABLE staffs
(
staff_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
email VARCHAR(100),
phone VARCHAR(20),
store_id INT,

FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE orders
(
order_id INT PRIMARY KEY,
customer_id INT,
store_id INT,
staff_id INT,
order_date DATE,

FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
FOREIGN KEY (store_id) REFERENCES stores(store_id),
FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);
--- Create a view that shows product name, brand name, category name, model year and list price.

CREATE VIEW vw_ProductDetails 
AS 
SELECT p.product_name, b.brand_name,c.category_name,p.model_year,p.list_price
FROM products p
INNER JOIN brands b ON p.brand_id=b.brand_id
INNER JOIn categories c ON p.category_id=c.category_id;

SELECT * FROM vw_ProductDetails;

---Create a view that shows order details with customer name, store name and staff name.
CREATE VIEW vw_OrderDetails AS
SELECT 
o.order_id,
CONCAT(c.first_name,' ',c.last_name) AS customer_name,
s.store_name,
CONCAT(st.first_name,' ',st.last_name) AS staff_name,
o.order_date
FROM orders o
JOIN customers c
ON o.customer_id = c.customer_id
JOIN stores s
ON o.store_id = s.store_id
JOIN staffs st
ON o.staff_id = st.staff_id;

SELECT * FROM vw_OrderDetails;
	
--Product Table Indexes

CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

--Orders Table Indexes

CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);

