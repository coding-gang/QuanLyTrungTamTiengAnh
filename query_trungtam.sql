INSERT INTO Branches(Name) VALUES (N'Chi nhánh Phù Đổng Thiên Vương')
INSERT INTO Branches(Name) VALUES (N'Chi nhánh Quang Trung')
SELECT * FROM Branches

--ALTER TABLE Courses
--ALTER COLUMN TimeToStudy datetime;

INSERT INTO Courses(Name, TimeToStudy, Cost, BranchID) VALUES (N'IELTS cơ bản', '2022-3-11', 500000, 1)
INSERT INTO Courses(Name, TimeToStudy, Cost, BranchID) VALUES (N'IELTS nâng cao', '2022-3-11', 500000, 1)
SELECT * FROM Courses

--ALTER TABLE Employees
--ALTER COLUMN Position nvarchar(30);

INSERT INTO Employees(FullName, DOB, Phone, Qualification, Nation, Position,  Salary, BranchID) 
VALUES (N'Nguyễn Xuân Nam', '1993-3-11', '0912384732', N'Đại học', N'Việt Nam', N'Giáo viên', 300000, 1)
INSERT INTO Employees(FullName, DOB, Phone, Qualification, Nation, Position,  Salary, BranchID) 
VALUES (N'Trần Như Ngọc', '1995-3-11', '0912332442', N'Cao đẳng', N'Việt Nam', N'Giáo viên', 300000, 2)
SELECT * FROM Employees


--ALTER TABLE Grades
--ALTER COLUMN StartTime time;
INSERT INTO Grades(Name, StartTime, StudyDate) VALUES (N'Ca 1', '7:00', '2022-3-15')
INSERT INTO Grades(Name, StartTime, StudyDate) VALUES (N'Ca 2', '8:00', '2022-3-10')
INSERT INTO Grades(Name, StartTime, StudyDate) VALUES (N'Ca 3', '6:00', '2022-3-12')
SELECT * FROM Grades

INSERT INTO Classes(CourseID, EmployeeID, GradeID, Room, StartDate) VALUES (2, 1, 1, 5, '2022-3-11')
INSERT INTO Classes(CourseID, EmployeeID, GradeID, Room, StartDate) VALUES (3, 1, 1, 2, '2022-3-11')



--ALTER TABLE Students
--ADD FullName nvarchar(50);
INSERT INTO Students(DOB, Phone, Address, BranchID, FullName) 
VALUES ('2015-3-23', '0912384374', N'12 Bùi Thị Xuân', 1, N'Đào Siêu')
INSERT INTO Students(DOB, Phone, Address, BranchID, FullName) 
VALUES ('2011-3-3', '0912383214', N'15 Nguyễn Chí Thanh', 1, N'Văn Tuân')


INSERT INTO Register(ClassID, StudentID) VALUES (2, 1)
INSERT INTO Register(ClassID, StudentID) VALUES (2, 2)
SELECT * FROM Register


SELECT * FROM Branches
SELECT * FROM Courses
SELECT * FROM Employees
SELECT * FROM Classes
SELECT * FROM Students
SELECT * FROM Grades
SELECT * FROM Register