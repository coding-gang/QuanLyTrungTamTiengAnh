using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Entities;
using Dtos;

namespace UI
{
    public partial class frmBaoCao : Form
    {
        private IEnumerable<object> _listBaoCao = null;
        private string v;
        private List<Student> listStudent;
        private IEnumerable<ClassStudys> listClass;
        private List<BillStudent> billStudents;

        public frmBaoCao(string title,List<object> listBaoCao)
        {
            InitializeComponent();
            txtTitleBaoCao.Text = title;
            this._listBaoCao = listBaoCao;
            dtgBaoCao.DataSource = this._listBaoCao;
        }

        public frmBaoCao(string title, List<Student> listStudent)
        {
            InitializeComponent();
            txtTitleBaoCao.Text = title;
            this.listStudent = listStudent;
            dtgBaoCao.DataSource = this.listStudent;
        }

        public frmBaoCao(string title, IEnumerable<ClassStudys> listClass)
        {
            InitializeComponent();
            txtTitleBaoCao.Text = title;
            this.listClass = listClass;
            dtgBaoCao.DataSource = this.listClass;
            dtgBaoCao.Columns["CourseId"].Visible = false;
            dtgBaoCao.Columns["CaseId"].Visible = false;
            dtgBaoCao.Columns["EmpId"].Visible = false;
            dtgBaoCao.Columns["BranchId"].Visible = false;
            dtgBaoCao.Columns["Id"].Visible = false;
        }

        public frmBaoCao(string v, List<BillStudent> billStudents)
        {
            InitializeComponent();
            txtTitleBaoCao.Text = v;
            this.billStudents = billStudents;
            dtgBaoCao.DataSource = this.billStudents;
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
          //  LoadDataBaoCao();
        }

        //private void LoadDataBaoCao()
        //{
        //    dtgBaoCao.DataSource = this._listBaoCao;
        //}
    }
}
