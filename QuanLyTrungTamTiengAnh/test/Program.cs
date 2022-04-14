using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL.Entities;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentBLL = new StudentBLL();
            var student = new Student("Nguyen Phat Thuan", 
                                       DateTime.ParseExact("2000-03-06", "yyyy-dd-MM", null),
                                       "0949238339","45 Nguyen Cong Tru");
            studentBLL.unitOfWork.studentRepository.Add(student);
           // student.unitOfWork.studentRepository.GetAll();
        }
    }
}
