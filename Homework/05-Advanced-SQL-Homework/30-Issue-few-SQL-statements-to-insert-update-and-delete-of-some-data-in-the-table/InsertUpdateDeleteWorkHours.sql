-- insert data
insert into WorkHours ( WorkDate, Task, WorkHours, Comments, EmployeeId ) values
('07-01-2015', 'Todo One', '08:00:00', 'Precessing', 1),
('07-02-2015', 'Todo Two', '07:00:00', 'Precessing', 2),
('07-03-2015', 'Todo Three', '09:00:00', 'Precessing', 3),
('07-04-2015', 'Todo Four', '07:00:00', 'Precessing', 4),
('07-05-2015', 'Todo Five', '09:00:00', 'Precessing', 5),
('07-06-2015', 'Todo Six', '07:00:00', 'Precessing', 6),
('07-07-2015', 'Todo Seven', '08:00:00', 'Precessing', 7),
('07-08-2015', 'Todo Eight', '09:00:00', 'Precessing', 8),
('07-09-2015', 'Todo Nine', '08:00:00', 'Precessing', 9),
('07-10-2015', 'Todo Ten', '09:00:00', 'Precessing', 10)
-- update data
update WorkHours set Comments = 'Done' where EmployeeId in (2, 5, 8, 10)
-- delete data
delete from WorkHours where EmployeeId in (2, 5, 8, 10)