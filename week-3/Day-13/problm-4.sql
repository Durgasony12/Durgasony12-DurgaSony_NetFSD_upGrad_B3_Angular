

USE SalesDb;
DROP TABLE IF EXISTS order_items;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS stocks;
DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS stores;


-- 2. CREATE TABLES

-- Products Table
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL
);

-- Stores Table
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100) NOT NULL
);

-- Stocks Table
CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- Orders Table
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    order_date DATE
);

-- Order Items Table
CREATE TABLE order_items (
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);


-- 3. INSERT DATA

-- Products
INSERT INTO products VALUES
(1,'Laptop'),
(2,'Mobile'),
(3,'Headphones'),
(4,'Keyboard');

-- Stores
INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Chennai Store');

-- Stocks
INSERT INTO stocks VALUES
(1,1,50),
(1,2,40),
(1,3,20),
(2,1,30),
(2,4,15);

-- Orders
INSERT INTO orders VALUES
(101,'2024-01-10'),
(102,'2024-01-15'),
(103,'2024-02-01');

-- Order Items
INSERT INTO order_items VALUES
(101,1,5),
(101,2,3),
(102,1,2),
(103,3,4);


-- 4. FINAL QUERY (Product Stock and Sales Analysis)

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    ISNULL(SUM(oi.quantity),0) AS total_quantity_sold
FROM stocks st
INNER JOIN products p 
    ON st.product_id = p.product_id
INNER JOIN stores s 
    ON st.store_id = s.store_id
LEFT JOIN order_items oi 
    ON st.product_id = oi.product_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY 
    p.product_name;