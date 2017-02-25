create database Performance;
use Performance;
create table Logs(EventDate datetime, EventLog text)
partition by range columns (EventDate)
(
	partition p01 values less than ('2000-01-01'),
    partition p02 values less than ('2010-01-01'),
    partition p03 values less than (maxvalue)
)

DELIMITER $$
create procedure filldata()
begin
	declare count int default 0;
    
    while count <= 10000000 do
		insert into Logs values
		 (date_add(str_to_date('01/01/1990', '%d/%m/%Y'), interval count minute),
         concat('I perform event number: ', cast(count / 10 as char(11))));
        set count = count + 10;
	end while;
end $$

call filldata();

select * from Logs where EventDate between str_to_date('01/01/1994', '%d/%m/%Y') and str_to_date('01/01/1996', '%d/%m/%Y');
-- Searching speed in partition 1 = 0.235 sec
select * from Logs where EventDate between str_to_date('01/01/2004', '%d/%m/%Y') and str_to_date('01/01/2006', '%d/%m/%Y');
-- Searching speed in partition 2 = 0.250 sec
