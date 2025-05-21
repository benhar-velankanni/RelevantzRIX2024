mysql> create database DigitalPrescription;
Query OK, 1 row affected (0.04 sec)

mysql> use DigitalPrescription;
Database changed

mysql> create table Prescription(
    -> PrescriptionID int primary key auto_increment,
    -> PatientName varchar(20),
    -> DoctorName varchar(20),
    -> MedicineName varchar(20),
    -> Date date,
    -> TotalAmount double
    -> );
Query OK, 0 rows affected (0.05 sec)

mysql> desc Prescription;
+----------------+-------------+------+-----+---------+----------------+
| Field          | Type        | Null | Key | Default | Extra          |
+----------------+-------------+------+-----+---------+----------------+
| PrescriptionID | int         | NO   | PRI | NULL    | auto_increment |
| PatientName    | varchar(20) | YES  |     | NULL    |                |
| DoctorName     | varchar(20) | YES  |     | NULL    |                |
| MedicineName   | varchar(20) | YES  |     | NULL    |                |
| Date           | date        | YES  |     | NULL    |                |
| TotalAmount    | double      | YES  |     | NULL    |                |
+----------------+-------------+------+-----+---------+----------------+
6 rows in set (0.01 sec)

mysql> SELECT * FROM Prescription;
+----------------+-------------+------------+--------------+------------+-------------+
| PrescriptionID | PatientName | DoctorName | MedicineName | Date       | TotalAmount |
+----------------+-------------+------------+--------------+------------+-------------+
|              1 | Begonia     | Dr Pal     | Dolo         | 2025-04-03 |         300 |
+----------------+-------------+------------+--------------+------------+-------------+
1 row in set (0.00 sec)

mysql> SELECT * FROM Prescription;
+----------------+-------------+------------+--------------+------------+-------------+
| PrescriptionID | PatientName | DoctorName | MedicineName | Date       | TotalAmount |
+----------------+-------------+------------+--------------+------------+-------------+
|              1 | Begonia     | Dr Pal     | Dolo         | 2025-04-03 |         300 |
|              2 | Bob         | Dr John    | Parcetamol   | 2025-09-09 |         500 |
+----------------+-------------+------------+--------------+------------+-------------+
2 rows in set (0.00 sec)

mysql> SELECT * FROM Prescription;
+----------------+--------------+------------+--------------+------------+-------------+
| PrescriptionID | PatientName  | DoctorName | MedicineName | Date       | TotalAmount |
+----------------+--------------+------------+--------------+------------+-------------+
|              1 | Arul Begonia | Dr Doe     | Dolo         | 2024-09-08 |         400 |
|              2 | Bob          | Dr John    | Parcetamol   | 2025-09-09 |         500 |
+----------------+--------------+------------+--------------+------------+-------------+
2 rows in set (0.00 sec)

mysql> SELECT * FROM Prescription;
+----------------+--------------+-------------+--------------+------------+-------------+
| PrescriptionID | PatientName  | DoctorName  | MedicineName | Date       | TotalAmount |
+----------------+--------------+-------------+--------------+------------+-------------+
|              1 | Arul Begonia | Dr Doe      | Dolo         | 2024-09-08 |         400 |
|              2 | Shinchan     | Dr Hemowari | Paracetamol  | 2023-12-21 |        1000 |
+----------------+--------------+-------------+--------------+------------+-------------+
2 rows in set (0.00 sec)

mysql> SELECT * FROM Prescription;
+----------------+--------------+---------------+--------------+------------+-------------+
| PrescriptionID | PatientName  | DoctorName    | MedicineName | Date       | TotalAmount |
+----------------+--------------+---------------+--------------+------------+-------------+
|              1 | Arul Begonia | Dr Doe        | Dolo         | 2024-09-08 |         400 |
|              2 | Shinchan     | Dr Hemowari   | Paracetamol  | 2023-12-21 |        1000 |
|              3 | Sam          | Dr Fox        | Cetaphil     | 2021-08-18 |         200 |
|              4 | Harry        | Dr Hermoyinie | Dolo         | 1998-02-02 |         150 |
+----------------+--------------+---------------+--------------+------------+-------------+
4 rows in set (0.00 sec)

mysql> SELECT * FROM Prescription;
+----------------+--------------+-------------+--------------+------------+-------------+
| PrescriptionID | PatientName  | DoctorName  | MedicineName | Date       | TotalAmount |
+----------------+--------------+-------------+--------------+------------+-------------+
|              1 | Arul Begonia | Dr Doe      | Dolo         | 2024-09-08 |         400 |
|              2 | Shinchan     | Dr Hemowari | Paracetamol  | 2023-12-21 |        1000 |
|              3 | Sam          | Dr Fox      | Cetaphil     | 2021-08-18 |         200 |
+----------------+--------------+-------------+--------------+------------+-------------+
3 rows in set (0.00 sec)






























