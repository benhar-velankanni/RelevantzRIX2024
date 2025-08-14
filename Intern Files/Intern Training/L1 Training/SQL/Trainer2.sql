USE Eden;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Create Department Table
CREATE TABLE department (
   deptno INT PRIMARY KEY,
   name VARCHAR(50),
   location VARCHAR(50)
);

-- Create Employee Table
CREATE TABLE employee (
   empno INT PRIMARY KEY,
   firstname VARCHAR(50),
   lastname VARCHAR(50),
   date_of_joining DATE,
   manager_code INT,
   salary DECIMAL(10, 2),
   deptno INT,
   FOREIGN KEY (deptno) REFERENCES department(deptno)
);
-- Insert dummy data into Department Table
INSERT INTO department (deptno, name, location) VALUES
(10, 'HR', 'New York'),
(20, 'Finance', 'Chicago'),
(30, 'IT', 'San Francisco'),
(40, 'Marketing', 'Los Angeles'),
(50, 'Logistics', 'Houston');

-- Insert dummy data into Employee Table
INSERT INTO employee (empno, firstname, lastname, date_of_joining, manager_code, salary, deptno) VALUES
(1001, 'Alice', 'Smith', '2020-01-15', NULL, 70000.00, 10),
(1002, 'Bob', 'Johnson', '2019-03-10', 1001, 65000.00, 20),
(1003, 'Carol', 'Williams', '2021-07-23', 1001, 60000.00, 30),
(1004, 'David', 'Brown', '2018-05-11', 1002, 72000.00, 20),
(1005, 'Eva', 'Jones', '2022-09-05', 1003, 58000.00, 30),
(1006, 'Frank', 'Garcia', '2017-11-20', NULL, 90000.00, 40),
(1007, 'Grace', 'Miller', '2021-02-14', 1006, 67000.00, 40),
(1008, 'Hank', 'Davis', '2020-04-30', 1001, 55000.00, 50),
(1009, 'Ivy', 'Rodriguez', '2023-01-19', 1005, 52000.00, 30),
(1010, 'Jake', 'Martinez', '2021-08-08', 1006, 60000.00, 10);

COMMIT;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Display all employees:
SELECT 
    *
FROM
    EMPLOYEE;

-- Display the full names of the employees:
SELECT 
    FIRSTNAME, LASTNAME
FROM
    EMPLOYEE;

-- Display the full names of the empoyee with different column headings:
SELECT 
    FIRSTNAME FNAME, LASTNAME LNAME
FROM
    EMPLOYEE;
    
SELECT 
    FIRSTNAME 'FIRST NAME', LASTNAME 'LAST NAME'
FROM
    EMPLOYEE;
    
-- Display full names ad a single colum:
SELECT 
    CONCAT(FIRSTNAME," ", LASTNAME) AS NAME
FROM
    EMPLOYEE;
    
-- Display employees of Department Number 10:
SELECT 
    *
FROM
    EMPLOYEE
WHERE
    DEPTNO = 10;
    
-- Display EmpNo, Name, Salary and 10% incremented salary as New Sal for all employees:
SELECT 
    EMPNO 'EMPLOYEE NO.',
    CONCAT(FIRSTNAME, ' ', LASTNAME) AS 'EMPLOYEE NAME',
    SALARY 'CURRENT SALARY',
    (SALARY + 1.10) AS 'NEW SALARY'
FROM
    EMPLOYEE;
    
-- Display employees who joined b/w 2020 and 2025:
SELECT 
    *
FROM
    EMPLOYEE
WHERE
    (DATE_OF_JOINING BETWEEN '2020-01-01' AND '2026-01-01'); 
    
-- Display employees with a manager:
SELECT 
    *
FROM
    EMPLOYEE
WHERE
    MANAGER_CODE IS NOT NULL;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Numeric Functions: ROUND, TRUNCATE
SELECT ROUND(172.567, 2); 
SELECT ROUND(172.567, 1);
SELECT ROUND(172.567, 0);
SELECT ROUND(172.567, - 1);
SELECT ROUND(172.567, - 2);
    
SELECT TRUNCATE(172.567, 2); 
SELECT TRUNCATE(172.567, 1);
SELECT TRUNCATE(172.567, 0);
SELECT TRUNCATE(172.567, - 1);
SELECT TRUNCATE(172.567, - 2);

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Character Functions:
SELECT UPPER('VENOM');
SELECT LOWER('VENOM');
SELECT SUBSTR('VENOM', 1, 2);
SELECT INSTR('VENOM', 'V');
SELECT RTRIM('VENOM     ');
SELECT LTRIM('     VENOM');
SELECT LENGTH('VENOM');

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Display the first name and initial of the employees:
SELECT 
    CONCAT(FIRSTNAME,
            '.',
            UPPER(SUBSTR(LASTNAME, 1, 1))) 'EMPLOYEE NAME'
FROM
    EMPLOYEE;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Aggregate Functions:
