USE EDEN;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Users table
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    phone VARCHAR(15),
    address TEXT
);
 
-- Products table
CREATE TABLE products (
    product_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255),
    price DECIMAL(10 , 2 ),
    category VARCHAR(100),
    stock INT
);
 
-- Orders table
CREATE TABLE orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    total DECIMAL(10 , 2 ),
    FOREIGN KEY (user_id)
        REFERENCES users (user_id)
);
 
-- Order Items table
CREATE TABLE order_items (
    order_item_id INT AUTO_INCREMENT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    price DECIMAL(10 , 2 ),
    FOREIGN KEY (order_id)
        REFERENCES orders (order_id),
    FOREIGN KEY (product_id)
        REFERENCES products (product_id)
);
 
-- Insert 100 sample products with some duplicate values in category
INSERT INTO products (name, price, category, stock) VALUES
    ('Laptop', 75000.00, 'Electronics', 20),
    ('Smartphone', 40000.00, 'Electronics', 50),
    ('Headphones', 2500.00, 'Accessories', 100),
    ('Shoes', 3000.00, 'Fashion', 60),
    ('Backpack', 1500.00, 'Fashion', 80),
    ('Gaming Console', 45000.00, 'Electronics', 10),
    ('Tablet', 32000.00, 'Electronics', 30),
    ('Monitor', 12000.00, 'Electronics', 25),
    ('Smartwatch', 15000.00, 'Electronics', 40),
    ('Bluetooth Speaker', 5000.00, 'Accessories', 50),
    ('Keyboard', 2000.00, 'Accessories', 100),
    ('Mouse', 1500.00, 'Accessories', 100),
    ('T-shirt', 800.00, 'Fashion', 150),
    ('Jeans', 2500.00, 'Fashion', 90),
    ('Jacket', 4000.00, 'Fashion', 70),
    ('Sunglasses', 2000.00, 'Fashion', 50),
    ('Handbag', 3000.00, 'Fashion', 60),
    ('Printer', 8000.00, 'Electronics', 15),
    ('Scanner', 6000.00, 'Electronics', 10),
    ('Fitness Tracker', 12000.00, 'Electronics', 35);
 
-- Insert 80 more random records by repeating some categories
INSERT INTO products (name, price, category, stock)
SELECT name, price, category, stock FROM products LIMIT 80;

INSERT INTO users (name, email, phone, address) VALUES
    ('John Doe', 'john@example.com', '9876543210', '123 Main Street, City'),
    ('Jane Smith', 'jane@example.com', '9876543211', '456 Elm Street, Town'),
    ('Michael Brown', 'michael@example.com', '9876543212', '789 Pine Avenue, Village'),
    ('Emma White', 'emma@example.com', '9876543213', '234 Oak Road, City'),
    ('Liam Johnson', 'liam@example.com', '9876543214', '567 Maple Lane, Town'),
    ('Sophia Davis', 'sophia@example.com', '9876543215', '890 Birch Way, Village');
     
-- Generate 94 more random users based on existing entries
INSERT INTO users (name, email, phone, address)
SELECT name, CONCAT('user', user_id, '@example.com'), phone, address FROM users LIMIT 94;

-- Insert 100 random orders linked to existing users
INSERT INTO orders (user_id, total) 
SELECT user_id, ROUND(RAND() * 50000, 2) FROM users LIMIT 100;

INSERT INTO order_items (order_id, product_id, quantity, price)
SELECT order_id, 
       FLOOR(RAND() * 20) + 1, -- Random product_id
       FLOOR(RAND() * 5) + 1,  -- Random quantity
       (SELECT price FROM products ORDER BY RAND() LIMIT 1)
FROM orders LIMIT 100;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Write a query to select all columns from the users table.
SELECT 
    *
FROM
    USERS;

-- Write a query to select all products with a price greater than ₹10,000.
SELECT 
    *
FROM
    PRODUCTS
HAVING PRICE > 10000;

-- Write a query to select all orders placed in the last 7 days.
SELECT 
    *
FROM
    ORDERS
WHERE
    ORDER_DATE BETWEEN 7 - NOW() AND NOW();

-- Write a query to select products from the 'Electronics' category.
SELECT 
    *
FROM
    PRODUCTS
HAVING CATEGORY = 'ELECTRONICS';

-- Write a query to select users whose email contains 'gmail.com'.
SELECT 
    *
FROM
    USERS
HAVING EMAIL LIKE '%@example.com';

-- Write a query to count the total number of orders.
SELECT 
    COUNT(ORDER_ID) 'TOTAL ORDERS'
FROM
    ORDERS;

-- Write a query to find the average price of products in each category.
SELECT 
    CATEGORY, ROUND(AVG(PRICE), 2) 'AVERAGE PRICE'
FROM
    PRODUCTS
GROUP BY CATEGORY;

-- Write a query to find the total revenue generated from all orders.
SELECT 
    SUM(TOTAL) 'TOTAL SALE'
FROM
    ORDERS;

-- Write a query to find the category with the highest number of products.
SELECT 
    CATEGORY, COUNT(PRODUCT_ID) 'NUMBER OF PRODUCTS'
FROM
    PRODUCTS
GROUP BY CATEGORY
LIMIT 1;

-- Write a query to find the total quantity of products sold in the order_items table.
SELECT 
    COUNT(QUANTITY) 'TOTAL INV SOLD'
FROM
    ORDER_ITEMS;

-- Write a query to select all orders along with user details.
SELECT 
    O.ORDER_ID 'ORDER ID',
    U.USER_ID 'USER ID',
    O.ORDER_DATE 'DATE',
    O.TOTAL 'PRICE',
    U.NAME 'NAME',
    U.EMAIL 'EMAIL',
    U.PHONE 'PHONE',
    U.ADDRESS 'ADDRESS'
FROM
    ORDERS O
        JOIN
    USERS U;
    
-- Write a query to select order details along with the product names.
SELECT
	O.ORDER_ID 'ORDER ID',
    O.USER_ID 'USER ID',
    P.PRODUCT_ID 'PRODUCT ID',
    P.NAME 'NAME',
    P.CATEGORY 'CATEGORY',
    P.PRICE 'PRICE',
    O.ORDER_DATE 'DATE',
    O.TOTAL 'PRICE'
FROM
	ORDERS O
		JOIN
	PRODUCTS P;
    
-- Write a query to select users who have placed at least one order.
SELECT DISTINCT
    U.USER_ID 'USER ID',
    U.NAME 'NAME',
    U.EMAIL 'EMAIL',
    U.PHONE 'PHONE',
    U.ADDRESS 'ADDRESS'
FROM
    USERS U
        JOIN
    ORDERS O;

-- Write a query to select products that have never been ordered.
SELECT DISTINCT
    P.PRODUCT_ID, P.NAME
FROM
    PRODUCTS P
        JOIN
    ORDER_ITEMS O
WHERE
    P.PRODUCT_ID NOT IN (SELECT DISTINCT
            PRODUCT_ID
        FROM
            ORDER_ITEMS);
            
-- Write a query to find the top 5 most ordered products.
SELECT 
    P.NAME, P.PRODUCT_ID, SUM(O.QUANTITY)
FROM
    PRODUCTS P
        JOIN
    ORDER_ITEMS O ON P.PRODUCT_ID = O.PRODUCT_ID
GROUP BY P.NAME , P.PRODUCT_ID
ORDER BY SUM(O.QUANTITY) DESC
LIMIT 5;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------