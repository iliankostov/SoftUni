DROP DATABASE IF EXISTS `application`;

CREATE DATABASE `application`
  CHARACTER SET utf8
  COLLATE utf8_general_ci;

USE `application`;

CREATE TABLE `users` (
  id           INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  username     VARCHAR(255),
  password     VARCHAR(255),
  gold         INT(11),
  food         INT(11)
);

CREATE TABLE `buildings` (
  id   INT          NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(300) NOT NULL
);

CREATE TABLE `building_levels` (
  building_id INT(11),
  level       INT(11),
  gold        INT(11),
  food        INT(11),
  FOREIGN KEY (building_id) REFERENCES buildings (id)
    ON DELETE CASCADE
);

CREATE TABLE `user_buildings_level` (
  user_id     INT(11),
  building_id INT(11),
  level       INT(11),
  FOREIGN KEY (user_id) REFERENCES users (id)
    ON DELETE CASCADE,
  FOREIGN KEY (building_id) REFERENCES buildings (id)
    ON DELETE CASCADE,
  UNIQUE (user_id, building_id, level)
);