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
    public partial class CreateAuthorForm : Form
    {
        public CreateAuthorForm()
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

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM author", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "author");

            DataRow thisRow = thisDataSet.Tables["author"].NewRow();
            try
            {

                if (string.IsNullOrEmpty(txtAuthorName.Text))
                {
                    MessageBox.Show("Author name is Empty");
                }
                else if (string.IsNullOrEmpty(txtAuthorMail.Text))
                {
                    MessageBox.Show("Author mail is Empty");
                }
                else
                {

                    thisRow["Author_name"] = txtAuthorName.Text;
                    thisRow["Author_Mail"] = txtAuthorMail.Text;

                    thisDataSet.Tables["author"].Rows.Add(thisRow);

                    thisAdapter.Update(thisDataSet, "author");
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
