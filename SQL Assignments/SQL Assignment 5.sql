use sql_assignments

--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details
--give the code in lower case letters

select * from emp

create procedure generate_payslip
    @employee_id int
as
begin
    declare @employee_name varchar(100)
    declare @salary decimal(10,2)
    declare @hra decimal(10,2)
    declare @da decimal(10,2)
    declare @pf decimal(10,2)
    declare @it decimal(10,2)
    declare @deductions decimal(10,2)
    declare @gross_salary decimal(10,2)
    declare @net_salary decimal(10,2)

    select 
        @employee_name = ename,
        @salary = salary
    from emp
    where empno = @employee_id

    set @hra = @salary * 0.10
    set @da = @salary * 0.20
    set @pf = @salary * 0.08
    set @it = @salary * 0.05
    set @deductions = @pf + @it
    set @gross_salary = @salary + @hra + @da
    set @net_salary = @gross_salary - @deductions

    print 'payslip'
    print 'employee id     : ' + cast(@employee_id as varchar)
    print 'employee name   : ' + @employee_name
    print 'basic salary    : ' + cast(@salary as varchar)
    print 'hra (10%)       : ' + cast(@hra as varchar)
    print 'da (20%)        : ' + cast(@da as varchar)
    print 'pf (8%)         : ' + cast(@pf as varchar)
    print 'it (5%)         : ' + cast(@it as varchar)
    print 'deductions      : ' + cast(@deductions as varchar)
    print 'gross salary    : ' + cast(@gross_salary as varchar)
    print 'net salary      : ' + cast(@net_salary as varchar)
end

exec generate_payslip 7566

--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like
--“Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc
--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation 

create table public_holiday (
    holiday_date date primary key,
    holiday_name varchar(100)
)

insert into public_holiday values 
('2025-08-15', 'independence day'),
('2025-10-21', 'diwali'),
('2025-01-26', 'republic day'),
('2025-12-25', 'christmas'),
('2025-07-23', 'dusshera');

create trigger trg_restrict_on_holiday
on emp
for insert, update, delete
as
begin
    declare @today date = cast(getdate() as date)
    declare @holiday_name varchar(100)

    select @holiday_name = holiday_name
    from public_holiday
    where holiday_date = @today

    if @holiday_name is not null
    begin
        rollback transaction
        raiserror('due to %s, you cannot manipulate data', 16, 1, @holiday_name)
    end
end

insert into emp values(100,'abc','ceo',null,'17-DEC-80',10000,null,10)







































