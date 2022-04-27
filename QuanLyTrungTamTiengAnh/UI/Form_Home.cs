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
        private EmployeeBLL empBLL = null;
        private BranchBLL branchBLL = null;
        private IUnitOfWork _unitOfWork  = new UnitOfWork();
        private RegisterBLL _registerBLL = null;
        private StudentBLL  _studentBLL  = null;
        private CoursesBLL  _coursesBLL  = null;
        private ClassStudyBLL _classBll  = null;
        private CaseStudyBLL _caseStudyBLL = null;
        private EmployeeBLL _employeeBLL = null;
        private ReportBLL _reportBLL = null;
        private IDictionary<int, int> dictionaryClassCaseStudy =null;
        private List<DetailRegister> detailRegisters = null;
        private FormUpdateClassStudent frmUpdate = null;
        private frmBaoCao frmReport = null;
        private List<Employee> employees = new List<Employee>();
        private List<Branch> branches = new List<Branch>();

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
            _reportBLL = new ReportBLL(_unitOfWork);
            empBLL = new EmployeeBLL(_unitOfWork);
            branchBLL = new BranchBLL(_unitOfWork);
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadRegisters();
            LoadCourses();
            LoadClassStudy();
            LoadLopCourses();
            LoadCaseStudy();
            LoadBranchTemp();
            LoadEmployees();
            LoadTimeDayClass();
            LoadDateStudy();
            LoadCbbGiaoVien();
            LoadClassStudyWithoutTeacher();
            LoadAllEmployee();
            LoadBranch();
            LoadLevel();
            LoadJobTitle();
            loadTypeSearch();
        }
        IDictionary<string, string> typeSearch = new Dictionary<string, string>()
            {
                {"Id","Mã nhân viên" },
                 {"BranhId","Nhánh" },
                {"FullName","Họ tên"},
                {"DOB","Ngày sinh"},
                {"Phone","SĐT" },
                {"Qualification","Trình độ"},
                {"Nation", "Quốc tịch" },
                {"Jobtitle","Chức danh" },
                 {"Salary","Lương" }
            };

        public void loadTypeSearch()
        {
            cbSearchType.DataSource = new BindingSource(typeSearch, null);
            cbSearchType.ValueMember = "key";
            cbSearchType.DisplayMember = "value";
        }
        private void SearchEmployeeByeName()
        {
            string typeSearch = cbSearchType.SelectedValue.ToString();
            var listEmployee = employees;

            var listNEmployeeExist = listEmployee.Where(employee =>
                      employee.GetType().GetProperty(typeSearch).GetValue(employee).ToString().ToLower().Contains(txtSearchByName.Text.ToLower().Trim())).ToList();
            if (listNEmployeeExist.Count > 0)
            {
                dtgNhanVien.DataSource = listNEmployeeExist;
            }
            else
            {
                dtgNhanVien.DataSource = employees;
            }
        }

        public void LoadAllEmployee()
        {

            employees = (List<Employee>)empBLL._unitOfWork.employeeRepository.GetAll();
            dtgNhanVien.DataSource = employees;
        }
        public void LoadBranch()
        {
            branches = (List<Branch>)branchBLL._unitOfWork.branchRepository.GetAll();
            cbBranch.DataSource = branches;
            cbBranch.DisplayMember = "Name";
            cbBranch.ValueMember = "Id";
        }
        public void LoadLevel()
        {
            string[] levels = { "Đại học", "Cao đẳng", "THCS" };
            cbbLevel.DataSource = levels;
        }
        public void LoadJobTitle()
        {
            string[] jobTitles = { "Giáo viên", "lễ Tân", "Bảo vệ", "Kế toán", "Nhân viên" };
            cbbJobTitle.DataSource = jobTitles;
        }

        private void LoadTimeDayClass()
        {
            cbbTimeDate.DataSource = TimeDayClass;
        }

        private void LoadBranchTemp()
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
                m.MenuItems.Add(new MenuItem("Xuất báo cáo", MenuItemBaoCao_Click));

                int currentMouseOverRow = dtgDangky.HitTest(e.X, e.Y).RowIndex;
                var nameStudent = dtgDangky.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                var idStudent = dtgDangky.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                var student = detailRegisters.Find(d => d.NameStudent.Equals(nameStudent));
                m.Show(dtgDangky, new Point(e.X, e.Y));
                var billStudents = _reportBLL._unitOfWork.reportRepository.PrintBillByStudent(student.StudentId);
                this.frmReport = new frmBaoCao($"Biên lại tiền học của học sinh {nameStudent}", billStudents);
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

            var teacherId = chbAddGv.Checked ? null : cbbLopHocEmp.SelectedValue.ToString();
            var branchId = cbbBranch.SelectedText == "Chi nhánh 1" ? 1 : 2;
            var room = tbRoom.Text.Trim();
            var timePerWeek = tbThoiGianHoc.Text.Trim();
            var classStudy = new ClassStudys
            {
                CourseId = (int)coursesId,
                CaseId = (int)caseStudyId,
                EmpId = teacherId,
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

        private void LoadClassStudyWithoutTeacher()
        {
            cbbKHAddNV.DisplayMember = "NameLessons";
            cbbKHAddNV.ValueMember = "CourseId";
            cbbKHAddNV.DataSource = _classBll._unitOfWork.classStudyRepository.GetAllWithoutTeacher();
        }
        private void LoadCbbGiaoVien()
        {
            cbbGanGv.DisplayMember = "FullName";
            cbbGanGv.ValueMember = "Id";
            cbbGanGv.DataSource = _employeeBLL._unitOfWork.employeeRepository.GetAll();
        }
        private void cbbKHAddNV_SelectedIndexChanged(object sender, EventArgs e)
        {
           var classStudy = (DetailClassStudy)cbbKHAddNV.SelectedItem;
           txtNameCH.Text = classStudy.NameCaseStudy;
           txtIdLopHoc.Text = classStudy.Id.ToString();
        }

        //Add Emp in class
        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if(ConfirmAction("Bạn có chắc muốn gắn giáo viên?","Gắn giáo viên!!"))
            {
                DeclareTeacherInClass();
            }
        }

        private void DeclareTeacherInClass()
        {
            var idTeach = cbbGanGv.SelectedValue;
            var isSuccess = _classBll._unitOfWork.classStudyRepository.UpdateEmployeesInClass(int.Parse(txtIdLopHoc.Text), idTeach.ToString());
            if (isSuccess)
            {
                Notify("Gắn giáo viên vào lớp học thành công!");
                LoadClassStudy();
                LoadClassStudyWithoutTeacher();
            }
            else
            {
                Notify("Gắn giáo viên thất bại!");
            }
        }

        private void dtgClassStudy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Báo học viên theo lớp", MenuItemBaoCao_Click));
                int currentMouseOverRow = dtgClassStudy.HitTest(e.X, e.Y).RowIndex;
                var idClass = dtgClassStudy.Rows[currentMouseOverRow].Cells[4].Value.ToString();
                m.Show(dtgClassStudy, new Point(e.X, e.Y));
                var listStudent = _reportBLL._unitOfWork.reportRepository.PrintStudentInClass(int.Parse(idClass));
                this.frmReport = new frmBaoCao("Báo cáo danh sách học viên theo lớp".ToUpper(),listStudent);
               // this.frmUpdate.EventUpdateHandler += FrmUpdate_EventUpdateHandler;
            }
        }
        private void MenuItemBaoCao_Click(Object sender, System.EventArgs e)
        {
            this.frmReport.Show();

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            var idCourses = cbbLopHocKH.SelectedValue;
            var nameLesson = cbbLopHocKH.Text;
            var listStudent = _reportBLL._unitOfWork.reportRepository.PrintStudentInCourses((int)idCourses);
            this.frmReport = new frmBaoCao($"Báo cáo danh sách học viên theo khóa học {nameLesson}".ToUpper(), listStudent);
            this.frmReport.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            var emp = cbbLopHocEmp.Text.Trim();
            var listClass =  _reportBLL._unitOfWork.reportRepository.PrintClassByTeacher(emp);
            this.frmReport = new frmBaoCao($"Báo cáo danh sách lớp theo giáo viên {emp}".ToUpper(),listClass);
            this.frmReport.Show();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
           var listReport = _reportBLL._unitOfWork.reportRepository.ReportMax("GVMax");
            tbReportGV.Text = listReport[0].FullName;
            tbReportSLGV.Text = listReport[0].Solop.ToString();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            var listReport = _reportBLL._unitOfWork.reportRepository.ReportMax("HVMax");
            tbReportHS.Text = listReport[0].FullName;
            tbReportSLHS.Text = listReport[0].Solop.ToString();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            var listReport = _reportBLL._unitOfWork.reportRepository.ReportMax("KHMax");
            tbReportKH.Text = listReport[0].FullName;
            tbReportKHHS.Text = listReport[0].Solop.ToString();
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            var listReport = _reportBLL._unitOfWork.reportRepository.ReportCaHocMax();
            dtgReportMax.DataSource = listReport;
            tbHSCaHoc.Text = listReport[0].SoHocSinh;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            var listReport = _reportBLL._unitOfWork.reportRepository.TeacherNotInClass();
            dtgReportMax.DataSource = listReport;
        }

        private void txtSearchByName_KeyUp(object sender, KeyEventArgs e)
        {
            //SearchEmployeeByeName();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee
            {
                BranhId = int.Parse(cbBranch.SelectedValue.ToString()),
                FullName = txtFullName1.Text,
                DOB = dtpDOB.CalendarTodayDate,
                Phone = txtPhone.Text,
                Qualification = cbbLevel.Text,
                Nation = txtNation.Text,
                Jobtitle = cbbJobTitle.Text,
                Salary = int.Parse(txtSalary.Text)
            };
            var result = empBLL._unitOfWork.employeeRepository.Add(employee);
            handleNotifyFromData(result, "Thêm nhân viên thành công", "Thêm nhân viên thất bại");
        }
        private void handleNotifyFromData(bool result, string notifySuccess, string notifyError)
        {
            if (result)
            {
                Notify(notifySuccess);
                LoadAllEmployee();
            }
            else
            {
                Notify(notifyError);
            }
        }

        string idEmployee = "";
        Employee currentEmployee;
        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dtgNhanVien.Rows[index];
            idEmployee = selectedRow.Cells[0].Value.ToString();
            cbBranch.SelectedValue = selectedRow.Cells[1].Value;
            txtFullName1.Text = selectedRow.Cells[2].Value.ToString();
            dtpDOB.CalendarTodayText = selectedRow.Cells[3].Value.ToString();
            txtPhone.Text = selectedRow.Cells[4].Value.ToString();
            cbbLevel.Text = selectedRow.Cells[5].Value.ToString();
            txtNation.Text = selectedRow.Cells[6].Value.ToString();
            cbbJobTitle.Text = selectedRow.Cells[7].Value.ToString();
            txtSalary.Text = selectedRow.Cells[8].Value.ToString();

            currentEmployee = new Employee
            {
                Id = selectedRow.Cells[0].Value.ToString(),
                BranhId = int.Parse(selectedRow.Cells[1].Value.ToString()),
                FullName = selectedRow.Cells[2].Value.ToString(),
                DOB = DateTime.Parse(selectedRow.Cells[3].Value.ToString()),
                Phone = selectedRow.Cells[4].Value.ToString(),
                Qualification = selectedRow.Cells[5].Value.ToString(),
                Nation = selectedRow.Cells[6].Value.ToString(),
                Jobtitle = selectedRow.Cells[7].Value.ToString(),
                Salary = int.Parse(selectedRow.Cells[8].Value.ToString())
            };
        }

        private void dtgNhanVien_Click(object sender, EventArgs e)
        {
            btnUpdateEmployee.Visible = true;
            btnDeleteEmployee.Visible = true;
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {

            Employee employee = new Employee
            {
                Id = currentEmployee.Id,
                BranhId = int.Parse(cbBranch.SelectedValue.ToString()),
                FullName = txtFullName1.Text,
                DOB = DateTime.Parse(dtpDOB.Value.ToString()),
                Phone = txtPhone.Text,
                Qualification = cbbLevel.Text,
                Nation = txtNation.Text,
                Jobtitle = cbbJobTitle.Text,
                Salary = int.Parse(txtSalary.Text)
            };


            if (currentEmployee.BranhId != employee.BranhId)
            {

                var result = empBLL._unitOfWork.employeeRepository.Update(idEmployee, employee);
                var updateBranch = empBLL._unitOfWork.employeeRepository.UpdateBranchEmployee(currentEmployee.BranhId, employee.BranhId, employee.Id);
                handleNotifyFromData(result && updateBranch, "cập nhật nhân viên thành công", "cập nhật nhân viên thất bại");

            }
            else
            {
                var result = empBLL._unitOfWork.employeeRepository.Update(idEmployee, employee);
                handleNotifyFromData(result, "cập nhật nhân viên thành công", "cập nhật nhân viên thất bại");

            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            var result = empBLL._unitOfWork.employeeRepository.Delete(idEmployee);
            handleNotifyFromData(result, "Xoá nhân viên thành công", "Xoá nhân viên thất bại");
        }

        ///\
        ///

    }
}
