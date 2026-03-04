CREATE DATABASE SalesDb
USE SalesDb

CREATE TABLE stores (
    store_id    INT PRIMARY KEY,
    store_name  VARCHAR(50)
);

CREATE TABLE orders (
    order_id     INT PRIMARY KEY,
    store_id     INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items (
    order_id    INT,
    item_id     INT,
    product_id  INT,
    quantity    INT,
    list_price  DECIMAL(10,2),
    discount    DECIMAL(4,2),
    PRIMARY KEY (order_id, item_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

INSERT INTO stores VALUES
(1, 'Chennai Store'),
(2, 'Mumbai Store'),
(3, 'Delhi Store');

INSERT INTO orders VALUES
(101, 1, 4),   
(102, 2, 4),  
(103, 1, 1),   
(104, 3, 4),  
(105, 2, 2);   

INSERT INTO order_items VALUES
(101, 1, 1, 2, 1000.00, 0.10),
(101, 2, 2, 1,  500.00, 0.05),
(102, 1, 3, 3,  800.00, 0.20),
(103, 1, 1, 2, 1000.00, 0.10),
(104, 1, 2, 1, 1500.00, 0.15),
(105, 1, 3, 2,  600.00, 0.10);


SELECT s.store_name, SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN orders o ON s.store_id  = o.store_id
INNER JOIN order_items oi ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;