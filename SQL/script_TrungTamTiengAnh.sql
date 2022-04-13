create Database DatabaseEnglishCenter

USE DatabaseEnglishCenter
GO

-- Table: Student
CREATE TABLE Students (
   id int IDENTITY(1,1)  NOT NULL,
   full_name nvarchar(90)  NOT NULL,
   date_of_birth date,
   phone varchar(15)  NOT NULL,
   address nvarchar(100)  NOT NULL,
   CONSTRAINT Students_pk PRIMARY KEY  (id)
);
select * from Students

-- Table: Branch
CREATE TABLE Branches (
   id int IDENTITY(1,1) NOT NULL,
   name nvarchar(90)  NOT NULL,
   address nvarchar(100)  NOT NULL,
   CONSTRAINT Branches_pk PRIMARY KEY  (id)
);

-- Table: Employee
CREATE TABLE Employees (
   id varchar(6)  NOT NULL,
   branch_id int  NOT NULL,
   full_name nvarchar(50)  NOT NULL,
   date_of_birth datetime  NOT NULL,
   phone varchar(15)  NOT NULL,
   qualification nvarchar(30),
   nation nvarchar(30)  NOT NULL,
   jobtitle nvarchar(30)  NOT NULL,
   salary int  NOT NULL,
   CONSTRAINT Employees_pk PRIMARY KEY  (id)
);

-- Table: Class
CREATE TABLE Classes (
   id int IDENTITY(1,1) NOT NULL,
   course_id int  NOT NULL,
   case_id int  NOT NULL,
   teacher_id varchar(6) NULL,
   branch_id int  NOT NULL,
   room int  NOT NULL,
   start_date date  NOT NULL,
   time_per_week int  NOT NULL,
   active bit  NOT NULL,
   CONSTRAINT Classes_pk PRIMARY KEY  (id)
);

-- Table: Register
CREATE TABLE Registers (
   id int IDENTITY(1,1) NOT NULL,
   student_id int  NOT NULL,
   class_id int  NOT NULL,
   payment_date datetime  NOT NULL,
   amount money  NOT NULL,
   status bit  NOT NULL,
   CONSTRAINT Registers_pk PRIMARY KEY  (id)
);

-- Table: Course
CREATE TABLE Courses (
   id int IDENTITY(1,1) NOT NULL,
   lessons nvarchar(500)  NOT NULL,
   duration int  NOT NULL,
   cost money  NOT NULL,
   CONSTRAINT Courses_pk PRIMARY KEY  (id)
);

-- Table: Case
CREATE TABLE Case_study (
   id int IDENTITY(1,1) NOT NULL,
   name varchar(50)  NOT NULL,
   start_time varchar(50)  NOT NULL,
   date_study nvarchar(50)  NOT NULL,
   CONSTRAINT Group_Day_pk PRIMARY KEY  (id)
);


-- foreign keys
-- Reference: Payments_Students (table: Registers)
ALTER TABLE Registers ADD CONSTRAINT Payments_Students
   FOREIGN KEY (student_id)
   REFERENCES Students (id);

-- Reference: Payments_Classes (table: Registers)
ALTER TABLE Registers ADD CONSTRAINT Payments_Classes
   FOREIGN KEY (class_id)
   REFERENCES Classes (id);

-- Reference: Classes_Courses (table: Classes)
ALTER TABLE Classes ADD CONSTRAINT Classes_Courses
   FOREIGN KEY (course_id)
   REFERENCES Courses (id);

-- Reference: Classes_Case_study (table: Classes)
ALTER TABLE Classes ADD CONSTRAINT Classes_Case_study
   FOREIGN KEY (case_id)
   REFERENCES Case_study (id);

-- Reference: Employees_Branches (table: Employees)
ALTER TABLE Employees ADD CONSTRAINT Employees_Branches
   FOREIGN KEY (branch_id)
   REFERENCES Branches (id);

-- Reference: Classes_Branches (table: Classes)
ALTER TABLE Classes ADD CONSTRAINT Classes_Branches
   FOREIGN KEY (branch_id)
   REFERENCES Branches (id);

-- Reference: Classes_Employees (table: Classes)
ALTER TABLE Classes ADD CONSTRAINT Classes_Employees
   FOREIGN KEY (teacher_id)
   REFERENCES Employees (id);

