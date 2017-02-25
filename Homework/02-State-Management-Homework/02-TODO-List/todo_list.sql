DROP DATABASE IF EXISTS `todo_list`;

CREATE DATABASE `todo_list`
  CHARACTER SET utf8
  COLLATE utf8_general_ci;

USE `todo_list`;

CREATE TABLE `users` (
  id           INT                NOT NULL AUTO_INCREMENT PRIMARY KEY,
  username     VARCHAR(50) UNIQUE NOT NULL,
  passwordHash VARCHAR(300)       NOT NULL
);

CREATE TABLE `todos` (
  id        INT          NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_id   INT          NOT NULL,
  todo_item VARCHAR(300) NOT NULL,
  FOREIGN KEY (user_id) REFERENCES users (id)
    ON DELETE CASCADE
);
