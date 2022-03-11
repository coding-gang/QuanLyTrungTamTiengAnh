USE [DatabaseTienganh]
GO
/****** Object:  UserDefinedFunction [dbo].[IsClassInBranch]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[IsClassInBranch](@studentId int, @idClass int) returns int
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
GO
/****** Object:  UserDefinedFunction [dbo].[IsEmployeesInBranch]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Function [dbo].[IsEmployeesInBranch](@empId int, @idCourse int) returns int
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
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[GradeID] [int] NOT NULL,
	[Room] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TimeToStudy] [datetime] NULL,
	[Cost] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Phone] [nchar](20) NOT NULL,
	[Qualification] [nvarchar](30) NULL,
	[Nation] [nvarchar](30) NULL,
	[Position] [nvarchar](30) NULL,
	[Salary] [int] NULL,
	[BranchID] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StartTime] [time](7) NULL,
	[StudyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Register]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Register](
	[ClassID] [int] NOT NULL,
	[StudentID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[Phone] [nchar](20) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[BranchID] [int] NULL,
	[FullName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_Salary]  DEFAULT ((0)) FOR [Salary]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Courses]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Employees]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Grades] FOREIGN KEY([GradeID])
REFERENCES [dbo].[Grades] ([ID])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Grades]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Branches]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Branches]
GO
ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_Classes] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Classes] ([ID])
GO
ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_Classes]
GO
ALTER TABLE [dbo].[Register]  WITH CHECK ADD  CONSTRAINT [FK_Register_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Register] CHECK CONSTRAINT [FK_Register_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Branches]
GO
/****** Object:  StoredProcedure [dbo].[Add_Classes]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Add_Classes] @courseId int, @employeeId int, @gradeId int,
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
GO
/****** Object:  StoredProcedure [dbo].[Add_Courses]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Add_Courses] @name nvarchar(50), @timeToStudy datetime,
							 @cost int, @branchId int	
as
INSERT INTO Courses(Name, TimeToStudy, Cost, BranchID)
VALUES (@name,@timeToStudy,@cost,@branchId)
GO
/****** Object:  StoredProcedure [dbo].[Add_Employees]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Add_Employees] @fullName nvarchar(50), @dob datetime, @phone nchar(20),
							   @qualification nvarchar(30), @nation nvarchar(30),
							   @position nvarchar(30), @salary int, @branchId int
as
   INSERT INTO Employees(FullName, DOB, Phone, Qualification, Nation, Position,  Salary, BranchID) 
VALUES (@fullName, @dob, @phone, @qualification, @nation, @position, @salary, @branchId)
GO
/****** Object:  StoredProcedure [dbo].[Add_Grades]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Add_Grades] @name nvarchar(50), @startTime time, @studyDate datetime
as
INSERT INTO Grades(Name, StartTime, StudyDate) VALUES (@name, @startTime, @studyDate)
GO
/****** Object:  StoredProcedure [dbo].[Add_Register]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  Create Procedure [dbo].[Add_Register] @classId int, @studentId int
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
GO
/****** Object:  StoredProcedure [dbo].[Add_Students]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Add_Students] @dob datetime, @phone nchar(20), @address nvarchar(150),
							  @branchId int, @fullName nvarchar(50)
as
INSERT INTO Students(DOB, Phone, Address, BranchID, FullName) 
VALUES (@dob,@phone,@address,@branchId,@fullName)
GO
/****** Object:  StoredProcedure [dbo].[CaHocCoHvHocNhieuNhat]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[CaHocCoHvHocNhieuNhat]
 as
  Select TOP 2 g.Name as 'CaHoc', COUNT(r.ClassID) SoDK
 From Classes cl, Register r,Grades g
 Where cl.ID = r.ClassID  and cl.GradeID = g.ID
 Group by  r.ClassID ,g.Name
 Order By SoDK DESC
GO
/****** Object:  StoredProcedure [dbo].[GvDayNhieuLopNhat]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[GvDayNhieuLopNhat] 
 as
 Select TOP 1 emp.FullName ,  COUNT(c.EmployeeID) Solop
 From Classes c, Employees emp
 Where c.EmployeeID =emp.ID
 Group by c.EmployeeID, emp.FullName
 Order by Solop DESC
GO
/****** Object:  StoredProcedure [dbo].[KhoaHocCoHvHocNhieuNhat]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[KhoaHocCoHvHocNhieuNhat]
 as
  Select TOP 1 c.Name, COUNT(r.ClassID) HocVien
 From Classes cl, Register r, Students s,Courses c
 Where cl.ID = r.ClassID and r.StudentID =s.ID and cl.CourseID =c.ID
 Group by r.ClassID,c.Name
 Order By HocVien DESC
GO
/****** Object:  StoredProcedure [dbo].[Print_Class]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   Create Procedure [dbo].[Print_Class]
   as
   Select cl.ID, c.Name , e.FullName as 'Giao vien' , g.Name,
		  g.StartTime,g.StudyDate,cl.Room,cl.StartDate
   from Classes cl, Courses c,Employees e,Grades g
   where cl.CourseID = c.ID and cl.EmployeeID = e.ID
         and cl.GradeID = g.ID
GO
/****** Object:  StoredProcedure [dbo].[Print_Courses]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Print_Courses]
    as 
    select c.ID, c.Name, c.TimeToStudy, c.Cost, b.Name 
	from Courses c, Branches b
	where c.BranchID = b.ID
GO
/****** Object:  StoredProcedure [dbo].[Print_DS_ByClass]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Print_DS_ByClass] @idclass int
 as
 Select emp.ID, emp.FullName, emp.DOB,emp.Phone,emp.Qualification,emp.Position,
       emp.Nation
 from Classes cl, Employees emp, Branches b 
 where cl.EmployeeID =emp.ID and emp.BranchID = b.ID and  cl.ID =@idclass
GO
/****** Object:  StoredProcedure [dbo].[Print_DS_Student_ByClass]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 Create Procedure [dbo].[Print_DS_Student_ByClass] @idClass int
 as
 Select s.FullName as 'StudentName',s.Address,s.DOB,s.Phone  
 from Classes cl , Register r, Students s
 where cl.ID = r.ClassID and r.StudentID =s.ID and cl.ID =@idClass
GO
/****** Object:  StoredProcedure [dbo].[Print_DS_Student_ByCourse]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Print_DS_Student_ByCourse] @idCourse int
 as
 Select s.FullName as 'StudentName',s.Address,s.DOB,s.Phone  
 from Classes cl , Register r, Students s , Courses c
 where cl.ID = r.ClassID and r.StudentID =s.ID and c.ID =cl.CourseID and c.ID =@idCourse
GO
/****** Object:  StoredProcedure [dbo].[Print_DSBill_ByStudent]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 Create Procedure [dbo].[Print_DSBill_ByStudent] @idStudent int
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
GO
/****** Object:  StoredProcedure [dbo].[Print_DSClass_ByGV]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Print_DSClass_ByGV] @idEmp int
 as
 Select cl.ID, c.Name, emp.FullName as 'Giao vien', g.Name,cl.Room,cl.StartDate
 from Classes cl , Courses c , Grades g,Employees emp
 where cl.CourseID =c.ID and cl.EmployeeID =emp.ID and cl.EmployeeID = @idEmp
       and cl.GradeID =g.ID
GO
/****** Object:  StoredProcedure [dbo].[Print_Employees]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  Create Procedure [dbo].[Print_Employees]
  as 
   select * from Employees
GO
/****** Object:  StoredProcedure [dbo].[Print_Grades]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Print_Grades]
  as
  Select * from Grades
GO
/****** Object:  StoredProcedure [dbo].[Print_Students]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Print_Students]
 as
 Select st.ID, st.FullName, st.DOB, st.Phone, st.Address, b.Name as 'name branch'
 from Students st , Branches b
 where st.BranchID = b.ID
GO
/****** Object:  StoredProcedure [dbo].[Update_Register]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create Procedure [dbo].[Update_Register] @classId int, @studentId int
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
GO
/****** Object:  StoredProcedure [dbo].[UpdateBranchForEmployee]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[UpdateBranchForEmployee] @empId int, @branchId int
as
  Update Employees
  SET BranchID =@branchId
  Where ID = @empId
GO
/****** Object:  StoredProcedure [dbo].[UpdateBranchForStudent]    Script Date: 3/12/2022 12:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[UpdateBranchForStudent] @studentId int, @branchId int
as
  Update Students
  SET BranchID =@branchId
  Where ID = @studentId
GO
