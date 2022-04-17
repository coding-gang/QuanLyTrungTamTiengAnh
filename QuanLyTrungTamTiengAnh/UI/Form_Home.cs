using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using Core.IConfiguration;
using Core.UnitOfWork;
using DAL.Entities;
using Dtos;
namespace UI
{
    public partial class frmHome : Form
    {
        private IUnitOfWork _unitOfWork  = new UnitOfWork();
        private RegisterBLL _registerBLL = null;
        private StudentBLL  _studentBLL  = null;
        private CoursesBLL  _coursesBLL  = null;
        private IDictionary<int, int> dictionaryClassCaseStudy =null;
        public frmHome()
        {
            InitializeComponent();
            _registerBLL = new RegisterBLL(_unitOfWork);
            _studentBLL = new StudentBLL(_unitOfWork);
            _coursesBLL = new CoursesBLL(_unitOfWork);
            
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadRegisters();
            LoadCourses();
        }
        private void LoadRegisters()
        {
           dtgDangky.DataSource = _registerBLL.unitOfWork.registerRepository.GetAll();
           dtgDangky.Columns["StudentId"].Visible = false;
            dtgDangky.Columns["ClassId"].Visible = false;
            dtgDangky.Columns["Id"].Visible = false;
        }

        private void LoadCourses()
        {
            cbbCourses.DisplayMember = "Lesson";
            cbbCourses.ValueMember = "Id";
            cbbCourses.DataSource =  _coursesBLL.unitOfWork.coursesRepository.GetAll();           
        }

        private void LoadStudents()
        {
           cbbHocvien.DataSource = _studentBLL.unitOfWork.studentRepository.GetAll().Reverse().ToList();
           cbbHocvien.DisplayMember = "FullName";
            cbbHocvien.ValueMember = "Id"; 
        }

        private void LoadCaseStudy(List<CaseStudys> listCaseStudy)
        {
            cbbCaHoc.DataSource = listCaseStudy;
            cbbCaHoc.DisplayMember = "Name";
            cbbCaHoc.ValueMember   = "Id";
        }
        private List<CaseStudys> InitCaseStudys(List<InfoToRegister> infoToRegisters)
        {
            var listCaseStudy = new List<CaseStudys>();
            dictionaryClassCaseStudy = new Dictionary<int,int>();
            foreach (var item in infoToRegisters)
            {
                if (!dictionaryClassCaseStudy.ContainsKey(item.InfoCaseStudy.Id))
                {
                    dictionaryClassCaseStudy.Add(item.InfoCaseStudy.Id, item.IdClass);
                }   
                listCaseStudy.Add(item.InfoCaseStudy);
            }
            return listCaseStudy;
        }

        private void cbbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            var courses = (Courses)cbbCourses.SelectedItem;
            tbCost.Text = FormatCurrency(courses.Cost);
            var idCourses = int.Parse(cbbCourses.SelectedValue.ToString());
            var infoRegisters = _registerBLL.unitOfWork.registerRepository.GetInfoToRegisters(idCourses);
            var listCaseStudy = InitCaseStudys(infoRegisters);
            LoadCaseStudy(listCaseStudy);
        }

        private string FormatCurrency(decimal money)
        {
            var cul = CultureInfo.GetCultureInfo("vi-VN");
            return money.ToString("#,##", cul.NumberFormat);
        }

        private void cbbCaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
           var caseStudy    = (CaseStudys)cbbCaHoc.SelectedItem;
           tbDateStudy.Text = caseStudy.DateStudy;
           tbStartTime.Text = caseStudy.StartTime;
        }

        private void AddStudent()
        {
            var student = new Student
            {
                FullName = txtFullName.Text.Trim(),
                Address = txtAdrress.Text.Trim(),
                Phone = txtPhoneNumber.Text.Trim(),
                DoB = dtpDateOfBirth.CalendarTodayDate
            };
           var isSucces = _studentBLL.unitOfWork.studentRepository.Add(student);
            if (isSucces)
            {
                Notify("Thêm học viên thành công!");
            }
            else
            {
                Notify("Thêm học viên thất bại");
            }
        }

        private void Notify(string message)
        {
            MessageBox.Show(message);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAdrress.Text) && 
                String.IsNullOrEmpty(txtFullName.Text) &&
                String.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                Notify("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                AddStudent();
                LoadStudents();
            }
        }

        private void AddRegister()
        {
            var isNoPayment = String.IsNullOrEmpty(tbMoney.Text);
            var caseStudyId = ((CaseStudys)cbbCaHoc.SelectedItem).Id;
            var classId = dictionaryClassCaseStudy[caseStudyId];
            var register = new Register
            {
                StudentId = (int)((Student)cbbHocvien.SelectedItem).Id,
                ClassId = classId,
                PaymentDate = DateTime.Now,
                Amount = isNoPayment ? 0 : decimal.Parse(tbMoney.Text),
                Status = !isNoPayment
            };
            var isRegister = _registerBLL.unitOfWork.registerRepository.Add(register);
            if (isRegister)
            {
                Notify("Đăng ký khóa học thành công!");
            }
            else
            {
                Notify("Đăng ký thất bại!");
            }
        }

        private void btnDangkydk_Click(object sender, EventArgs e)
        {
            AddRegister();
            LoadRegisters();
        }
    }
}
