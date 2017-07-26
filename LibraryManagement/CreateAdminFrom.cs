using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class CreateAdminFrom : Form
    {
        public CreateAdminFrom()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM admin", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "admin");

            DataRow thisRow = thisDataSet.Tables["admin"].NewRow();
            try
            {

                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("Username is Empty");
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Password is Empty");
                }
                else
                {

                    thisRow["USERNAME"] = txtUsername.Text;
                    thisRow["PASSWORD"] = txtPassword.Text;

                    thisDataSet.Tables["admin"].Rows.Add(thisRow);



                    thisAdapter.Update(thisDataSet, "admin");
                    MessageBox.Show("Submitted");

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
        }
    }
}
