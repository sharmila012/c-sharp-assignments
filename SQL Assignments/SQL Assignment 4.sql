use sql_assignments

--1.	Write a T-SQL Program to find the factorial of a given number.
declare @given_nbr int = 5
declare @fact bigint = 1
declare @temp int = @given_nbr
while @given_nbr > 1
	begin
		set @fact = @fact * @given_nbr
		set @given_nbr = @given_nbr - 1
	end
print 'factorial of '+cast(@temp as varchar)+ ' is '+cast(@fact as varchar)


--2. Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
create proc sp_multable @num int,@endnum int
as
begin
	declare @i int = 1
	while @i < = @endnum
		begin
			print cast(@num as varchar) + ' X ' + cast(@i as varchar)
			+ ' = '+cast(@num*@i as varchar)
			set @i = @i + 1
		end
end

exec sp_multable 8,10


--3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

create table student (
    sid int primary key,
    sname varchar(50)
)

create table marks (
    mid int primary key,
    sid int references student(sid),
    score int
)

insert into student values
(1, 'jack'), (2, 'rithvik'), (3, 'jaspreeth'),
(4, 'praveen'), (5, 'bisa'), (6, 'suraj')

insert into marks values
(1, 1, 23), (2, 6, 95), (3, 4, 98),
(4, 2, 17), (5, 3, 53), (6, 5, 13)

create function fn_getstatus (@score int)
returns varchar(10)
as
begin
    return case when @score >= 50 then 'pass' else 'fail' end;
end

select s.sid, s.sname, m.score, dbo.fn_getstatus(m.score) as status
from student s
join marks m on s.sid = m.sid;

