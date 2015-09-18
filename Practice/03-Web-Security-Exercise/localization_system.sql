DROP DATABASE IF EXISTS `localization_system`;

CREATE DATABASE `localization_system`
  CHARACTER SET utf8
  COLLATE utf8_general_ci;

USE `localization_system`;

CREATE TABLE `translations` (
  id      INT(11)      NOT NULL AUTO_INCREMENT PRIMARY KEY,
  tag     VARCHAR(250) NOT NULL,
  text_en TEXT         NOT NULL,
  text_bg TEXT         NOT NULL
);

INSERT INTO `translations` (`tag`, `text_en`, `text_bg`) VALUES
  ('greeting_header_hello', 'Hello', 'Здравейте'),
  ('welcome_message', 'Welcome to our site', 'Добре дошли в нашия сайт');