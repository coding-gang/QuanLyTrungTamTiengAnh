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

INSERT INTO Classes(CourseID, EmployeeID, GradeID, Room, StartDate) VALUES (1, 1, 1, 5, '2022-3-11')
INSERT INTO Classes(CourseID, EmployeeID, GradeID, Room, StartDate) VALUES (2, 1, 1, 2, '2022-3-11')



--ALTER TABLE Students
--ADD FullName nvarchar(50);
INSERT INTO Students(DOB, Phone, Address, BranchID, FullName) 
VALUES ('2015-3-23', '0912384374', N'12 Bùi Thị Xuân', 1, N'Đào Siêu')
INSERT INTO Students(DOB, Phone, Address, BranchID, FullName) 
VALUES ('2011-3-3', '0912383214', N'15 Nguyễn Chí Thanh', 1, N'Văn Tuân')


INSERT INTO Register(ClassID, StudentID) VALUES (1, 1)
INSERT INTO Register(ClassID, StudentID) VALUES (1, 2)
SELECT * FROM Register


SELECT * FROM Branches
SELECT * FROM Courses
SELECT * FROM Employees
SELECT * FROM Classes
SELECT * FROM Students
SELECT * FROM Grades
SELECT * FROM Register


Create Procedure Add_Employees @fullName nvarchar(50), @dob datetime, @phone nchar(20),
							   @qualification nvarchar(30), @nation nvarchar(30),
							   @position nvarchar(30), @salary int, @branchId int
as
   INSERT INTO Employees(FullName, DOB, Phone, Qualification, Nation, Position,  Salary, BranchID) 
VALUES (@fullName, @dob, @phone, @qualification, @nation, @position, @salary, @branchId)
go;

EXEC Add_Employees N'Nguyen Phat Trien', '1999-3-11', '0912332444', N'Cao đẳng', N'Việt Nam', N'Giáo viên', 400000, 2

Create Procedure Add_Students @dob datetime, @phone nchar(20), @address nvarchar(150),
							  @branchId int, @fullName nvarchar(50)
as
INSERT INTO Students(DOB, Phone, Address, BranchID, FullName) 
VALUES (@dob,@phone,@address,@branchId,@fullName)

EXEC Add_Students '2000-3-2', '0912384371', N'21 Phu Dong Thien Vuong', 2, N'Mau Tuan'

Create Procedure Add_Courses @name nvarchar(50), @timeToStudy datetime,
							 @cost int, @branchId int	
as
INSERT INTO Courses(Name, TimeToStudy, Cost, BranchID)
VALUES (@name,@timeToStudy,@cost,@branchId)

EXEC Add_Courses N'TOEIC cơ bản', '2022-3-11', 300000, 1
EXEC Add_Courses N'TOEIC nang cao', '2022-3-11', 300000, 2
Create Procedure Add_Grades @name nvarchar(50), @startTime time, @studyDate datetime
as
INSERT INTO Grades(Name, StartTime, StudyDate) VALUES (@name, @startTime, @studyDate)

EXEC Add_Grades N'Ca 4', '8:00', '2022-4-10'


  
  /*In DS Nhan Vien*/
  Create Procedure Print_Employees
  as 
  select * from Employees

  EXEC Print_Employees
  /*In DS khoa hoc*/
    Create Procedure Print_Courses
    as 
    select c.ID, c.Name, c.TimeToStudy, c.Cost, b.Name 
	from Courses c, Branches b
	where c.BranchID = b.ID

  EXEC Print_Courses

  /*In danh sach ca hoc*/
  Create Procedure Print_Grades
  as
  Select * from Grades

  EXEC Print_Grades


   /*In DS Lop hoc*/
   Create Procedure Print_Class
   as
   Select cl.ID, c.Name , e.FullName as 'Giao vien' , g.Name,
		  g.StartTime,g.StudyDate,cl.Room,cl.StartDate
   from Classes cl, Courses c,Employees e,Grades g
   where cl.CourseID = c.ID and cl.EmployeeID = e.ID
         and cl.GradeID = g.ID

EXEC Print_Class

 /*In DS Hoc vien*/
 Create Procedure Print_Students
 as
 Select st.ID, st.FullName, st.DOB, st.Phone, st.Address, b.Name as 'name branch'
 from Students st , Branches b
 where st.BranchID = b.ID

 EXEC Print_Students

 
 /*Ham kiem tra lop ton tai trong chi nhanh*/
