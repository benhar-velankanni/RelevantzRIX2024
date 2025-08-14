Create database EmployeeMVCDB;
 
use EmployeeMVCDB;
 
CREATE TABLE Employees (
 
  EmployeeId INT PRIMARY KEY AUTO_INCREMENT,
 
  EmployeeName VARCHAR(100),
 
  Email VARCHAR(100),
 
  Department VARCHAR(100),
 
  HireDate datetime
 
);

select * from Employees;

insert into Employees values(1,'rahu','sdfugd','dfgd','2025-10-12');
 