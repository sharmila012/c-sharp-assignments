use sql_cc

--1.Write a query to display your birthday( day of week)
select '2004-06-26' as 'Birthdate',datename(WEEKDAY,'2004-06-26') as 
'my birthday weekday'

--2.Write a query to display your age in days
select '2004-06-26' as 'Birthdate',datediff(day,'2004-06-26',getdate()) as 'my age in days'


--dept table creation
create table dept(
deptno int primary key,
dname varchar(30),
loc varchar(30)
)
-- employee table creation
create table emp(
empno int primary key,
ename varchar(30) not null,
job varchar(30) not null,
mgr_id int,
hire_date datetime,
salary int,
comm int,
deptno int references dept(deptno)
)
 
--inserting values
insert into dept values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO' ),
(40,'OPERATIONS','BOSTON')

insert into emp values (7369, 'SMITH', 'CLERK', 7902, '17-JUL-80', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-JUL-81', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-JUL-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-JUL-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10)

--3.Write a query to display all employees information those 
--who joined before 5 years in the current month
select * from emp
where month(hire_date) = month(getdate()) and 
	datediff(year,hire_date,getdate()) >= 5

--UPDATE emp
--set hire_date = '15-JUL-24'
--where empno = 7369

--4. Create table Employee with empno, ename, sal, doj columns 
create table newemployee(
empno int primary key,
ename varchar(30) not null,
sal int,
doj date
)

begin transaction

--4.a)First insert 3 rows 
insert into newemployee values(101, 'Poorna', 25000, '2020-07-01'),
(102, 'Sharmila', 30000, '2021-08-15'),
(103, 'Yashu', 28000, '2022-09-10')
select * from newemployee

--4.b) Update the second row sal with 15% increment
update newemployee set sal = sal*1.15
where empno = 102
select * from newemployee

save transaction trans1

--4.c)Delete first row.
delete from newemployee where empno = 101
select * from newemployee

--After completing above all actions, recall the deleted row without losing increment of second row.
rollback transaction trans1
select * from newemployee

--5.Create a user defined function calculate Bonus for all employees of a  given dept using following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus
create function fn_calbonus(@deptno int,@sal int)
returns float
as
begin
	declare @bonus float
	if @deptno = 10
		set @bonus = @sal * 0.15
	else if @deptno = 20
		set @bonus = @sal * 0.25
	else
		set @bonus = @sal * 0.05
	return @bonus
end

select empno,ename,deptno,salary,
dbo.fn_calbonus(deptno,salary) 
as bonus from emp

--6.Create a procedure to update the salary of employee by 500
--whose dept name is Sales and current salary is below 1500 (use emp table)
create proc sp_updatesal
as
begin
	update e
	set e.salary = e.salary + 500
	from emp e
	join dept d on e.deptno = d.deptno
	where d.dname = 'sales' and e.salary < 1500

	select e.empno, e.ename, e.salary, d.dname
	from emp e
	join dept d on e.deptno = d.deptno
	where d.dname = 'sales'
end
exec sp_updatesal
