USE EventDb
DROP TABLE IF EXISTS Order_Items;
DROP TABLE IF EXISTS Orders;
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

--Calculate Total Price After Discount
CREATE FUNCTION fn_CalcTotalAfterDiscount
(
    @price DECIMAL(10,2),
    @quantity INT,
    @discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @total DECIMAL(10,2)

    SET @total = (@price * @quantity) * (1 - ISNULL(@discount,0))

    RETURN @total
END

SELECT dbo.fn_CalcTotalAfterDiscount(60000,2,0.10) AS TotalPrice

--Total Sales Per Store
CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_name,
        SUM(dbo.fn_CalcTotalAfterDiscount
        (p.list_price, oi.quantity, oi.discount)) AS Total_Sales
    FROM Stores s
    JOIN Orders o ON s.store_id = o.store_id
    JOIN Order_Items oi ON o.order_id = oi.order_id
    JOIN Products p ON oi.product_id = p.product_id
    GROUP BY s.store_name
END

EXEC sp_TotalSalesPerStore

--Orders by Date Range
CREATE PROCEDURE sp_GetOrdersByDateRange
(
    @StartDate DATE,
    @EndDate DATE
)
AS
BEGIN
    SELECT *
    FROM Orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
END

EXEC sp_GetOrdersByDateRange '2024-02-01','2024-02-10'

--Top 5 Selling Products
CREATE FUNCTION fn_TopSellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS Total_Quantity_Sold
    FROM Products p
    JOIN Order_Items oi 
    ON p.product_id = oi.product_id
    GROUP BY p.product_name
    ORDER BY Total_Quantity_Sold DESC
)

SELECT * FROM dbo.fn_TopSellingProducts()