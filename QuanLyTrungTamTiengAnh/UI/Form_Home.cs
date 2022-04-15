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
using Core.IConfiguration;
using Core.UnitOfWork;
namespace UI
{
    public partial class frmHome : Form
    {
        private IUnitOfWork _unitOfWork =new UnitOfWork();
        private RegisterBLL _registerBLL = null;
        private StudentBLL _studentBLL = null;
        public frmHome()
        {
            InitializeComponent();
            _registerBLL = new RegisterBLL(_unitOfWork);
            _studentBLL = new StudentBLL(_unitOfWork);
            
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }
        private void LoadRegisters()
        {
            _registerBLL.unitOfWork.registerRepository.GetAll();
        }

        private void LoadStudents()
        {
           dtgDangky.DataSource = _studentBLL.unitOfWork.studentRepository.GetAll();
        }

     
    }
}
