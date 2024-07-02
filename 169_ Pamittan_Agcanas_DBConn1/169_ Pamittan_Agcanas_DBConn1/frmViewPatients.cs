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
    public partial class frmViewPatients : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Z:\\169_Pamittan_PaulaHewlett_SC\\169_Pamittan_PaulaHewlett_Agcanas_JakeRussel_AppDB\\dbHospital.accdb");

        public frmViewPatients()
        {
            InitializeComponent();
        }

        private void frmViewPatients_Load(object sender, EventArgs e)
        {
            search("SELECT patient.* FROM patient WHERE(((patient.Lastname) = '" + txtPatient.Text + "'));");
        }

        void search(string _query)
        {
            OleDbCommand cmd = new OleDbCommand(_query, conn);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            grdPatients.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("SELECT patient.* FROM patient WHERE(((patient.Lastname) = '" + txtPatient.Text + "'));");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPatient.Clear();
            search("SELECT patient.* FROM patient");
        }
    }
}
