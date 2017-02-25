DROP DATABASE IF EXISTS `i_cart`;

CREATE DATABASE `i_cart`
  CHARACTER SET utf8
  COLLATE utf8_general_ci;

USE `i_cart`;

CREATE TABLE `roles` (
  id   INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255)
);

INSERT INTO roles (name)
VALUES ('admin'), ('editor'), ('user');

CREATE TABLE `users` (
  id       INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(255) UNIQUE,
  password VARCHAR(255),
  role_id  INT,
  cash     DECIMAL(18, 9),
  FOREIGN KEY (role_id) REFERENCES roles (id)
);

INSERT INTO users (username, password, role_id, cash)
VALUES ('admin', '$2y$10$ilwmxJFaAnSJ03DzgUD4u.jUQWzSN7mEsijwJn7GF6Z2dpAtiWXYO', 1, 1000000);

CREATE TABLE `categories` (
  id   INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255)
);

INSERT INTO categories (name)
VALUES ('laptops'), ('notebooks'), ('tablets'), ('smartphones'), ('accessoaries');

CREATE TABLE `products` (
  id          INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name        VARCHAR(255),
  model       VARCHAR(255),
  price       DECIMAL(18, 9),
  quantity    INT,
  category_id INT,
  FOREIGN KEY (category_id) REFERENCES categories (id)
    ON DELETE CASCADE
);

CREATE TABLE `users_products` (
  id         INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_id    INT,
  product_id INT,
  FOREIGN KEY (user_id) REFERENCES users (id)
    ON DELETE CASCADE,
  FOREIGN KEY (product_id) REFERENCES products (id)
    ON DELETE CASCADE
);

CREATE TABLE `available_products` (
  id         INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_id    INT,
  product_id INT,
  discount   INT,
  FOREIGN KEY (user_id) REFERENCES users (id)
    ON DELETE CASCADE,
  FOREIGN KEY (product_id) REFERENCES products (id)
    ON DELETE CASCADE
);

CREATE TABLE `user_cart_products` (
  id         INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_id    INT,
  product_id INT,
  totalprice INT,
  quantiry   INT,
  FOREIGN KEY (user_id) REFERENCES users (id)
    ON DELETE CASCADE,
  FOREIGN KEY (product_id) REFERENCES products (id)
    ON DELETE CASCADE
);
