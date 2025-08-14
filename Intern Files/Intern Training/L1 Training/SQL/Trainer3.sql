USE EDEN;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE CUSTOMERS (
    CustomerId INT UNIQUE,
    CustomerName VARCHAR(30),
    AddressId INT PRIMARY KEY
);

CREATE TABLE ADDRESSES (
    AddressId INT UNIQUE,
    AddressValue VARCHAR(150),
    FOREIGN KEY (AddressId)
        REFERENCES CUSTOMERS (AddressId)
);

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

SELECT 
    C.CustomerId 'CUSTOMER ID',
    C.CustomerName 'CUSTOMER NAME',
    C.AddressId 'ADDRESS ID',
    A.AddressValue 'ADDRESS'
FROM
    CUSTOMERS C
        LEFT OUTER JOIN
    ADDRESSES A ON C.AddressId = A.AddressId;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO CUSTOMERS VALUES (101, 'XYZ', 101), (102, 'XYZ', 102), (103, 'XYZ', 103), (104, 'XYZ', 104);

INSERT INTO ADDRESSES VALUE (101, 'Lorem ipsum dolor amet.'), (102, 'Lorem ipsum dolor amet.'), (103, 'Lorem ipsum dolor amet.');

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE PERSONS (
    PersonId INT PRIMARY KEY,
    PersonName VARCHAR(50),
    PersonDOB DATE,
    NationalityId INT UNIQUE,
    FOREIGN KEY (NationalityId)
        REFERENCES NATIONALITY (NationalityId)
);

CREATE TABLE NATIONALITY (
    NationalityId INT PRIMARY KEY,
    Nationality VARCHAR(50)
);

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

SELECT 
    P.PersonId 'PERSON ID',
    P.PersonName 'NAME',
    P.PersonDOB 'DOB',
    N.NationalityId 'Nationality ID',
    N.Nationality 'Nationality'
FROM
    PERSONS P
        LEFT OUTER JOIN
    NATIONALITY N ON P.NationalityId = N.NationalityId;
    
CREATE VIEW DEFAULTVIEW AS
    SELECT 
        P.PersonId 'PERSON ID',
        P.PersonName 'NAME',
        P.PersonDOB 'DOB',
        N.NationalityId 'Nationality ID',
        N.Nationality 'Nationality'
    FROM
        PERSONS P
            LEFT OUTER JOIN
        NATIONALITY N ON P.NationalityId = N.NationalityId;
        
SELECT 
    *
FROM
    DEFAULTVIEW;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO NATIONALITY
VALUES
	(101, 'INDIA'), 
	(102, 'USA'),
    (103, 'JAPAN'),
    (104, 'CHINA'),
    (105, 'CANADA'),
    (106, 'AFRICA'),
    (107, 'SOUTH AMERICA');
    
INSERT INTO PERSONS
VALUES
	(1, 'XYZ', '2005-06-09', 101),
	(2, 'ABC', '2005-06-09', 102),
	(3, 'EFG', '2005-06-09', 103),
	(4, 'HIJ', '2005-06-09', 104),
	(5, 'LMN', '2005-06-09', 105),
	(6, 'OPQ', '2005-06-09', 106),
	(7, 'RST', '2005-06-09', 107);
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE ORDERS (
    ORDER_ID INT PRIMARY KEY,
    CUSTOMER_ID INT,
    FOREIGN KEY (CUSTOMER_ID)
        REFERENCES CUSTOMERS (CUSTOMERID),
    ORDER_DATE DATE,
    AMOUNT DECIMAL
);
 
CREATE TABLE ITEMS (
    ITEM_ID INT PRIMARY KEY,
    ITEM_NAME VARCHAR(20),
    ITEM_DESC VARCHAR(50)
);
 
CREATE TABLE ITEMS_ORDERS (
    ORDER_ID INT,
    FOREIGN KEY (ORDER_ID)
        REFERENCES ORDERS (ORDER_ID),
    ITEM_ID INT,
    FOREIGN KEY (ITEM_ID)
        REFERENCES ITEMS (ITEM_ID)
);

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Store Procedure:
DELIMITER //

CREATE PROCEDURE ShowData()
BEGIN
SELECT 
    P.PersonId 'PERSON ID',
    P.PersonName 'NAME',
    P.PersonDOB 'DOB',
    N.NationalityId 'Nationality ID',
    N.Nationality 'Nationality'
FROM
    PERSONS P
        LEFT OUTER JOIN
    NATIONALITY N ON P.NationalityId = N.NationalityId;
END //
 
CREATE PROCEDURE GetByName(IN PersonName VARCHAR(50))
BEGIN
  SELECT 
    P.PersonId 'PERSON ID',
    P.PersonName 'NAME',
    P.PersonDOB 'DOB',
    N.NationalityId 'Nationality ID',
    N.Nationality 'Nationality'
FROM
    PERSONS P
        JOIN
    NATIONALITY N ON (P.NationalityId = N.NationalityId AND P.PersonName = PersonName);
END //
 
DELIMITER ;
  
CALL ShowData();
 
CALL GetByName('XYZ');
 
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Task:
CREATE TABLE USERLOGIN (
    UserName VARCHAR(50),
    UserPassword VARCHAR(50)
);

DELIMITER //

CREATE PROCEDURE UserCount (IN P_UserName VARCHAR(50), IN P_UserPassword VARCHAR(50), OUT P_Result VARCHAR(50))
BEGIN
	DECLARE UserCount INT;
    
SELECT 
    COUNT(*)
INTO UserCount FROM
    USERLOGIN
WHERE
    (UserName = P_UserName
        AND UserPassword = P_UserPassword);
    
    IF UserCount > 0 THEN
    SET P_Result = 'LOGIN SUCCESFULLY!';
    ELSE
    SET P_Result = 'LOGIN FAILED!';
    END IF;
END //

DELIMITER ;

INSERT INTO USERLOGIN VALUE ('XYZ', 123);

CALL UserCount('XYZ', 123, @result);
SELECT @result;
CALL UserCount('ABC', 123, @result);
SELECT @result;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