-- Branch
INSERT INTO Branches(name, address) VALUES (N'Chi nhánh 1', N'67/8 Phù Đổng Thiên Vương')
INSERT INTO Branches(name, address) VALUES (N'Chi nhánh 2', N'15 Quang Trung')
SELECT * FROM Branches

-- Student
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Đào Tuấn Siêu', '2010-3-23', '0912344374', N'12 Bùi Thị Xuân')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Văn Minh Tuân', '2011-3-3', '0912383214', N'6 Nguyễn Chí Thanh')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Nhất Hữu Nam', '2013-3-23', '0917678374', N'44/3 Quang Trung')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Đào Minh Nam', '2012-3-3', '0923183214', N'55/1 Nguyễn Đình Chiểu')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Ngọc Hữu Minh', '2011-3-23', '0342384374', N'16 Cô Giang')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Lam Siêu Huy', '2013-3-3', '0793483214', N'32 Yết Kiêu')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Văn Nhất Trung', '2014-3-23', '0888384374', N'15/5 Phù Đổng Thiên Vương')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Nguyễn Thị Mai', '2015-3-3', '0381723214', N'64 Nguyễn Chí Thanh')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Vui Văn Đến', '2012-3-23', '0871284374', N'13 Bùi Thị Xuân')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Trần Kim Sương', '2011-3-3', '0916433214', N'47 Trần Phú')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Hữu Đào Long', '2016-3-23', '0916907374', N'56 Nguyễn Quốc Toản')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Nguyễn Trần Khoa', '2013-3-3', '0830383214', N'12 Kiến Con')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Trần Đem Tới', '2011-3-23', '0938384374', N'79 Trần Quốc Toản')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Vui Ca Nhất', '2014-3-3', '0397383214', N'12 Võ Trường Toản')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Chế Nguyệt Mai', '2011-3-23', '0395384374', N'75 Phan Đình Phùng')
INSERT INTO Students(full_name, date_of_birth, phone, address) 
VALUES (N'Đoàn Minh Minh', '2012-3-3', '0364383214', N'76 Nguyễn Công Trứ')

select * from Students
-- Course
INSERT INTO Courses(lessons, duration, cost) VALUES (N'IELTS cơ bản', 60, 700000)
INSERT INTO Courses(lessons, duration, cost) VALUES (N'IELTS nâng cao', 90, 1200000)
INSERT INTO Courses(lessons, duration, cost) VALUES (N'TOEIC cơ bản', 60, 500000)
INSERT INTO Courses(lessons, duration, cost) VALUES (N'TOEIC nâng cao', 90, 1000000)
select * from Case_study
-- Case *********************

INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 1', '7:00', N'Thứ 2 - Thứ 4')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 1', '7:00', N'Thứ 3 - Thứ 5')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 1', '7:00', N'Thứ 4 - Thứ 6')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 1', '7:00', N'Thứ 5 - Thứ 7')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 1', '7:00', N'Thứ 2 - Thứ 6')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 1', '7:00', N'Thứ 3 - Thứ 7')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 2', '15:00', N'Thứ 2 - Thứ 4')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 2', '15:00', N'Thứ 3 - Thứ 5')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 2', '15:00', N'Thứ 4 - Thứ 6')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 2', '15:00', N'Thứ 5 - Thứ 7')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 2', '15:00', N'Thứ 2 - Thứ 6')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 2', '15:00', N'Thứ 3 - Thứ 7')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 3', '19:00', N'Thứ 2 - Thứ 4')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 3', '19:00', N'Thứ 3 - Thứ 5')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 3', '19:00', N'Thứ 4 - Thứ 6')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 3', '19:00', N'Thứ 5 - Thứ 7')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 3', '19:00', N'Thứ 2 - Thứ 6')
INSERT INTO Case_study(Name, start_time, date_study) VALUES ('Ca 3', '19:00', N'Thứ 3 - Thứ 7')

