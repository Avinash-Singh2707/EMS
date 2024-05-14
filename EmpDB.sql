CREATE DATABASE EmpDatabase;
 

 
CREATE TABLE Employee (
    Emp_ID INT PRIMARY KEY,
    Emp_First_Name VARCHAR(25) NOT NULL,
    Emp_Last_Name VARCHAR(25),
	Emp_Date_of_Birth DATE,
    Emp_Date_of_Joining DATE,
    Emp_Dept_ID INT,
    Emp_Grade VARCHAR(10) NOT NULL,
    Emp_Designation VARCHAR(50),
    Emp_Salary DECIMAL(10,2),
    Emp_Gender VARCHAR(10),
    Emp_Marital_Status VARCHAR(20),
    Emp_Home_Address VARCHAR(255),
    Emp_Contact_Num VARCHAR(15),
	FOREIGN KEY (Emp_Dept_ID) REFERENCES Department(Dept_ID),
	FOREIGN KEY (Emp_Grade) REFERENCES GRADE_MASTER(GRADE_CODE)
);

Alter table Employee Add Status varchar(20) default 'Active';

delete from Employee
select * from Employee
UPDATE Employee
SET Status = 'Active';

CREATE TABLE Department (
    Dept_ID INT PRIMARY KEY,
    Dept_Name VARCHAR(50) not null
);
 select * from Department
 select * from Grade_Master
 select * from Employee
CREATE TABLE Admin (
    AdminId VARCHAR(50) not null,
    AdminPassword VARCHAR(50) not null,
    
);
insert into Admin values('Admin','Admin')
 select * from Admin
 select * from Grade_master

CREATE TABLE Grade_master (
    Grade_Code VARCHAR(10) PRIMARY KEY,
    Description VARCHAR(50) not null,
    Min_Salary DECIMAL(10,2) not null,
    Max_Salary DECIMAL(10,2) not null
);
select * from Grade_master;

CREATE TABLE Holiday (
    HolidayID INT Primary key,
    HolidayName VARCHAR(100) NOT NULL,
    HolidayDate DATE NOT NULL
);


select * from Holiday

INSERT INTO Holiday VALUES (1,'New Year', '2024-01-01');
INSERT INTO Holiday VALUES (2,'Independence Day', '2024-07-04');

INSERT INTO Holiday VALUES (3,'Christmas Day', '2024-12-25');

drop table Holiday



