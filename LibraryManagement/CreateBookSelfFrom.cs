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
    public partial class CreateBookSelfFrom : Form
    {
        public CreateBookSelfFrom()
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

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM book_self", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "book_self");

            DataRow thisRow = thisDataSet.Tables["book_self"].NewRow();
            try
            {

                if (string.IsNullOrEmpty(txtSelfNo.Text))
                {
                    MessageBox.Show("Bookself no is Empty");
                }
                else if (string.IsNullOrEmpty(txtSelfName.Text))
                {
                    MessageBox.Show("Bookself name is Empty");
                }
                else
                {

                    thisRow["Self_no"] = txtSelfNo.Text;
                    thisRow["Self_name"] = txtSelfName.Text;

                    thisDataSet.Tables["book_self"].Rows.Add(thisRow);

                    thisAdapter.Update(thisDataSet, "book_self");
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
