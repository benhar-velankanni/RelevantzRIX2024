create database online_learning;
use online_learning;
CREATE TABLE course (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(30),
    course_description VARCHAR(30),
    course_amount INT
);

INSERT INTO course (course_id,course_name,course_description,course_amount) VALUES 
(1,'JAVA','CORE JAVA FUNDAMENDALS',5000),
(2,'React js','React js advance',5000),
(3,'PYTHON','ADVANCE PYTHON',15000),
(4,'Mern','Mern advance',15000),
(5,'DOT-NET','DOT-NET FUNDAMENDALS',18000),
(6,'C++','C++ Fundamendals',18000),
(7,'C','ADVANCE C CONCEPTS',5000);

CREATE TABLE student (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(30),
    student_email VARCHAR(30)
);
INSERT INTO student (student_id,student_name,student_email) VALUES 
(201,'Ramesh','abc@gmail.com'),
(202,'Ainesh','vmvkf@gmail.com'),
(203,'Syed','jdadsw@gmail.com'),
(204,'Kumar','wdreds@gmail.com'),
(205,'Velan','mshxb@gmail.com'),
(206,'Billa','sxsxh@gmail.com'),
(207,'Aishwarya','kfrsd@gmail.com');

CREATE TABLE enrollment (
    enrollment_id INT PRIMARY KEY,
    course_id INT,
    student_id INT,
    FOREIGN KEY (course_id)
        REFERENCES course (course_id),
    FOREIGN KEY (student_id)
        REFERENCES student (student_id)
);
INSERT INTO enrollment (enrollment_id,course_id,student_id) VALUES 
(401,2,205),
(402,4,204),
(403,1,206),
(404,2,203),
(405,7,202),
(406,3,201),
(407,6,201);

CREATE TABLE assessment (
    assessment_id INT PRIMARY KEY,
    course_id INT,
    FOREIGN KEY (course_id)
        REFERENCES course (course_id),
    assessment_name VARCHAR(30)
);
INSERT INTO assessment (assessment_id,course_id,assessment_name) VALUES
(501,4,'Mern Assessment'),
(502,5,'Dot-net Assessment'),
(503,3,'PYTHON Assessment'),
(504,2,'React js Assessment'),
(505,1,'Java Assessment'),
(506,6,'C++ Assessment'),
(507,7,'C Assessment');

CREATE TABLE student_assessment (
    student_assessment_id INT PRIMARY KEY,
    student_id INT,
    FOREIGN KEY (student_id)
        REFERENCES student (student_id),
    assessment_id INT,
    FOREIGN KEY (assessment_id)
        REFERENCES assessment (assessment_id),
    score INT
);
INSERT INTO student_assessment(student_assessment_id,student_id,assessment_id,score) VALUES
(801,204,501,85),
(802,205,504,85),
(803,203,504,85),
(804,202,507,85),
(805,201,503,85),
(806,207,501,85),
(807,206,505,85);





