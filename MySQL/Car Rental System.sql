create database Car_Rental;
show databases;
use Car_Rental;
CREATE TABLE Car (
  CarID INT PRIMARY KEY,
  CarName VARCHAR(50),
  Model VARCHAR(50),
  Year INT,
  Type VARCHAR(50),
  LicenseNO VARCHAR(50)
);
CREATE TABLE Customer (
  CustomerID INT PRIMARY KEY,
  Name VARCHAR(100) NOT NULL,
  Email VARCHAR(100) UNIQUE NOT NULL,
  PhoneNO VARCHAR(20) NOT NULL,
  Address VARCHAR(200) NOT NULL,
  CONSTRAINT chk_Customer_Email CHECK (Email LIKE '_%@_%._%')
);
CREATE TABLE Rental (
  RentalID INT PRIMARY KEY,
  CarID INT NOT NULL,
  CustomerID INT NOT NULL,
  RentalDate DATE NOT NULL,
  ReturnDate DATE,
  TotalCost DECIMAL(10, 2) NOT NULL,
  FOREIGN KEY (CarID) REFERENCES Car(CarID),
  FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
  CONSTRAINT chk_Rental_Dates CHECK (RentalDate < ReturnDate OR ReturnDate IS NULL)
);
CREATE TABLE Payment (
  PaymentID INT PRIMARY KEY,
  RentalID INT NOT NULL,
  PaymentMethod VARCHAR(50) NOT NULL,
  PaymentDate DATE NOT NULL,
  Amount DECIMAL(10, 2) NOT NULL,
  FOREIGN KEY (RentalID) REFERENCES Rental(RentalID),
  CONSTRAINT chk_Payment_Amount CHECK (Amount > 0)
);
CREATE TABLE Employee (
  EmployeeID INT PRIMARY KEY,
  RentalID INT NOT NULL,
  EmpName VARCHAR(100) NOT NULL,
  EmpEmail VARCHAR(100) UNIQUE NOT NULL,
  EmpPhoneNO VARCHAR(20) NOT NULL,
  EmpRole VARCHAR(50) NOT NULL,
  FOREIGN KEY (RentalID) REFERENCES Rental(RentalID),
  CONSTRAINT chk_Employee_Email CHECK (EmpEmail LIKE '_%@_%._%')
);

INSERT INTO Car (CarID, CarName, Model, Year, Type, LicenseNO)
VALUES
  (1, 'Toyota', 'Camry', 2015, 'Sedan', 'ABC123'),
  (2, 'Honda', 'Civic', 2018, 'Sedan', 'DEF456'),
  (3, 'Ford', 'Fusion', 2012, 'Sedan', 'GHI789'),
  (4, 'Nissan', 'Altima', 2016, 'Sedan', 'JKL012'),
  (5, 'Chevrolet', 'Malibu', 2014, 'Sedan', 'MNO345'),
  (6, 'Kia', 'Optima', 2017, 'Sedan', 'PQR678'),
  (7, 'Hyundai', 'Sonata', 2019, 'Sedan', 'STU901');
  
  Select * from car;
  INSERT INTO Customer (CustomerID, Name, Email, PhoneNO, Address)
VALUES
  (1, 'Arul', 'arul@example.com', '123-456-7890', '123 Main St'),
  (2, 'Arul Naveen', 'aruknaveen@example.com', '987-654-3210', '456 Elm St'),
  (3, 'Naveen', 'naveen@example.com', '555-123-4567', '789 Oak St'),
  (4, 'Praveen', 'praveen@example.com', '901-234-5678', '321 Pine St'),
  (5, 'Daisy', 'daisy@example.com', '111-222-3333', '901 Maple St'),
  (6, 'Nithya', 'nithya@example.com', '444-555-6666', '234 Cedar St'),
  (7, 'Arul Thomas', 'arulthomas@example.com', '777-888-9999', '567 Spruce St');
  Select * from customer;
  INSERT INTO Rental (RentalID, CarID, CustomerID, RentalDate, ReturnDate, TotalCost)
VALUES
  (1, 1, 1, '2024-01-01', '2025-01-05', 20000.00),
  (2, 2, 2, '2024-01-05', '2025-01-10', 25000.00),
  (3, 3, 3, '2024-01-10', '2025-01-15', 30000.00),
  (4, 4, 4, '2024-01-15', '2025-01-20', 35000.00),
  (5, 5, 5, '2024-01-20', '2025-01-25', 40000.00),
  (6, 6, 6, '2024-01-25', '2025-01-30', 45000.00),
  (7, 7, 7, '2024-01-30', '2025-02-04', 50000.00);
   Select * from Rental;
   INSERT INTO Payment (PaymentID, RentalID, PaymentMethod, PaymentDate, Amount)
VALUES
  (1001, 1, 'Credit Card', '2024-01-01', 20000.00),
  (1002, 2, 'Cash', '2024-01-05', 25000.00),
  (1003, 3, 'Credit Card', '2024-01-10', 30000.00),
  (1004, 4, 'Cash', '2024-01-15', 35000.00),
  (1005, 5, 'Credit Card', '2024-01-20', 40000.00),
  (1006, 6, 'Cash', '2024-01-25', 45000.00),
  (1007, 7, 'Credit Card', '2024-01-30', 50000.00);
  Select * from Payment;
  INSERT INTO Employee (EmployeeID, RentalID,EmpName, EmpEmail, EmpPhoneNO, EmpRole)
VALUES
  (11,1, 'Mary','mary@example.com', '123-456-7890', 'Manager'),
  (12,2, 'Mary Pushpam', 'marypushpam@example.com', '987-654-3210', 'Staff'),
  (13,3, 'Pushpam', 'pushpam@example.com', '666-123-4567', 'Staff'),
  (14,4, 'Seeman', 'seeman@example.com', '777-123-4567', 'Staff'),
  (15, 5,'MS Dhoni', 'msdhoni@example.com', '111-123-4567', 'Staff'),
  (16,6, 'Sithamparam', 'sithamparam@example.com', '222-123-4567', 'Staff'),
  (17,7, 'Pirabhakaran', 'pirabhakaran@example.com', '444-123-4567', 'Staff');
   Select * from Employee;