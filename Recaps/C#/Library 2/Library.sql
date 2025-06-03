-- Create database
CREATE DATABASE library;

USE library;

-- Create books table
CREATE TABLE
    books (
        id INT AUTO_INCREMENT PRIMARY KEY,
        isbn VARCHAR(20) UNIQUE NOT NULL,
        title VARCHAR(255) NOT NULL,
        author_name VARCHAR(255) NOT NULL,
        publication_year INT NOT NULL,
        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
        updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
    );

-- Insert some sample data (optional)
INSERT INTO
    books (isbn, title, author_name, publication_year)
VALUES
    (
        '978-0134685991',
        'Effective Java',
        'Joshua Bloch',
        2017
    ),
    (
        '978-0135166307',
        'Clean Code',
        'Robert C. Martin',
        2008
    ),
    (
        '978-0596009205',
        'Head First Design Patterns',
        'Eric Freeman',
        2004
    );