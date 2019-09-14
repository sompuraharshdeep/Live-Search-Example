create table employee
(
	empId int primary key not null identity,
	empName varchar(50) not null,
	empEmail varchar(50) not null unique,
	empContact varchar(20) not null unique,
	empDOB date not null
)