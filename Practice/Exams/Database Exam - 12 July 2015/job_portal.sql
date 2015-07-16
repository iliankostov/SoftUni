-- Problem 16

-- Task 1
DROP DATABASE IF EXISTS `job_portal`;

CREATE DATABASE `job_portal` 
CHARACTER SET utf8 
COLLATE utf8_general_ci;

USE `job_portal`;

CREATE TABLE `users` (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    username NVARCHAR(50) NOT NULL,
    fullname NVARCHAR(300) NOT NULL);

CREATE TABLE `salaries` (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    from_value decimal(10, 2) NOT NULL,
    to_value decimal(10, 2) NOT NULL);

CREATE TABLE `job_ads` (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    title NVARCHAR(50) NOT NULL,
    description NVARCHAR(300),
    author_id int not null,
    salary_id int not null,
    FOREIGN KEY (author_id) REFERENCES users(id) on delete cascade,
	FOREIGN KEY (salary_id) REFERENCES salaries(id) on delete cascade);  
    
CREATE TABLE `job_ad_applications` (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    job_ad_id int NOT NULL,
    user_id int NOT NULL,
    FOREIGN KEY (job_ad_id) REFERENCES job_ads(id) on delete cascade,
	FOREIGN KEY (user_id) REFERENCES users(id) on delete cascade);
    
insert into users (username, fullname)
values ('pesho', 'Peter Pan'),
('gosho', 'Georgi Manchev'),
('minka', 'Minka Dryzdeva'),
('jivka', 'Jivka Goranova'),
('gago', 'Georgi Georgiev'),
('dokata', 'Yordan Malov'),
('glavata', 'Galin Glavomanov'),
('petrohana', 'Peter Petromanov'),
('jubata', 'Jivko Jurandov'),
('dodo', 'Donko Drozev'),
('bobo', 'Bay Boris');

insert into salaries (from_value, to_value)
values (300, 500),
(400, 600),
(550, 700),
(600, 800),
(1000, 1200),
(1300, 1500),
(1500, 2000),
(2000, 3000);

insert into job_ads (title, description, author_id, salary_id)
values ('PHP Developer', NULL, (select id from users where username = 'gosho'), (select id from salaries where from_value = 300)),
('Java Developer', 'looking to hire Junior Java Developer to join a team responsible for the development and maintenance of the payment infrastructure systems', (select id from users where username = 'jivka'), (select id from salaries where from_value = 1000)),
('.NET Developer', 'net developers who are eager to develop highly innovative web and mobile products with latest versions of Microsoft .NET, ASP.NET, Web services, SQL Server and related applications.', (select id from users where username = 'dokata'), (select id from salaries where from_value = 1300)),
('JavaScript Developer', 'Excellent knowledge in JavaScript', (select id from users where username = 'minka'), (select id from salaries where from_value = 1500)),
('C++ Developer', NULL, (select id from users where username = 'bobo'), (select id from salaries where from_value = 2000)),
('Game Developer', NULL, (select id from users where username = 'jubata'), (select id from salaries where from_value = 600)),
('Unity Developer', NULL, (select id from users where username = 'petrohana'), (select id from salaries where from_value = 550));

insert into job_ad_applications(job_ad_id, user_id)
values 
	((select id from job_ads where title = 'C++ Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Game Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'JavaScript Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'Unity Developer'), (select id from users where username = 'petrohana')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'jivka')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'jivka'));

select 
	u.username,
    u.fullname,
    ja.title as Job,
    s.from_value as 'From Value',
    s.to_value as 'To Value'
from job_ad_applications as jaa
join users as u
on u.Id = jaa.user_id
join job_ads as ja
on ja.id = jaa.job_ad_id
join salaries as s
on ja.salary_id = s.Id
order by u.username, ja.title
