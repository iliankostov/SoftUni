DROP DATABASE IF EXISTS `i_cart`;

CREATE DATABASE `i_cart`
  CHARACTER SET utf8
  COLLATE utf8_general_ci;

USE `i_cart`;

CREATE TABLE `users` (
  id       INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(255),
  password VARCHAR(255)
);

INSERT INTO users (username, password)
VALUES ('admin', '$2y$10$ilwmxJFaAnSJ03DzgUD4u.jUQWzSN7mEsijwJn7GF6Z2dpAtiWXYO');
