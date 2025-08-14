-- Active: 1745925233938@@127.0.0.1@3306@eden
USE Eden;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE
    Employee (
        EmpNo INT,
        EmpFirstName VARCHAR(30),
        EmpLastName VARCHAR(30),
        EmpAge INT,
        EmpCity VARCHAR(30)
    );

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

SELECT
    *
FROM
    Employees;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- SQL DDL: Can be rolled back.
-- TABLE RENAME:
ALTER TABLE Employee
RENAME TO Employees;

-- ADD New Column:
ALTER TABLE Employees ADD EmpContact VARCHAR(10);

-- DROP existing Column:
ALTER TABLE Employees
DROP EmpCity;

-- MODIFY:
ALTER TABLE Employees MODIFY EmpContact VARCHAR(10);

-- DROP TABLE:
-- DROP TABLE Employees;
-- TRUNCATE: Remove data alone:
TRUNCATE TABLE Employees;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- SQL DML:  Can not be rolled back.
-- INSERT:
-- Single Row.
INSERT INTO
    Employees
VALUES
    (100, 'Nisanth', 'Saravanan', 21, '8925465856');

-- Single Row, Industry Std.
INSERT INTO
    Employees (
        EmpNo,
        EmpFirstName,
        EmpLastName,
        EmpAge,
        EmpContact
    )
VALUES
    (101, 'Mani', 'Gandhi', 24, '1234567890');

-- Multi Row.
INSERT INTO
    Employees
VALUES
    (103, 'Mani', 'Jeevi', 36, '1234567890'),
    (104, 'Jeeva', 'Kaithi', 26, '1234567890'),
    (105, 'Thanga', 'Mani', 27, '1234567890');

-- Partial Data INSERT:
INSERT INTO
    Employees
VALUES
    (106, 'Ram', null, 30, null);

INSERT INTO
    Employees (
        EmpNo,
        EmpFirstName,
        EmpLastName,
        EmpAge,
        EmpContact
    )
VALUES
    (107, 'Somu', null, 20, null);

-- Update:
-- update <TABLE Name> set <ColumnName> = <Value>;
-- update <TABLE Name> set <Column Name> = <Value> where <Condition>;
DELETE FROM Employees
WHERE
    EmpNo = 106;

DELETE FROM Employees
WHERE
    EmpFirstName = 'Somu';

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- TCL:ACID Properties:
-- ATOmicity.
-- Consistency.
-- Isolation.
-- Durability.
-- Commit:
COMMIT;

-- Rollback:
ROLLBACK;

-- Savepoint:
-- savepoint <Savepoint Name>;
SAVEPOINT CHECKpoint1;

-- Rollback TO Savepoint:
ROLLBACK TO CHECKpoint1;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE
    Products (
        ProductId INT PRIMARY KEY UNIQUE NOT NULL,
        ProductName VARCHAR(20) UNIQUE,
        CONSTRAINT chk_ProductId CHECK (ProductId >= 100)
    );

SELECT
    *
FROM
    Products;

-- Will allow, both VALUES are UNIQUE and ProductId is not null.
INSERT INTO
    Products (ProductId, ProductName) value (100, 'Juice');

-- Will allow for a null value in an UNIQUE column (ProductName).
INSERT INTO
    Products (ProductId, ProductName) value (101, null);

-- ERROR: Wont allow for repeated ProductId (Primary Key).
INSERT INTO
    Products (ProductId, ProductName) value (100, 'Box');

-- ERROR: Wont allow for a null ProductId (Primary Key).
INSERT INTO
    Products (ProductId, ProductName) value (null, 'TOy');

-- ERROR: Wont allow for repeated ProductName (Unique).
INSERT INTO
    Products (ProductId, ProductName) value (101, 'Juice');

-- ERROR: Wont allow for due TO the CHECK CONSTRAINT on ProductId.
INSERT INTO
    Products (ProductId, ProductName) value (10, 'Gamma');

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Task:
CREATE TABLE
    Employees (
        EmpId INT PRIMARY KEY,
        EmpName VARCHAR(30),
        EmpAge INT,
        EmpLocation VARCHAR(30),
        EmpSalary INT,
        CONSTRAINT chk_EmpAge CHECK (EmpAge > 18),
        CONSTRAINT chk_EmpLocation CHECK (EmpLocation IN ('CHN', 'VRTC')),
        CONSTRAINT chk_EmpSalary CHECK (EmpSalary BETWEEN 10000 AND 25000)
    );

ALTER TABLE Employees ADD EmpContact VARCHAR(10) not null;

ALTER TABLE Employees ADD EmpMail VARCHAR(50);

ALTER TABLE Employees ADD CONSTRAINT chk_EmpContact CHECK (EmpContact REGEXP '[0-9]{10}$');

ALTER TABLE Employees ADD CONSTRAINT chk_EmpMail CHECK (EmpMail LIKE '%__@__%.__%');

INSERT INTO
    Employees (
        EmpId,
        EmpName,
        EmpAge,
        EmpLocation,
        EmpSalary,
        EmpContact,
        EmpMail
    )
VALUES
    (
        101,
        'Nisanth',
        21,
        'VRTC',
        25000,
        1234567890,
        'xxxxx@xxx.com'
    ),
    (
        102,
        'Rishi',
        23,
        'VRTC',
        25000,
        1234567890,
        'xxxxx@xxx.com'
    ),
    (
        103,
        'Mani',
        26,
        'VRTC',
        25000,
        1234567890,
        'xxxxx@xxx.com'
    ),
    (
        104,
        'Sani',
        31,
        'CHN',
        10000,
        1234567890,
        'xxxxx@xxx.com'
    ),
    (
        105,
        'Terry',
        22,
        'CHN',
        10000,
        1234567890,
        'xxxxx@xxx.com'
    );

SELECT
    *
FROM
    Employees;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------