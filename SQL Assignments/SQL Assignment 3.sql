use sql_assignments

select * from emp
select * from dept

--1. Retrieve a list of MANAGERS. 
select e2.empno as 'manager id',e2.ename as 'manager name'
from emp e1
join emp e2 on e2.mgr_id = e1.empno

--2. Find out the names and salaries of all employees earning more than 1000 per 
--month. 
select ename,salary 
from emp
where salary > 1000

--3. Display the names and salaries of all employees except JAMES. 
select ename,salary
from emp
where ename ! = 'james'

--4. Find out the details of employees whose names begin with ‘S’. 
select * from emp where ename like 's%'

--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select empno,ename from emp
where ename like '%a%'

--6. Find out the names of all employees that have ‘L’ as their third character in 
--their name. 
select empno,ename from emp
where ename like '__l%'

--7. Compute daily salary of JONES. 
select empno,ename,salary as 'monthly salary',salary/30 as 'Daily salary' 
from emp
where ename = 'jones'

--8. Calculate the total monthly salary of all employees. 
select empno,ename,salary as 'monthly salary',salary/30 as 'Daily salary' 
from emp

--9. Print the average annual salary . 
--select (sum(salary)*12)/count(*) as 'average annual salary' from emp
select avg(salary)*12 as 'average annual salary' from emp

--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 
select ename,job,salary,deptno 
from emp
where deptno = 30 and job!='salesman'

--11. List unique departments of the EMP table. 
select distinct e.deptno,d.dname
from emp e
join dept d on e.deptno = d.deptno --there is no dept 40 in emp table

--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as 'employee', salary as 'monthly salary'
from emp 
where salary > 1500 and deptno in (10,30)

--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000.
select ename,job,salary from emp
where job in('manager','analyst') and salary not in(1000,3000,5000)

--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
select ename,salary,comm 
from emp
where comm > salary*1.10

--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
select ename,mgr_id,deptno 
from emp
where ename like '%l%l%' and (deptno = 30 or mgr_id = 7782)

--16. Display the names of employees with experience of over 30 years and under 40 yrs.
-- Count the total number of employees. 
select ename,hire_date,
datediff(year,hire_date,getdate()) as 'experience years'
from emp
where datediff(year,hire_date,getdate()) between 31 and 39

select count(*) as 'total employees' from emp

--17. Retrieve the names of departments in ascending order and their employees in 
--descending order. 
select d.dname,e.ename
from dept d
join emp e on d.deptno = e.deptno
order by d.dname asc,e.ename desc

--18. Find out experience of MILLER. 
select empno,ename,hire_date,
datediff(year,hire_date,getdate()) as 'experience years'
from emp
where ename = 'miller'
