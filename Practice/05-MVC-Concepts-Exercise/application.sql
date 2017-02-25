DROP DATABASE IF EXISTS `mvc_app`;

CREATE DATABASE `mvc_app`
  CHARACTER SET utf8
  COLLATE utf8_general_ci;

USE `mvc_app`;

CREATE TABLE `users` (
  id       INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(255),
  password VARCHAR(255),
  gold     INT(11),
  food     INT(11)
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

INSERT INTO users (username, password, gold, food) VALUES ('admin', '$2y$10$ilwmxJFaAnSJ03DzgUD4u.jUQWzSN7mEsijwJn7GF6Z2dpAtiWXYO', 1500, 1500);

INSERT INTO buildings (name) VALUES ('Barracks');
INSERT INTO buildings (name) VALUES ('Archery Range');
INSERT INTO buildings (name) VALUES ('Stables');
INSERT INTO buildings (name) VALUES ('Siege Workshop');

INSERT INTO building_levels (building_id, level, gold, food) VALUES (1, 1, 100, 100);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (1, 2, 200, 200);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (1, 3, 300, 300);

INSERT INTO building_levels (building_id, level, gold, food) VALUES (2, 1, 100, 100);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (2, 2, 200, 200);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (2, 3, 300, 300);

INSERT INTO building_levels (building_id, level, gold, food) VALUES (3, 1, 100, 100);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (3, 2, 200, 200);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (3, 3, 300, 300);

INSERT INTO building_levels (building_id, level, gold, food) VALUES (4, 1, 100, 100);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (4, 2, 200, 200);
INSERT INTO building_levels (building_id, level, gold, food) VALUES (4, 3, 300, 300);

INSERT INTO user_buildings_level (user_id, building_id, level) VALUES (1, 1, 0);
INSERT INTO user_buildings_level (user_id, building_id, level) VALUES (1, 2, 0);