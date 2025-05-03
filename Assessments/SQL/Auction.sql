CREATE DATABASE AUCTION_HOUSE;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

USE AUCTION_HOUSE;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- ITEM STATUS TABLE:
CREATE TABLE ITEM_STATUS (
    ItemStatusID INT PRIMARY KEY,
    ItemStatusValue VARCHAR(50) UNIQUE
);

INSERT INTO ITEM_STATUS (ItemStatusID,ItemStatusValue) 
VALUES
	(1, 'SOLD'),
    (0, 'UNSOLD');
    
SELECT 
    ItemStatusID 'ID', ItemStatusValue 'STATUS'
FROM
    ITEM_STATUS;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- BID STATUS TABLE:
CREATE TABLE BID_STATUS(
	BidStatusID INT PRIMARY KEY,
    BidStatusValue VARCHAR(50) UNIQUE
);

INSERT INTO BID_STATUS (BidStatusID, BidStatusValue)
VALUES
	(1, 'WINNER'),
    (2, 'LOST'),
    (3, 'PENDING');
    
SELECT 
    BidStatusID 'ID', BidStatusValue 'VALUE'
FROM
    BID_STATUS;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- ITEM CATEGORIES TABLE:
CREATE TABLE ITEM_CATEGORIES(
	CatgoryID INT PRIMARY KEY,
    CategoryValue VARCHAR(50) UNIQUE
);

INSERT INTO ITEM_CATEGORIES (CatgoryID, CategoryValue)
VALUES
	(100, 'ANTIQUES'),
	(101, 'ELECTRONICS'),
	(102, 'FASHION'),
	(103, 'JEWELLERY'),
	(104, 'ART'),
	(105, 'PRE-HISTORIC'),
	(106, 'HISTORIC'),
	(107, 'ORIENTAL'),
	(108, 'WAR MEMROBILLIA'),
	(109, 'LITERATURE'),
	(110, 'MISC');
    
SELECT 
    CatgoryID 'ID', CategoryValue 'CATEGORY'
FROM
    ITEM_CATEGORIES;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- AUCTION ITEMS TABLE:
CREATE TABLE AUCTION_ITEMS(
	AItemID INT AUTO_INCREMENT PRIMARY KEY,
    AItemName VARCHAR(50),
    AItemDesc VARCHAR(250),
    CatgoryID INT,
    ItemStatusID INT DEFAULT 0,
    FOREIGN KEY (CatgoryID) REFERENCES ITEM_CATEGORIES(CatgoryID),
    FOREIGN KEY (ItemStatusID) REFERENCES ITEM_STATUS(ItemStatusID)    
);

INSERT INTO AUCTION_ITEMS (AItemName, AItemDesc, CatgoryID)
VALUES
	('TEMPLAR KNIGHT ARMOR', 'Lorem ipsum dolor sit amet',106),
	('THE OLDEST KNOWN GREEN TEA FROM THE SILK ROUTE', 'Lorem ipsum dolor sit amet',107),
	('MG42 - THE LMG', 'Lorem ipsum dolor sit amet',108),
	('THE FIRST COPY OF ANIMAL FARM', 'Lorem ipsum dolor sit amet',109),
	('A PARCHMENT OF OLD ROYAL DECREE', 'Lorem ipsum dolor sit amet',110),
	('COLLAR BONE OF A T-REX', 'Lorem ipsum dolor sit amet',105),
	("DANTE'S INFERNO", 'Lorem ipsum dolor sit amet',104),
	('KOHINOOR', 'Lorem ipsum dolor sit amet',103),
	("HITLER'S TRENCH COAT", 'Lorem ipsum dolor sit amet',102),
	('HUMMING BIRD VASE', 'Lorem ipsum dolor sit amet',100),
	('THE 1ST PHONE', 'Lorem ipsum dolor sit amet',101);
    
SELECT 
    A.AItemID 'ITEM ID',
    A.AItemName 'NAME',
    A.AItemDesc 'DESCRIPTION',
    C.CategoryValue 'CATEGORY',
    S.ItemStatusValue 'STATUS'
FROM
    AUCTION_ITEMS A
        JOIN
    ITEM_CATEGORIES C ON A.CatgoryID = C.CatgoryID
        JOIN
    ITEM_STATUS S ON A.ItemStatusID = S.ItemStatusID;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- BIDDERS TABLE: 
