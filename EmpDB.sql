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

Alter table Employee Add IsActive varchar(20)
 
select * from Employee

CREATE TABLE Department (
    Dept_ID INT PRIMARY KEY,
    Dept_Name VARCHAR(50) not null
);
 select * from Department
 select * from Grade_Master
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

CREATE TABLE Holiday (
    HolidayID INT IDENTITY,
    HolidayName VARCHAR(100) NOT NULL,
    HolidayDate DATE NOT NULL
);




