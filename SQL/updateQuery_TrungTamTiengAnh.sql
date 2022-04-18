-- cqrs
-- git flow
-- facade
use DatabaseEnglishCenter
alter table Classes alter column teacher_id varchar(6) null;
 /*Chuyen lop cung chi nhanh hoac khac*/
  Create Procedure Update_Register @classId int, @studentId int
  as
  begin
     update Registers 
	 set class_id =@classId
	 where student_id =@studentId
  end
  exec Update_Register 9, 1
  select * from Students
  select * from Registers
  select * from Classes
  select * from Employees
   
   drop Procedure Update_Branch_Emp
   /*Chuyen GV  chi nhanh khac- GV*/
  Create Procedure Update_Branch_Emp @branchCurrentId int,@branchExchangeId int ,@EmpId varchar(6)
  as
  begin

   update Classes
   set teacher_id =null
   where branch_id =  @branchCurrentId and teacher_id = @EmpId  
   update Employees 
   set branch_id = @branchExchangeId
	where id = @EmpId
  end
  exec Update_Branch_Emp 2,1,'GV007'

   /*Phan bo giao vien - GV*/
   Create Procedure Update_ClassByTeachId @classId int,@EmpId varchar(6)
   as
   begin
   update Classes
   set teacher_id =@EmpId
   where id = @classId 
   end
   exec Update_ClassByTeachId 7,'GV003'

 /*them hoc vien */

 select * from Students
 create procedure Add_Student @fullname nvarchar(90), @dob date,
							  @phone varchar(15), @address nvarchar(100)
 as
 begin
  INSERT INTO Students(full_name, date_of_birth, phone, address) 
  VALUES (@fullname, @dob, @phone,@address)
 end
 exec Add_Student 'Nguyen Mau Tuan', '2000-03-06','0949238337', 'Phu Dong Thien Vuong' 
 
 create procedure Update_Student @id int, @fullname nvarchar(90), @dob date,
							  @phone varchar(15), @address nvarchar(100) 
 as
 begin
   Update Students
   SET full_name = @fullname, date_of_birth = @dob, phone= @phone, address = @address
   Where ID = @id
 end
 
 select * from Students
 exec Update_Student 17, 'Nguyen Mau Tuan', '2000-06-03','0949238337', 'Phu Dong Thien Vuong' 

 Create Procedure Add_Employees @fullName nvarchar(50), @dob datetime, @phone nchar(20),
							   @qualification nvarchar(30), @nation nvarchar(30),
							   @jobtitle nvarchar(30), @salary int, @branchId int
 as
 begin
   INSERT INTO Employees(branch_id,full_name,date_of_birth ,phone, qualification, nation,jobtitle,salary) 
   VALUES (@branchId,@fullName, @dob, @phone, @qualification, @nation, @jobtitle, @salary)
 end

Create Procedure Add_Courses @lessons nvarchar(50), @duration int,
							 @cost money	
as
INSERT INTO Courses(lessons, duration, cost)
VALUES (@lessons, @duration, @cost)

 
 create procedure Xuat_DS_HV_ByIdCourses (@idCourses int)
 as
 begin
 select st.id,st.full_name,st.date_of_birth,st.phone,st.address
 from Students st
 inner join(
 select student_id
 from Registers r
 inner join (
  Select id
 from Classes cl
 where cl.course_id = (select id from Courses where id = @idCourses)) cl
 on r.class_id = cl.id) r
 on r.student_id = st.id
 end
 
 exec Xuat_DS_HV_ByIdCourses 1
 

 create procedure Xuat_DS_HV_ByIdClass (@idClass int)
 as
 begin
 select st.id,st.full_name,st.date_of_birth,st.phone,st.address
 from Students st
 inner join(
 select student_id
 from Registers r
 inner join (
  Select id
 from Classes cl
 where cl.id = @idClass) cl
 on r.class_id = cl.id) r
 on r.student_id = st.id
 end

 exec Xuat_DS_HV_ByIdClass 9



 create procedure Xuat_DS_Lop_ByIdGV (@idGV int)
 as
 begin
 select *
 from Classes
 where teacher_id =@idGV
 end

  Create Procedure Xuat_DSBill_ByStudent @idStudent int
 as
 begin  
  select id,lessons,cost
  from
  Courses
  inner join 
  (select course_id
  from Classes cl
  inner join(
   select class_id 
  from Registers
  where student_id = @idStudent) r
  on r.class_id = cl.id) c
  on c.course_id =id
  end

  exec Xuat_DSBill_ByStudent 8

 Create Procedure GvDayNhieuLopNhat 
 as
 begin
 Select TOP 1 emp.full_name ,  COUNT(c.teacher_id) Solop
 From Classes c
 inner join  Employees emp 
 on c.teacher_id = emp.id
 Group by c.teacher_id, emp.full_name
 Order by Solop DESC
 end

 Create Procedure HvHocNhieuNhatLop
 as
begin
 Select TOP 1 s.full_name, COUNT(r.class_id) SoLop
 From Classes cl
 inner join Registers r 
 on  cl.ID = r.class_id
 inner join Students s
 on r.student_id =s.ID
 Group by s.full_name
 Order By SoLop DESC
end


 Create Procedure KhoaHocCoHvHocNhieuNhat
 as
 begin
 Select c.lessons, [So hoc sinh]
 from Courses c
 inner join(
 select TOP 1  course_id, COUNT(class_id) as 'So hoc sinh'  from Registers
  inner join Classes cl on cl.id = class_id
  Group by  course_id
  Order by  [So hoc sinh] DESC
) cou on cou.course_id = c.id
 end

 EXEC KhoaHocCoHvHocNhieuNhat

  Create Procedure CaHocCoLopHocNhieuNhat
  as
  begin
  Select *
  from Classes cl
  inner join (
   select TOP 1 cl.id , COUNT(class_id) as 'So hoc sinh'  from Registers
  inner join Classes cl on cl.id = class_id
  Group by  cl.id
  Order by  [So hoc sinh] DESC) r 
  on r.id =cl.id
  end

  EXEC CaHocCoLopHocNhieuNhat

  create procedure Add_Employess @id nvarchar(6), @branch_id int,@full_name nvarchar(50),@dob datetime,
                                 @phone varchar(15), @qualification nvarchar(30),
								 @nation nvarchar(30), @jobtitle nvarchar(30),
								 @salary int
  as
  begin
  INSERT INTO Employees(id, branch_id, full_name, date_of_birth, phone, qualification, nation, jobtitle, salary)
  VALUES (@id, @branch_id,@full_name,@dob,@phone,@qualification,@nation,@jobtitle,@salary)
  end

  create procedure GvChuaDuocPhanCong
  as
  begin
 Select *
 from Employees
 where full_name not in (Select full_name
 From Classes c, Employees emp 
 Where c.teacher_id =emp.ID)
 end

 exec GvChuaDuocPhanCong