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
using Core.UnitOfWork;
using Core.IConfiguration;
using BLL;
using Dtos;
using DAL.Entities;

namespace UI
{
    public partial class frmHome : Form
    {
        private IUnitOfWork _unitOfWork  = new UnitOfWork();
        private RegisterBLL _registerBLL = null;
        private StudentBLL  _studentBLL  = null;
        private CoursesBLL  _coursesBLL  = null;
        private ClassStudyBLL _classBll  = null;
        private CaseStudyBLL _caseStudyBLL = null;
        private EmployeeBLL _employeeBLL = null;
        private IDictionary<int, int> dictionaryClassCaseStudy =null;
        private List<DetailRegister> detailRegisters = null;
        private FormUpdateClassStudent frmUpdate = null;
        private string[] branchs = new string[] { "Chi nhánh 1", "Chi nhánh 2" };
        private string[] TimeDayClass = new string[] { "7:00", "15:00","19:00" };
        private string[] DateStudy = new string[] { "Thứ 2 - Thứ 4", "Thứ 3 - Thứ 4","Thứ 3 - Thứ 5",
                                                    "Thứ 3 - Thứ 6","Thứ 3 - Thứ 7","Thứ 2 - Thứ 5",
                                                    "Thứ 2 - Thứ 6","Thứ 2 - Thứ 7","Thứ 2 - Thứ 3",
                                                    "Thứ 4 - Thứ 6","Thứ 4 - Thứ 7","Thứ 4 - Thứ 4",
                                                    "Thứ 5 - Thứ 6","Thứ 5 - Thứ 7","Thứ 6 - Thứ 7",
                                                    "Thứ 2 - Thứ 3 - Thứ 4","Thứ 3 - Thứ 5 - Thứ 7","Thứ 2 - Thứ 6 - Thứ 7",
                                                    "Thứ 4 - Thứ 6 - Thứ 7","Thứ 4 - Thứ 5 - Thứ 7","Thứ 5 - Thứ 6 - Thứ 7","Thứ 2 - Thứ 4 - Thứ 6"};
        private int? IdCaseStudy { get; set; }
        public frmHome()
        {
            InitializeComponent();
            _registerBLL  = new RegisterBLL(_unitOfWork);
            _studentBLL   = new StudentBLL(_unitOfWork);
            _coursesBLL   = new CoursesBLL(_unitOfWork);
            _classBll     = new ClassStudyBLL(_unitOfWork);
            _caseStudyBLL = new CaseStudyBLL(_unitOfWork);
            _employeeBLL = new EmployeeBLL(_unitOfWork);
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadRegisters();
            LoadCourses();
            LoadClassStudy();
            LoadLopCourses();
            LoadCaseStudy();
            LoadBranch();
            LoadEmployees();
            LoadTimeDayClass();
            LoadDateStudy();
        }

        private void LoadTimeDayClass()
        {
            cbbTimeDate.DataSource = TimeDayClass;
        }

        private void LoadBranch()
        {
            cbbBranch.DataSource = branchs;
        }

        private void LoadDateStudy()
        {
            cbbDate.DataSource = DateStudy;
        }
        private void LoadEmployees()
        {
            cbbLopHocEmp.DisplayMember = "FullName";
            cbbLopHocEmp.ValueMember   = "Id";
            cbbLopHocEmp.DataSource = _employeeBLL._unitOfWork.employeeRepository.GetAll();
        }

        private void LoadRegisters()
        {
            detailRegisters =(List<DetailRegister>)_registerBLL.unitOfWork.registerRepository.GetAll();
            dtgDangky.DataSource = detailRegisters;
            dtgDangky.Columns["StudentId"].Visible = false;
            dtgDangky.Columns["ClassId"].Visible = false;
            dtgDangky.Columns["Id"].Visible = false;
            dtgDangky.Columns["Cost"].Visible = false;
            dtgDangky.Columns["Duration"].Visible = false;
        }

        private void LoadClassStudy()
        {
            dtgClassStudy.DataSource = _classBll._unitOfWork.classStudyRepository.GetAll();
            dtgClassStudy.Columns["CourseId"].Visible = false;
            dtgClassStudy.Columns["CaseId"].Visible = false;
            dtgClassStudy.Columns["EmpId"].Visible = false;
            dtgClassStudy.Columns["BranchId"].Visible = false;
            dtgClassStudy.Columns["Id"].Visible = false;
        }

        private void LoadCaseStudy()
        {
            cbbLopCaHoc.DisplayMember = "Name";
            cbbLopCaHoc.ValueMember   = "Id";
            cbbLopCaHoc.DataSource    = _caseStudyBLL._unitOfWork.caseStudyRepository.GetAll();

        }
        private void LoadCourses()
        {
            cbbCourses.DisplayMember = "Lesson";
            cbbCourses.ValueMember   = "Id";
            cbbCourses.DataSource    =  _coursesBLL.unitOfWork.coursesRepository.GetAll();           
        }