CREATE TABLE BIDDERS(
	BidderID INT AUTO_INCREMENT PRIMARY KEY,
    BidderName VARCHAR(50),
    BidderContact VARCHAR(10) NOT NULL,
    BidderAge INT,
    BidderAddress VARCHAR(250) NOT NULL,
    BidderAccNo VARCHAR(10) NOT NULL UNIQUE,
    CONSTRAINT CHK_BidderContact CHECK(BidderContact REGEXP '[0-9]{10}$'),
	CONSTRAINT CHK_BidderAccNo CHECK(BidderAccNo REGEXP '[0-9]{10}$'),
    CONSTRAINT CHK_BidderAge  CHECK(BidderAge >= 18)
);

INSERT INTO BIDDERS (BidderName, BidderContact, BidderAge, BidderAddress, BidderAccNo)
VALUES
	('JHON DOE', 1234567890, 23, 'Lorem ipsum dolor sit amet', 1234567890),
	('JANE DOE', 1245862350, 26, 'Lorem ipsum dolor sit amet', 1245862350),
	('JENNY DOE', 7541283609, 26, 'Lorem ipsum dolor sit amet', 7541283609),
	('JAKE DOE', 8965741238, 32, 'Lorem ipsum dolor sit amet', 8965741238),
	('MICKEY DOE', 8452367109, 67, 'Lorem ipsum dolor sit amet', 8452367109),
	('DUCKY DOE', 8541362079, 34, 'Lorem ipsum dolor sit amet', 2854136079),
	('MARY DOE', 1024586325, 87, 'Lorem ipsum dolor sit amet', 1024586325);
    
SELECT 
    BidderID 'ID',
    BidderName 'NAME',
    BidderContact 'CONTACT',
    BidderAge 'AGE',
    BidderAddress 'ADDRESS',
    BidderAccNo 'ACCOUNT NO'
FROM
    BIDDERS;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- BIDS TABLE:
CREATE TABLE BIDS(
	BidID INT AUTO_INCREMENT PRIMARY KEY,
    BidderID INT,
    AItemID INT,
    BidStatusID INT DEFAULT 3,
    BidAmount INT,
    FOREIGN KEY (BidderID) REFERENCES BIDDERS(BidderID),
    FOREIGN KEY (AItemID) REFERENCES AUCTION_ITEMS(AItemID),
    FOREIGN KEY (BidStatusID) REFERENCES BID_STATUS(BidStatusID)
);

INSERT INTO BIDS (BidderID, AItemID, BidAmount)
VALUES
	(1, 3, 50000),
	(3, 4, 45000),
	(7, 5, 75000),
	(2, 3, 84000),
	(1, 4, 96000),
	(4, 5, 98000),
	(6, 6, 75000),
	(7, 6, 784000);
    
SELECT 
    B.BidID 'BID ID',
    BD.BidderName 'BIDDER NAME',
    A.AItemName 'ITEM NAME',
    S.BidStatusValue 'STATUS',
    B.BidAmount 'BID AMOUNT'
FROM
    BIDS B
        JOIN
    BIDDERS BD ON B.BidderID = BD.BidderID
        JOIN
    AUCTION_ITEMS A ON B.AItemID = A.AItemID
        JOIN
    BID_STATUS S ON B.BidStatusID = S.BidStatusID;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Updating the bid status of a particular bid:
SELECT 
    B.BidID 'BID ID',
    BD.BidderName 'BIDDER NAME',
    A.AItemName 'ITEM NAME',
    S.BidStatusValue 'STATUS',
    B.BidAmount 'BID AMOUNT'
FROM
    BIDS B
        JOIN
    BIDDERS BD ON B.BidderID = BD.BidderID
        JOIN
    AUCTION_ITEMS A ON B.AItemID = A.AItemID
        JOIN
    BID_STATUS S ON B.BidStatusID = S.BidStatusID
WHERE
    B.AItemID = 5
ORDER BY B.BidAmount DESC;
    
UPDATE BIDS 
SET 
    BidStatusID = 1
WHERE
    (AItemID = 5) AND (BidAmount = 98000);

UPDATE BIDS 
SET 
    BidStatusID = 2
WHERE
    (AItemID = 5) AND (BidAmount = 75000);

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Updating the Item Status after sale:
UPDATE AUCTION_ITEMS 
SET 
    ItemStatusID = 1
WHERE
    AItemID = 5;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Deletion of sold items:
DELETE FROM AUCTION_ITEMS 
WHERE
    ItemStatusID = 1;
    
-- Deletion of Concluded Bids:
DELETE FROM BIDS 
WHERE
    BidStatusID != 3;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

    

