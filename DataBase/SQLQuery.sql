USE master
GO

DROP DATABASE TodoListDB
GO

CREATE DATABASE TodoListDB
GO

USE TodoListDB
GO

CREATE TABLE Role(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Role NVARCHAR(50),
	DateCreated DATE DEFAULT GETDATE()
)
GO

TRUNCATE TABLE Role
GO

INSERT INTO Role(Role)
VALUES(N'Giám Đôc')

INSERT INTO Role(Role)
VALUES(N'Nhân Viên')
GO

CREATE TABLE Employee(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Email NVARCHAR(100),
	Password VARCHAR(100),
	FullName NVARCHAR(100),
	PhoneNumber VARCHAR(10),
	IdRole INT DEFAULT 1,
	DateCreated DATE DEFAULT GETDATE(),
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

CREATE TABLE WorkStatus(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	WorkStatus NVARCHAR(50),
	DateCreated DATE DEFAULT GETDATE()
)
GO

TRUNCATE TABLE WorkStatus
GO

INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Cần Làm')

INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Đang Làm')

INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Đã Hoàn Thành')

INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Trễ Hạn')
GO

CREATE TABLE WorkListStatus(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	WorkListStatus VARCHAR(100),
	DateCreated DATE DEFAULT GETDATE()
)
GO

TRUNCATE TABLE WorkListStatus
GO

INSERT INTO WorkListStatus(WorkListStatus)
VALUES('Public')

INSERT INTO WorkListStatus(WorkListStatus)
VALUES('Private')
GO

CREATE TABLE WorkList(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	WorkListName NVARCHAR(100),
	IdWorkListStatus INT DEFAULT 1,
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT WorkList_WorkListStatus
	FOREIGN KEY(IdWorkListStatus)
	REFERENCES dbo.WorkListStatus(Id)
	ON DELETE CASCADE
)
GO

TRUNCATE TABLE WorkList
GO

INSERT INTO WorkList(WorkListName)
VALUES(N'Thực Tập Hè')

INSERT INTO WorkList(WorkListName)
VALUES(N'Đi Siêu Thị')

INSERT INTO WorkList(WorkListName)
VALUES(N'Đi Nhậu')
GO

CREATE TABLE WorkList_Employee(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdEmployee INT,
	IdWorkList INT,
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT WorkListEmployee_Employee
	FOREIGN KEY(IdEmployee)
	REFERENCES dbo.Employee(Id)
	ON DELETE CASCADE,
	CONSTRAINT WorkListEmployee_WorkList
	FOREIGN KEY(IdWorkList)
	REFERENCES dbo.WorkList(Id)
	ON DELETE CASCADE
)
GO

TRUNCATE TABLE WorkList_Employee
GO

INSERT INTO WorkList_Employee(IdEmployee, IdWorkList)
VALUES(3, 1)

INSERT INTO WorkList_Employee(IdEmployee, IdWorkList)
VALUES(3, 2)

INSERT INTO WorkList_Employee(IdEmployee, IdWorkList)
VALUES(3, 3)

INSERT INTO WorkList_Employee(IdEmployee, IdWorkList)
VALUES(4, 2)

INSERT INTO WorkList_Employee(IdEmployee, IdWorkList)
VALUES(4, 3)

INSERT INTO WorkList_Employee(IdEmployee, IdWorkList)
VALUES(5, 3)
GO

CREATE TABLE Work(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdWorkList INT,
	IdWorkStatus INT DEFAULT 1,
	WorkContent NVARCHAR(200),
	CONSTRAINT Work_WorkList
	FOREIGN KEY(IdWorkList)
	REFERENCES dbo.WorkList(Id)
	ON DELETE CASCADE,
	CONSTRAINT Work_WorkStatus
	FOREIGN KEY(IdWorkStatus)
	REFERENCES dbo.WorkStatus
	ON DELETE CASCADE
)
GO

TRUNCATE TABLE Work
GO

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(1, 2, N'Đi thực tập')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(1, 1, N'Viết báo cáo')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(1, 1, N'In báo cáo')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(2, 1, N'Mua trứng')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(2, 1, N'Mua rau')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(2, 2, N'Mua thịt')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(2, 3, N'Đổi nước')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(3, 1, N'Mua mồi')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(3, 1, N'Mua bia')

INSERT INTO Work(IdWorkList, IdWorkStatus, WorkContent)
VALUES(3, 1, N'Đi đón Phong')
GO

CREATE TABLE Work_Employee(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdEmployee INT,
	IdWork INT,
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT WorkEmployee_Employee
	FOREIGN KEY(IdEmployee)
	REFERENCES dbo.Employee(Id)
	ON DELETE CASCADE,
	CONSTRAINT WorkEmployee_Work
	FOREIGN KEY(IdWork)
	REFERENCES dbo.Work(Id)
	ON DELETE CASCADE
)
GO

TRUNCATE TABLE Work_Employee
GO

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 1)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 2)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 3)
GO

CREATE TABLE Comment(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	IdEmployee INT,
	IdWork INT,
	CommentContent NVARCHAR(200),
	DateCreated DATE DEFAULT GETDATE(),
	CONSTRAINT Comment_Employee
	FOREIGN KEY(IdEmployee)
	REFERENCES dbo.Employee(Id)
	ON DELETE CASCADE,
	CONSTRAINT Comment_Work
	FOREIGN KEY(IdWork)
	REFERENCES dbo.Work(Id)
	ON DELETE CASCADE
)
GO

TRUNCATE TABLE Comment
GO

INSERT INTO Comment(IdEmployee, IdWork, CommentContent)
VALUES(3, 1, N'Hay đó')

SELECT *
FROM Work

SELECT *
FROM Role

SELECT *
FROM Employee

SELECT *
FROM WorkStatus

SELECT *
FROM WorkListStatus

SELECT *
FROM WorkList

SELECT *
FROM Comment

SELECT *
FROM WorkList_Employee

SELECT *
FROM Work_Employee
GO