-- Employee
select * from Employees
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV001', 1, N'Nguyễn Xuân Nam', '1993-3-11', '0912384732', N'Đại học', N'Việt Nam', N'Giáo viên', 4200000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV002', 1, N'Trần Như Ngọc', '1995-3-11', '0912332442', N'Cao đẳng', N'Việt Nam', N'Giáo viên', 3700000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV003', 1, N'Phan Thu Anh', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 3000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV004', 1, N'Phạm Thị Ngân', '1997-8-23', '0439853485', N'Đại học', N'Việt Nam', N'Giáo viên', 4000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV005', 2, N'Trần Thanh Nhàn', '2000-8-23', '0934238743', N'Đại học', N'Việt Nam', N'Giáo viên', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV006', 2, N'Phan Nguyễn Huệ', '2000-8-23', '0916758493', N'Cao Đẳng', N'Việt Nam', N'Giáo viên', 3000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV001', 1, N'Nguyễn Đặng Minh', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Kế toán', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV002', 1, N'Vũ Thanh Hải', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Lễ tân', 7000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV007', 2, N'Phan Thái Tài', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 4000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV008', 2, N'Trần Minh Phương', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV009', 2, N'Nguyễn Thị Bảy', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV003', 1, N'Nguyễn Bảo Khánh', '2000-8-23', '0916758493', N'Cao đẳng', N'Việt Nam', N'Bảo vệ', 3000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV004', 1, N'Phạm Thanh Hoàng', '2000-8-23', '0916758493', N'', N'Việt Nam', N'Bảo vệ', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV005', 1, N'Phan Thanh Thanh', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Bảo vệ', 7000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV014', 1, N'Phạm Thị Trang', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV006', 2, N'Trần Thanh Quyết', '2000-8-23', '0916758493', N'Cao đẳng', N'Việt Nam', N'Kế toán', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV007', 2, N'Phan Nguyễn Phương', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Lễ tân', 7000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV010', 1, N'Nguyễn Nhật Đăng', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV011', 1, N'Vũ Thanh Thúy', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 7000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV008', 2, N'Phan Thái Thịnh', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Kế toán', 3000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV009', 2, N'Trần Minh Quân', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Bảo vệ', 4000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('NV010', 2, N'Nguyễn Thị Hoa', '2000-8-23', '0916758493', N'', N'Việt Nam', N'Bảo vệ', 4000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV012', 2, N'Nguyễn Bảo Ngọc', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 5000000)
INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
VALUES ('GV013', 2, N'Phạm Thanh Thủy', '2000-8-23', '0916758493', N'Đại học', N'Việt Nam', N'Giáo viên', 5000000)

SELECT * FROM Employees
select * from Classes

select * from Branches
-- Class
INSERT INTO Classes(course_id, case_id, teacher_id, branch_id, room, start_date, time_per_week, active)
VALUES (1,18,'GV001',1,5,'2022-3-11',4,1)
INSERT INTO Classes(course_id, case_id, teacher_id, branch_id, room, start_date, time_per_week, active)
VALUES (1,17,'GV002',1,6,'2022-3-11',4,1)

INSERT INTO Classes(course_id, case_id, teacher_id, branch_id, room, start_date, time_per_week, active)
VALUES (1,16,'GV005',2,6,'2022-3-11',4,1)

select * from Case_study


Alter Table Employees alter column full_name nvarchar(50);
-- Register

select * from Registers
INSERT INTO Registers(student_id, class_id, payment_date, amount, status) VALUES (1, 4, '2022-3-5', 700000, 1)
INSERT INTO Registers(student_id, class_id, payment_date, amount, status) VALUES (2, 5, '2022-3-5', 700000, 1)
INSERT INTO Registers(student_id, class_id, payment_date, amount, status) VALUES (3, 1, '2022-3-5', 700000, 1)
INSERT INTO Registers(student_id, class_id, payment_date, amount, status) VALUES (5, 4, '2022-3-5', 700000, 1)
INSERT INTO Registers(student_id, class_id, payment_date, amount, status) VALUES (6, 4, '2022-3-5', 700000, 1)
INSERT INTO Registers(student_id, class_id, payment_date, amount, status) VALUES (7, 2, '2022-3-5', 700000, 1)
INSERT INTO Registers(student_id, class_id, payment_date, amount, status) VALUES (8, 3, '2022-3-5', 700000, 1)

select * from Registers
