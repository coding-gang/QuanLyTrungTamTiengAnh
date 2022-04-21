using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Dtos;
using DAL.Entities;
namespace UI
{
    public partial class FormUpdateClassStudent : Form
    {
        private RegisterBLL _registerBLL = null;
        private int? _idStudent = null;
        private List<StudentRegister> studentRegisters = new List<StudentRegister>();
        private IDictionary<int, int> dictionaryClassCaseStudy = null;
        private List<CaseStudys> _listCaseStudys = null;
       

        public FormUpdateClassStudent(RegisterBLL registerBLL,int idStudent)
        {
            InitializeComponent();
            _idStudent = idStudent;
            _registerBLL = registerBLL;
        }

        public delegate void UpdateHandler(object sender, UpdateEventArgs args);
        public event UpdateHandler EventUpdateHandler;
        public class UpdateEventArgs : EventArgs
        {

        }
        public void UpdateFrm()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            EventUpdateHandler.Invoke(this, args);
        }

        private void cbbExchangeCaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var caseStudy = (CaseStudys)cbbExchangeCaHoc.SelectedItem;
            txtExchangeDateStudy.Text = caseStudy.DateStudy;
            txtExchangeStartTime.Text = caseStudy.StartTime;
        }

        private void FormUpdateClassStudent_Load(object sender, EventArgs e)
        {
            LoadStudentRegister();
        }

        private void LoadStudentRegister()
        {
            cbbCourses.DisplayMember = "Lesson";
            cbbCourses.ValueMember = "idCourses";
            studentRegisters = this._registerBLL.unitOfWork.registerRepository.RegisterClassForStudent((int)_idStudent);
            cbbCourses.DataSource = studentRegisters;
            lbNameStudent.Text = studentRegisters[0].NameStudent;
        }


        private void cbbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCourses.SelectedIndex > -1)
            {     
                var registerSelected = (StudentRegister)cbbCourses.SelectedItem;
                var stdRegiser = studentRegisters.Where(s => s.idCourses == registerSelected.idCourses).ToList();
                LoaddCbbCaHoc(stdRegiser);
                var infoRegisters = _registerBLL.unitOfWork.registerRepository.GetInfoToRegisters(registerSelected.idCourses);
                var caseStudyOrigin = InitCaseStudys(infoRegisters);
                var listCaseStudysRegister =  FilterCaseStudyRegister(caseStudyOrigin);
                if (listCaseStudysRegister.Count > 0)
                {
                    LoadCaseStudy(listCaseStudysRegister);
                }
            }
       
        }

        private List<CaseStudys> FilterCaseStudyRegister(List<CaseStudys> caseStudyOrigin)
        {
            var listForRegister = caseStudyOrigin.Where(x => !_listCaseStudys.Any(y => y.Id == x.Id)).ToList();
            return listForRegister;
        }

        private void LoadCaseStudy(List<CaseStudys> caseStudys)
        {
            if (caseStudys.Count > 0)
            {
                cbbExchangeCaHoc.DisplayMember = "Name";
                cbbExchangeCaHoc.ValueMember = "Id";
            }
            else
            {
                cbbExchangeCaHoc.DisplayMember = "";
                cbbExchangeCaHoc.ValueMember = "";
            }
            cbbExchangeCaHoc.DataSource = caseStudys;
           
        }

        private List<CaseStudys> InitCaseStudys(List<InfoToRegister> infoToRegisters)
        {
            var listCaseStudy = new List<CaseStudys>();
            dictionaryClassCaseStudy = new Dictionary<int, int>();
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
        private void LoaddCbbCaHoc(List<StudentRegister> stdRegister)
        {
            _listCaseStudys = new List<CaseStudys>();
            foreach (var item in stdRegister)
            {
                var caseStudy = new CaseStudys
                {
                    Id = item.idCaseStudy,
                    Name = item.NameCaseStudy,
                    DateStudy = item.DateStudy,
                    StartTime = item.StartTime
                };
                _listCaseStudys.Add(caseStudy);
            }
            cbbCahoc.DisplayMember = "Name";
            cbbCahoc.ValueMember = "Id";
            cbbCahoc.DataSource = _listCaseStudys;
        }

        private void cbbCahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
           var caseStudy = (CaseStudys)cbbCahoc.SelectedItem;
           txtDateStudy.Text = caseStudy.DateStudy;
           txtStartTime.Text = caseStudy.StartTime;
        }

        private void btnDoiCaHoc_Click(object sender, EventArgs e)
        {
            if (ConfirmAction("Bạn có chắc đổi lớp cho học sinh","Đổi lớp học!!"))
            {
                var caseStudy = (CaseStudys)cbbExchangeCaHoc.SelectedItem;
                var classIdRegister = dictionaryClassCaseStudy[caseStudy.Id];
                bool isSuccess = _registerBLL.unitOfWork.registerRepository.ExchangeClassStudent(classIdRegister, (int)this._idStudent);
                if (isSuccess)
                {
                    MessageBox.Show("Chuyển lớp thành công!");
                    UpdateFrm();
                }
                else
                {
                    MessageBox.Show("Chuyển lớp thất bại");
                }
            }
            
        }
        private bool ConfirmAction(string message, string cation)
        {
            var confirmResult = MessageBox.Show(message, cation, MessageBoxButtons.YesNo);
            return confirmResult == DialogResult.Yes;
        }
    }
}
