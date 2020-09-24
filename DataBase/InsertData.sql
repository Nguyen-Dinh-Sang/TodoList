USE TodoListDB
GO

--Quyền
INSERT INTO Role(Role)
VALUES(N'Giám Đôc')

INSERT INTO Role(Role)
VALUES(N'Nhân Viên')
GO

--Nhân viên
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

--Trạng thái công việc
INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Cần Làm')

INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Đang Làm')

INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Đã Hoàn Thành')

INSERT INTO WorkStatus(WorkStatus)
VALUES(N'Việc Trễ Hạn')
GO

--Trạng thái danh sách công việc
INSERT INTO WorkListStatus(WorkListStatus)
VALUES('Public')

INSERT INTO WorkListStatus(WorkListStatus)
VALUES('Private')
GO

--Danh sách công việc
INSERT INTO WorkList(WorkListName)
VALUES(N'Thực Tập Hè')

INSERT INTO WorkList(WorkListName)
VALUES(N'Đi Siêu Thị')

INSERT INTO WorkList(WorkListName)
VALUES(N'Đi Nhậu')
GO

--Danh sách công việc và nhân viên
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

--Công việc
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

--Công việc và nhân viên
INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 1)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 2)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 3)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 4)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 5)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 6)

INSERT INTO Work_Employee(IdEmployee, IdWork)
VALUES(3, 7)
GO

--Bình luận
INSERT INTO Comment(IdEmployee, IdWork, CommentContent)
VALUES(3, 1, N'Hay đó')

--Kiểm tra
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
FROM WorkList_Employee

SELECT *
FROM Work

SELECT *
FROM Work_Employee
GO

SELECT *
FROM Comment
GO