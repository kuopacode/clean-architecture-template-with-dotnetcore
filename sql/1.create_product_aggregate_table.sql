CREATE TABLE products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    product_name VARCHAR(50),
    sale_code VARCHAR(20),
    description TEXT,
    status INT,
    sale_start_date DATETIME,
    sale_end_date DATETIME,
    stock INT,
    create_time DATETIME
);

CREATE TABLE product_infos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    product_id INT NOT NULL,
    title VARCHAR(20),
    content VARCHAR(100)
);

CREATE TABLE product_pics (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    product_id INT NOT NULL,
    picture_url VARCHAR(200)
);

CREATE TABLE product_categories (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    product_id INT NOT NULL,
    d1_category_id INT NOT NULL,
    d2_category_id INT NOT NULL,
    d3_category_id INT NOT NULL
);

CREATE TABLE product_price_schedules (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    product_id INT NOT NULL,
    sale_start_date DATETIME,
    sale_end_date DATETIME,
    market_price INT NOT NULL,
    sale_price INT NOT NULL,
    create_time DATETIME,
    is_delete BOOLEAN
);