        private void LoadLopCourses()
        {
            cbbLopHocKH.DisplayMember = "Lesson";
            cbbLopHocKH.ValueMember = "Id";
            cbbLopHocKH.DataSource = _coursesBLL.unitOfWork.coursesRepository.GetAll();
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
            if (listCaseStudy.Count > 0)
            {
                cbbCaHoc.DisplayMember = "Name";
                cbbCaHoc.ValueMember = "Id";
            }
            else
            {
                cbbCaHoc.DisplayMember = "";
                cbbCaHoc.ValueMember = "";
            }
         

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
            if(listCaseStudy.Count > 0)
            {
                LoadCaseStudy(listCaseStudy);
            }
            else
            {
                cbbCaHoc.Text = String.Empty;
                this.IdCaseStudy = null;
                tbDateStudy.Text = String.Empty;
                tbStartTime.Text = String.Empty;
            }
        
        }

        private string FormatCurrency(decimal money)
        {
            var cul = CultureInfo.GetCultureInfo("vi-VN");
            return money.ToString("#,##", cul.NumberFormat);
        }

        private void cbbCaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextCaseStudy();
        }

        private void SetTextCaseStudy()
        {
            var caseStudy = (CaseStudys)cbbCaHoc.SelectedItem;
            this.IdCaseStudy = caseStudy.Id;
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
                if(ConfirmAction($"Bạn có chắc thêm mới học sinh {txtFullName.Text} ?","Thêm học sinh!!"))
                {
                    AddStudent();
                    LoadStudents();
                }         
            }
        }

        private bool IsAddRegister()
        {
           return String.IsNullOrEmpty(cbbCaHoc.Text) &&
                  String.IsNullOrEmpty(tbDateStudy.Text) &&
                  String.IsNullOrEmpty(tbStartTime.Text) ||
                  this.IdCaseStudy == null ? true : false;
            
        }

        private void AddRegister()
        {
            if (IsAddRegister())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                var isNoPayment = String.IsNullOrEmpty(tbTuition.Text);
                var classId = dictionaryClassCaseStudy[(int)this.IdCaseStudy];
                var register = new Register
                {
                    StudentId = (int)((Student)cbbHocvien.SelectedItem).Id,
                    ClassId = classId,
                    PaymentDate = DateTime.Now,
                    Amount = isNoPayment ? 0 : decimal.Parse(tbTuition.Text),
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

        }

        private void btnDangkydk_Click(object sender, EventArgs e)
        {
            if(ConfirmAction("Bạn có chắc muốn đăng ký ?", "Đăng ký khóa học!!"))
            {
                AddRegister();
                LoadRegisters();
            }
           
        }

        private bool ConfirmAction(string message,string cation)
        {
            var confirmResult = MessageBox.Show(message,cation,MessageBoxButtons.YesNo);
            return confirmResult == DialogResult.Yes;
        }

        private void dtgDangky_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           var register =  (DetailRegister)dtgDangky.CurrentRow.DataBoundItem;
           SetInfoRegiter(register);
        }
        private decimal TuitionDebt(decimal cost, decimal amount)
        {
            var money = cost - amount;
            return money;
        }

        private void btnThanhtoandk_Click(object sender, EventArgs e)
        {
            var tuitionDebt = nmrConno.Value;
            var currentRow = dtgDangky.CurrentRow;
            var index = currentRow.Index;
            var register = (DetailRegister)currentRow.DataBoundItem;
            var totalDebt = tuitionDebt + register.Amount;
            var message = $"Đóng tiền học cho học sinh: {register.NameStudent}\nSố tiền:{FormatCurrency(totalDebt)} đồng";
            if (ConfirmAction(message,"Đóng tiền học!!"))
            {
                PaymentTuition(totalDebt, register, index);
            }
            
        }

        private void PaymentTuition(decimal totalDebt, DetailRegister register,int index)
        {
            if (totalDebt > register.Cost)
            {
                Notify("Qúa số tiền đóng, vui lòng nhập lại");
            }
            else
            {
                bool isSuccess = _registerBLL.unitOfWork.registerRepository.PaymentTuition((int)register.Id, totalDebt);
                if (isSuccess)
                {
                    Notify("Đóng tiền thành công");
                    LoadRegisters();
                    var registers = (List<DetailRegister>)dtgDangky.DataSource;
                    var item = registers.Find(r => (int)r.Id == register.Id);
                    SetInfoRegiter(item);
                    dtgDangky.CurrentCell = dtgDangky.Rows[index].Cells[0];
                    SearchRegisterByNameStudent();
                }
                else
                {
                    Notify("Đóng tiền thất bại");
                }
            }
        }
        private void SetInfoRegiter(DetailRegister detailRegister)
        {
            tbMoney.Text = FormatCurrency(detailRegister.Cost);
            txtInfoLesson.Text = detailRegister.Lessons;
            txtInfoDuration.Text = detailRegister.Duration.ToString() + " giờ";
            var tuitionDebt = TuitionDebt(detailRegister.Cost, detailRegister.Amount);
            nmrConno.Text = tuitionDebt.ToString();

            if (tuitionDebt != 0m)
            {
                btnThanhtoandk.Visible = true;
            }
            else if (!detailRegister.Status)
            {
                btnThanhtoandk.Visible = true;
            }
            else
            {
                btnThanhtoandk.Visible = false;
            }
        }

        private void txbMahocvien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                SearchRegisterByNameStudent();
            }
        }

        private void txbMahocvien_KeyUp(object sender, KeyEventArgs e)
        {
             SearchRegisterByNameStudent();
        }

        private void SearchRegisterByNameStudent()
        {
            var listRegister = detailRegisters;
            var listExistName = listRegister.Where(r => r.NameStudent.Contains(txbMahocvien.Text.Trim())).ToList();
            if (listExistName.Count > 0)
            {
                dtgDangky.DataSource = listExistName;
                SetInfoRegiter(listExistName[0]);
            }
            else
            {
                dtgDangky.DataSource = detailRegisters;
            }
        }

        private void dtgDangky_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Cập nhật ca học", MenuItemNew_Click));
                int currentMouseOverRow = dtgDangky.HitTest(e.X, e.Y).RowIndex;
                var nameStudent = dtgDangky.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                var student = detailRegisters.Find(d => d.NameStudent.Equals(nameStudent));
                m.Show(dtgDangky, new Point(e.X, e.Y));
                this.frmUpdate = new FormUpdateClassStudent(_registerBLL, (int)student.StudentId);
                this.frmUpdate.EventUpdateHandler += FrmUpdate_EventUpdateHandler;   
            }
        }

        private void FrmUpdate_EventUpdateHandler(object sender, FormUpdateClassStudent.UpdateEventArgs args)
        {
            LoadRegisters();
            this.frmUpdate.Hide();
        }

        private void MenuItemNew_Click(Object sender, System.EventArgs e)
        {
            frmUpdate.Show();
           
        }

        private void cbbLopCaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
           var caseStudy = (CaseStudys)cbbLopCaHoc.SelectedItem;
           tbLopNgayHoc.Text = caseStudy.DateStudy;
           tbLopThoigian.Text = caseStudy.StartTime;
        }
        // them lop hoc
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if(ConfirmAction("Bạn có chắc muốn thêm lớp học!","Thêm mới lớp học!!"))
            {
                AddClassStudy();
            }
       
        }

        private void AddClassStudy()
        {
            var coursesId = cbbLopHocKH.SelectedValue;
            var caseStudyId = cbbLopCaHoc.SelectedValue;
            var teacherId = cbbLopHocEmp.SelectedValue;
            var branchId = cbbBranch.SelectedText == "Chi nhánh 1" ? 1 : 2;
            var room = tbRoom.Text.Trim();
            var timePerWeek = tbThoiGianHoc.Text.Trim();
            var classStudy = new ClassStudys
            {
                CourseId = (int)coursesId,
                CaseId = (int)caseStudyId,
                EmpId = teacherId.ToString(),
                BranchId = branchId,
                Room = int.Parse(room),
                StartDate = DateTime.Parse(dtNgayBatDau.Value.Date.ToString().Split(' ')[0]),
                TimePerWeek = int.Parse(timePerWeek),
                Active =true
            };
            bool isSuccess = _classBll._unitOfWork.classStudyRepository.Add(classStudy);
            if (isSuccess)
            {
                Notify("Thêm lớp học mới thành công!");
                LoadClassStudy();
            }
            else
            {
                Notify("Thêm lớp học thất bại!!");
            }

        }
        // add ca hoc
        private void kryptonButton3_Click(object sender, EventArgs e)
        {
           if(ConfirmAction("Bạn có chắc thêm ca học","Thêm ca học!!"))
            {
                AddCaseStudy();
            }
        }
        private void AddCaseStudy()
        {
            var caseStudy = new CaseStudys
            {
                Name = tbNameCaHoc.Text,
                DateStudy = cbbDate.Text,
                StartTime = cbbTimeDate.Text,
            };
            bool isSuccess = _caseStudyBLL._unitOfWork.caseStudyRepository.Add(caseStudy);
            if (isSuccess)
            {
                Notify("Thêm ca học thành công!");
                LoadCaseStudy();
            }
            else
            {
                Notify("Thêm ca học thất bại!");
            }
        }
    }
}
