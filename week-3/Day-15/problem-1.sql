CREATE DATABASE EcommDb
USE EcommDb

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

CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50) NOT NULL,
    city VARCHAR(50),
    state VARCHAR(50)
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

INSERT INTO categories VALUES
(1,'Motorcycles'),
(2,'Scooters'),
(3,'Electric Bikes'),
(4,'Sports Bikes'),
(5,'Cruiser Bikes');

INSERT INTO brands VALUES
(1,'Honda'),
(2,'Yamaha'),
(3,'Bajaj'),
(4,'Royal Enfield'),
(5,'TVS');

INSERT INTO stores VALUES
(1,'AutoWorld','Hyderabad','Telangana'),
(2,'Speed Motors','Chennai','Tamil Nadu'),
(3,'Bike Hub','Bangalore','Karnataka'),
(4,'Ride Zone','Mumbai','Maharashtra'),
(5,'Motor City','Delhi','Delhi');

INSERT INTO products VALUES
(101,'Honda Activa',1,2,2023,90000),
(102,'Yamaha R15',2,4,2024,180000),
(103,'Bajaj Pulsar',3,1,2023,140000),
(104,'Royal Enfield Classic 350',4,5,2024,210000),
(105,'TVS iQube Electric',5,3,2024,160000);

INSERT INTO customers VALUES
(1,'Ravi','Kumar','9876543210','ravi@gmail.com','Hyderabad','Telangana'),
(2,'Anita','Sharma','9876543211','anita@gmail.com','Chennai','Tamil Nadu'),
(3,'Rahul','Verma','9876543212','rahul@gmail.com','Bangalore','Karnataka'),
(4,'Sneha','Reddy','9876543213','sneha@gmail.com','Hyderabad','Telangana'),
(5,'Arjun','Mehta','9876543214','arjun@gmail.com','Mumbai','Maharashtra');

--Retrieve All Products with Brand and Category Names
SELECT p.product_name, b.brand_name,c.category_name
FROM products p
INNER JOIN brands b ON p.brand_id=b.brand_id
INNER JOIN categories c ON p.category_id=c.category_id

--Retrieve all customers from a specific city.

SELECT * FROM customers WHERE city='Mumbai';

--Display total number of products available in each category.
SELECT c.category_name, COUNT(p.product_name) AS product_total FROM categories c
LEFT JOIN products p ON P.category_id=C.category_id
GROUP BY c.category_name;