Create Function IsClassInBranch(@studentId int, @idClass int) returns int
as
Begin
              DEClARE @kq int;
              DECLARE @idBranch int;
			  DECLARE @idCourse int;
			  SET @idBranch = (select st.BranchID as 'IdBranch' from Students st where st.ID = @studentId)
			  SET @idCourse = (select cl.CourseID as 'IdCourse' from Classes cl where cl.ID = @idClass ) 
			Begin
			 if exists (select * from  Courses c 
	                    where  c.ID = @idCourse and c.BranchID =@idBranch)
                 SET @kq = 1
			  else
			     SET @kq = 0  
			End	 
            return @kq   
End
/*Dang ly lop cho hoc vien*/
drop Procedure Add_Register

  Create Procedure Add_Register @classId int, @studentId int
  as
  begin
     DECLARE @isValid int;
	 SET @isValid = dbo.IsClassInBranch(@studentId,@classId)
	 if(@isValid = 1)
	  begin
	       INSERT INTO Register(ClassID, StudentID) VALUES (@classId,@studentId)
	       print 'Dang ky thanh cong'
	  end
     else
	       print 'Dang Ky that bai'
  end

  EXEC Add_Register 6,3

  /*Chuyen lop cung chi nhanh hoac khac*/
  Create Procedure Update_Register @classId int, @studentId int
  as
  begin
     DECLARE @isValid int;
	 SET @isValid = dbo.IsClassInBranch(@studentId,@classId)
	 if(@isValid = 1)
	  begin
	       UPDATE Register
		   SET ClassID = @classId
		   where StudentID =@studentId
	       print 'Chuyen lop thanh cong'
	  end
     else
	       print 'Chuyen lop that bai'
  end

  EXEC Update_Register 5,3

  /* Cap nhat chi nhanh cho hoc vien*/
Create Procedure UpdateBranchForStudent @studentId int, @branchId int
as
  Update Students
  SET BranchID =@branchId
  Where ID = @studentId

  /* Cap nhat chi nhanh cho nhan vien*/
Create Procedure UpdateBranchForEmployee @empId int, @branchId int
as
  Update Employees
  SET BranchID =@branchId
  Where ID = @empId
  /*Ham kiem tra nhan vien thuoc Chi nhanh*/
Create Function IsEmployeesInBranch(@empId int, @idCourse int) returns int
as
Begin
              DEClARE @kq int;
              DECLARE @idBranch int;
			  SET @idBranch = (select emp.BranchID as 'IdBranch' from Employees emp where emp.ID = @empId)
			Begin
			 if exists (select * 
			            from Courses c where c.ID = @idCourse and c.BranchID =@idBranch)
                 SET @kq = 1
			  else
			     SET @kq = 0  
			End	 
            return @kq   
End
drop Procedure Add_Classes
/*Dang ky lop cho giao vien */
Create Procedure Add_Classes @courseId int, @employeeId int, @gradeId int,
						     @room int, @startDate datetime
as
BEGIN
     DECLARE @isValid int;
	 set @isValid = dbo.IsEmployeesInBranch(@employeeId,@courseId)
	 if(@isValid = 1)
	 begin
	  INSERT INTO Classes(CourseID, EmployeeID, GradeID, Room, StartDate) 
	  VALUES (@courseId,@employeeId,@gradeId,@room,@startDate)
     print 'Dang ky lop cho giao vien thanh cong!'
     end
	 else
	 print 'Dang ky lop cho giao vien that bai'
   
