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
    public partial class IssueBookForm : Form
    {
        public IssueBookForm()
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

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM issue", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "issue");

            DataRow thisRow = thisDataSet.Tables["issue"].NewRow();
            try
            {

                if (string.IsNullOrEmpty(txtMemberID.Text))
                {
                    MessageBox.Show("member id is Empty");
                }
                else if (string.IsNullOrEmpty(txtBookID.Text))
                {
                    MessageBox.Show("book id is Empty");
                }
                else
                {
                    thisRow["member_id"] = Convert.ToInt32(txtMemberID.Text);
                    thisRow["book_id"] = Convert.ToInt32(txtBookID.Text);
                    thisRow["issue_start_date"] = DateTime.Now;
                    thisRow["issue_end_date"] = dateTimePicker1.Text;
                    thisRow["issue_status"] = "Issued";

                    thisDataSet.Tables["issue"].Rows.Add(thisRow);



                    thisAdapter.Update(thisDataSet, "issue");
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sno = txtMemberID.Text.ToString();

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * FROM member where member_id=" + Convert.ToInt32(sno);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    txtName.Text = thisReader["member_name"].ToString();
                    txtMail.Text = thisReader["member_mail"].ToString();
                    txtMode.Text = thisReader["member_mode"].ToString();
                    txtCity.Text = thisReader["member_city"].ToString();
                    txtPhone.Text = thisReader["member_phone"].ToString();
                }
                else
                {
                    MessageBox.Show("no data");
                    txtMemberID.Text = "";
                }


                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sno = txtBookID.Text.ToString();

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * FROM book b,author a,publisher p where b.author_id=a.author_id and b.publisher_id=p.publisher_id and book_id=" + Convert.ToInt32(sno);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    txtBookName.Text = thisReader["book_name"].ToString();
                    txtBookMode.Text = thisReader["book_mode"].ToString();
                    txtAuthorName.Text = thisReader["author_name"].ToString();
                    txtPublisherName.Text = thisReader["publisher_name"].ToString();
                }
                else
                {
                    MessageBox.Show("no data");
                    txtBookID.Text = "";
                }


                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }
    }
}
