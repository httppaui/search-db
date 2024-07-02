using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _169__Pamittan_Agcanas_DBConn1
{
    public partial class frmViewDoctors : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Z:\\169_Pamittan_PaulaHewlett_SC\\169_Pamittan_PaulaHewlett_Agcanas_JakeRussel_AppDB\\dbHospital.accdb");

        public frmViewDoctors()
        {
            InitializeComponent();
        }

        void search(string _query)
        {
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            grdDoctors.DataSource = dt;
        }

        private void frmViewDoctors_Load(object sender, EventArgs e)
        {
            search("SELECT doctor.* FROM doctor WHERE(((doctor.Lastname) = '" + txtDoctor.Text + "'));");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("SELECT doctor.* FROM doctor WHERE(((doctor.Lastname) = '" + txtDoctor.Text + "'));");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDoctor.Clear();
            search("SELECT doctor.* FROM doctor");
            
        }
    }
}
