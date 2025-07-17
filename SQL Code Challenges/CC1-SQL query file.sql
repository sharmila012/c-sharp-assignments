create database sql_cc
use sql_cc

create table books(
id int primary key,
title varchar(50),
author varchar(50),
isbn float unique,
published_date datetime
)

insert into books values (1,'my first sql book','mary parker',981483029127,'2012-02-22 12:08:17'),
(2,'my second sql book','john mayer',857300923713,'1972-07-03 09:22:45'),
(3,'my third sql book','cary flint',523120967812,'2015-10-18 14:05:44')

-- 1.Write a query to fetch the details of the books written by author whose name ends with er.
select * from books where author like '%er'


create table reviews(
id int ,
book_id int references books(id),
reviewer_name varchar(50),
content varchar(100),
rating int,
published_date datetime
)

insert into reviews values (1,1,'john smith','my first review',4,'2017-12-10 05:50:11'),
(2,2,'john smith','my second review',5,'2017-10-13 15:05:12'),
(3,2,'alice walker','another review',1,'2017-10-22 23:47:10')

-- 2.Display the Title ,Author and ReviewerName for all the books from the above table 
select title,author,reviewer_name 
from books,reviews
where books.id = reviews.book_id

-- 3.Display the  reviewer name who reviewed more than one book.
select reviewer_name,count(*) as 'Number of books reviewed'
from reviews
group by reviewer_name
having count(*)>1


create table customers(
id int primary key,
cname varchar(30) not null,
age int,
caddress varchar(100),
salary float
)

insert into customers values (1,'ramesh',32,'ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'chaitali',25,'Mumbai',6500.00),
(5,'hardik',27,'bhopal',8500.00),
(6,'komal',22,'MP',4500.00),
(7,'muffy',24,'Indore',10000.00)

-- 4.Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
select cname as 'Customer name',caddress as 'Customer address' from customers where caddress like '%o%'



create table orders (
oid int,
date_purchased datetime,
customer_id int references customers(id),
amount int
)

insert into orders values (102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,30206)

-- 5.Write a query to display the   Date,Total no of customer  placed order on same Date 
select date_purchased,count(distinct customer_id) as 'Total customers placed order'
from orders
group by date_purchased


create table employee(
id int primary key,
ename varchar(30) not null,
age int,
eaddress varchar(100),
salary float
)

insert into employee values (1,'ramesh',32,'ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'chaitali',25,'Mumbai',6500.00),
(5,'hardik',27,'bhopal',8500.00),
(6,'komal',22,'MP',null),
(7,'muffy',24,'Indore',null)

-- 6.Display the Names of the Employee in lower case, whose salary is null 
select lower(ename),salary 
from employee
where salary is null


create table students(
registerno int primary key,
sname varchar(50),
age int,
qualification varchar(50),
mobileno varchar(13),
mail_id varchar(50),
slocation varchar(50),
gender varchar(20)
)

insert into students values (2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'SaiSaran', 21, 'B.A', '7890345678', 'saran@gmail.com', 'Madurai', 'F'),
(7, 'Tom', 23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune', 'M');

-- 7.Write a sql server query to display the Gender,Total no of male and female from the above relation   
select gender,count(*) as 'Total number' 
from students
group by gender












