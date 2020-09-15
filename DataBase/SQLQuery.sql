USE master
GO

CREATE DATABASE TodoListDB
GO

USE TodoListDB
GO

CREATE TABLE Role (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Role NVARCHAR(50)
)
GO

TRUNCATE TABLE Role
GO

INSERT INTO Role(Role)
VALUES(N'Giám Đôc')

INSERT INTO Role(Role)
VALUES(N'Nhân Viên')
GO

CREATE TABLE Employee (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Email NVARCHAR(100),
	Password VARCHAR(100),
	FullName NVARCHAR(100),
	PhoneNumber VARCHAR(10),
	DateCreated DATE DEFAULT GETDATE(),
	IdRole INT DEFAULT 1,
	CONSTRAINT User_Role
	FOREIGN KEY(IdRole)
	REFERENCES dbo.Role(Id)
	ON DELETE CASCADE
)
GO

TRUNCATE TABLE Employee
GO

INSERT INTO Employee(Email, Password, FullName, PhoneNumber, IdRole)
VALUES(N'giamdoc1@gmail.com', '12345', N'Phong Chân Lý', '0345225651', 1)

INSERT INTO Employee(Email, Password, FullName, PhoneNumber, IdRole)
VALUES(N'giamdoc2@gmail.com', '12345', N'Nhật The Best', '0345225651', 1)

INSERT INTO Employee(Email, Password, FullName, PhoneNumber, IdRole)
VALUES(N'nhanvien1@gmail.com', '12345', N'Sang Đẹp Trai', '0345225651', 2)

INSERT INTO Employee(Email, Password, FullName, PhoneNumber, IdRole)
VALUES(N'nhanvien2@gmail.com', '12345', N'Linh Xinh Gái', '0345225651', 2)

INSERT INTO Employee(Email, Password, FullName, PhoneNumber, IdRole)
VALUES(N'nhanvien3@gmail.com', '12345', N'Quân Bất Cần', '0345225651', 2)
GO

CREATE TABLE Status (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Status NVARCHAR(50)
)
GO

TRUNCATE TABLE Status
GO

INSERT INTO Status(Status)
VALUES(N'Việc Cần Làm')

INSERT INTO Status(Status)
VALUES(N'Việc Đang Làm')

INSERT INTO Status(Status)
VALUES(N'Việc Đã Hoàn Thành')

INSERT INTO Status(Status)
VALUES(N'Việc Trễ Hạn')
GO

SELECT *
FROM Role

SELECT *
FROM Employee
GO

SELECT *
FROM Status

DROP TABLE Employee
GO

DROP TABLE Role
GO

DROP TABLE Status
GO