SELECT 
    COUNT(*) AS 'EMPLOYEE COUNT',
    SUM(SALARY) AS 'TOTAL SALARY',
    AVG(SALARY) AS 'AVG SALARY',
    MIN(SALARY) AS 'LOWEST SALARY',
    MAX(SALARY) AS 'HIGHEST SALARY'
FROM
    EMPLOYEE;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Group By:
-- Display DeptNo and count  of employees in each Dept.
SELECT 
    DEPTNO, COUNT(EMPNO) AS 'NUMBER OF EMP'
FROM
    EMPLOYEE
GROUP BY DEPTNO;

-- Simillarly:
SELECT 
    MANAGER_CODE, COUNT(EMPNO) AS 'NUMBER OF EMP'
FROM
    EMPLOYEE
GROUP BY MANAGER_CODE;

SELECT 
    DEPTNO, MIN(SALARY)
FROM
    EMPLOYEE
GROUP BY DEPTNO;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Joins: INNER, OUTER.
SELECT 
    E.EMPNO, E.FIRSTNAME, E.DEPTNO, D.NAME
FROM
    EMPLOYEE E
        JOIN
    DEPARTMENT D ON E.DEPTNO = D.DEPTNO;

SELECT 
    E.EMPNO, E.FIRSTNAME, E.DEPTNO, D.NAME
FROM
    EMPLOYEE E
        LEFT OUTER JOIN
    DEPARTMENT D ON E.DEPTNO = D.DEPTNO;
    
SELECT 
    E.EMPNO, E.FIRSTNAME, E.DEPTNO, D.NAME
FROM
    EMPLOYEE E
        RIGHT OUTER JOIN
    DEPARTMENT D ON E.DEPTNO = D.DEPTNO;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Display the deptName and count of employees per department:
SELECT 
    D.NAME AS 'DEPT NAME', COUNT(E.EMPNO) AS 'NUMBER OF EMP'
FROM
    EMPLOYEE E
        LEFT OUTER JOIN
    DEPARTMENT D ON E.DEPTNO = D.DEPTNO
GROUP BY E.DEPTNO;

-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Cross Join:
SELECT 
    *
FROM
    EMPLOYEE
        CROSS JOIN
    DEPARTMENT;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Self Join:
SELECT 
    *
FROM
    EMPLOYEE
        JOIN
    EMPLOYEE;
    
-- Display employee name and manager name:
SELECT 
    CONCAT(E.FIRSTNAME, ' ', E.LASTNAME) AS 'EMPLOYEE',
    CONCAT(M.FIRSTNAME, ' ', M.LASTNAME) AS 'MANAGER'
FROM
    EMPLOYEE E
        LEFT OUTER JOIN
    EMPLOYEE M ON E.MANAGER_CODE = M.EMPNO;
    
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Sub quieries:
-- Display emploees wo get more salary than bob:
SELECT 
    CONCAT(FIRSTNAME, ' ', LASTNAME) AS 'NAMES'
FROM
    EMPLOYEE
WHERE
    SALARY > (SELECT 
            SALARY
        FROM
            EMPLOYEE
        WHERE
            FIRSTNAME = 'BOB');
  
-- Employees with more salary than average salary in dept 20:
SELECT 
    CONCAT(FIRSTNAME, ' ', LASTNAME) AS 'NAMES'
FROM
    EMPLOYEE
WHERE
    SALARY > (SELECT 
            AVG(SALARY)
        FROM
            EMPLOYEE
        WHERE
            DEPTNO = 20);
            
-- Employees working in New York:
SELECT 
    CONCAT(FIRSTNAME, ' ', LASTNAME) AS 'NAMES'
FROM
    EMPLOYEE
WHERE
    DEPTNO = (SELECT 
            DEPTNO
        FROM
            DEPARTMENT
        WHERE
            LOCATION = 'NEW YORK');
            
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Multi-Row Quieries:
SELECT 
    *
FROM
    EMPLOYEE
WHERE
    DEPTNO IN (SELECT 
            DEPTNO
        FROM
            DEPARTMENT
        WHERE
            LOCATION = 'NEW YORK');
            
SELECT 
    *
FROM
    EMPLOYEE
WHERE
    SALARY > ANY (SELECT 
            SALARY
        FROM
            EMPLOYEE
        WHERE
            DEPTNO = 30);
            
SELECT 
    *
FROM
    EMPLOYEE
WHERE
    SALARY > ALL (SELECT 
            SALARY
        FROM
            EMPLOYEE
        WHERE
            DEPTNO = 30);
            
-- ----------------------------------------------------------------------------------------------------------------------------------------------------

-- Like:
-- Wildcards: '%' , '_'
-- Employees with 'A' Names:
SELECT * FROM EMPLOYEE WHERE FIRSTNAME LIKE 'A%';

-- ----------------------------------------------------------------------------------------------------------------------------------------------------
           