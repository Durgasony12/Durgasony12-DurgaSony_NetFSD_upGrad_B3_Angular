USE EventDb
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

CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check if stock is enough
        IF EXISTS(
            SELECT 1
            FROM inserted i
            JOIN Orders o 
                ON i.order_id = o.order_id
            JOIN Stocks s 
                ON s.product_id = i.product_id
               AND s.store_id = o.store_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            THROW 50001, 'Stock is insufficient. Order cannot be completed.', 1;
        END

        -- Reduce stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM Stocks s
        JOIN inserted i
            ON s.product_id = i.product_id
        JOIN Orders o
            ON i.order_id = o.order_id
           AND s.store_id = o.store_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;


--Stock available
INSERT INTO Order_Items VALUES
(2,101,1,0.05);

SELECT * FROM Stocks;

--Stock not available
INSERT INTO Order_Items VALUES
(1,102,5,0.05);