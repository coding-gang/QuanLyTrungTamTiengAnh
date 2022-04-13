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