END
 /* 1, 1, 1, 5, '2022-3-11' */
   
 EXEC Add_Classes 1,2,4,3,'2022-3-11'
 EXEC Add_Classes 4,3,4,1,'2022-3-11'
 EXEC Add_Classes 3,1,4,2,'2022-3-11'
 
 /*In danh sach giao vien theo lop */
 Create Procedure Print_DS_ByClass @idclass int
 as
 Select emp.ID, emp.FullName, emp.DOB,emp.Phone,emp.Qualification,emp.Position,
       emp.Nation
 from Classes cl, Employees emp, Branches b 
 where cl.EmployeeID =emp.ID and emp.BranchID = b.ID and  cl.ID =@idclass

 EXEC Print_DS_ByClass 6


  /*In danh sach cac lop theo giao vien*/
 Create Procedure Print_DSClass_ByGV @idEmp int
 as
 Select cl.ID, c.Name, emp.FullName as 'Giao vien', g.Name,cl.Room,cl.StartDate
 from Classes cl , Courses c , Grades g,Employees emp
 where cl.CourseID =c.ID and cl.EmployeeID =emp.ID and cl.EmployeeID = @idEmp
       and cl.GradeID =g.ID

 EXEC Print_DSClass_ByGV 1

   /*In danh sach cac hoc vien theo lop*/
 Create Procedure Print_DS_Student_ByClass @idClass int
 as
 Select s.FullName as 'StudentName',s.Address,s.DOB,s.Phone  
 from Classes cl , Register r, Students s
 where cl.ID = r.ClassID and r.StudentID =s.ID and cl.ID =@idClass

 EXEC Print_DS_Student_ByClass 1

  /*In danh sach cac hoc vien theo khoa hoc*/
  drop Procedure Print_DS_Student_ByCourse
 Create Procedure Print_DS_Student_ByCourse @idCourse int
 as
 Select s.FullName as 'StudentName',s.Address,s.DOB,s.Phone  
 from Classes cl , Register r, Students s , Courses c
 where cl.ID = r.ClassID and r.StudentID =s.ID and c.ID =cl.CourseID and c.ID =@idCourse
 select * from Courses
 EXEC Print_DS_Student_ByCourse 4

 /*In DS khoa hoc cua hoc vien kem theo bien lai*/
 drop Procedure Print_DSBill_ByStudent

 Create Procedure Print_DSBill_ByStudent @idStudent int
 as
  Select c.ID, c.Name,c.Cost
 from Students s , Register r , Classes cl, Courses c
 where s.ID = r.StudentID and r.ClassID =cl.ID and cl.CourseID = c.ID
       and s.ID = @idStudent
 Group by c.ID , c.Name,c.Cost

 Select SUM(c.Cost) as 'hoc phi'
 from Students s , Register r , Classes cl, Courses c
 where s.ID = r.StudentID and r.ClassID =cl.ID and cl.CourseID = c.ID
       and s.ID = @idStudent
 Group by  r.StudentID

 EXEC Print_DSBill_ByStudent 2


 /*giao vien day nhieu nhat lop*/

 Create Procedure GvDayNhieuLopNhat 
 as
 Select TOP 1 emp.FullName ,  COUNT(c.EmployeeID) Solop
 From Classes c, Employees emp
 Where c.EmployeeID =emp.ID
 Group by c.EmployeeID, emp.FullName
 Order by Solop DESC 
 
 EXEC GvDayNhieuLopNhat

 /*Hoc vien hoc nhieu nhat lop*/
 Create Procedure HvHocNhieuNhatLop
 as
 Select TOP 1 s.FullName, COUNT(r.ClassID) SoLop
 From Classes cl, Register r, Students s
 Where cl.ID = r.ClassID and r.StudentID =s.ID
 Group by s.FullName
 Order By SoLop DESC

 /*Khoa hoc co nhieu hoc vien theo hoc nhat*/
 drop Procedure KhoaHocCoHvHocNhieuNhat
 Create Procedure KhoaHocCoHvHocNhieuNhat
 as
  Select TOP 1 c.Name, COUNT(r.ClassID) HocVien
 From Classes cl, Register r, Students s,Courses c
 Where cl.ID = r.ClassID and r.StudentID =s.ID and cl.CourseID =c.ID
 Group by r.ClassID,c.Name
 Order By HocVien DESC
 
  /*Ca hoc co nhieu hoc vien theo hoc nhat*/
  drop Procedure CaHocCoHvHocNhieuNhat
 Create Procedure CaHocCoHvHocNhieuNhat
 as
  Select TOP 2 g.Name as 'CaHoc', COUNT(r.ClassID) SoDK
 From Classes cl, Register r,Grades g
 Where cl.ID = r.ClassID  and cl.GradeID = g.ID
 Group by  r.ClassID ,g.Name
 Order By SoDK DESC

 EXEC CaHocCoHvHocNhieuNhat

 /*Giao vien chua duoc phan day*/
 Create Procedure TimGiaoVienChuaDuocPhanDay
 as
 Select *
 from Employees
where FullName not in (Select FullName
 From Classes c, Employees emp 
 Where c.EmployeeID =emp.ID)

