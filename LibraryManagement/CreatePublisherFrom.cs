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
    public partial class CreatePublisherFrom : Form
    {
        public CreatePublisherFrom()
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

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM publisher", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "publisher");

            DataRow thisRow = thisDataSet.Tables["publisher"].NewRow();
            try
            {

                if (string.IsNullOrEmpty(txtPublisherName.Text))
                {
                    MessageBox.Show("Publisher name is Empty");
                }
                else if (string.IsNullOrEmpty(txtPublisherMail.Text))
                {
                    MessageBox.Show("Publisher mail is Empty");
                }
                else
                {

                    thisRow["publisher_name"] = txtPublisherName.Text;
                    thisRow["publisher_mail"] = txtPublisherMail.Text;

                    thisDataSet.Tables["publisher"].Rows.Add(thisRow);

                    thisAdapter.Update(thisDataSet, "publisher");
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
