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
    public partial class CreateBookFrom : Form
    {
        public CreateBookFrom()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateBookFrom_Load(object sender, EventArgs e)
        {
            try
            {


                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                //publisher_id load
                thisCommand.CommandText =
                    "SELECT * FROM publisher";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbPublisherID.Items.Add(thisReader["publisher_ID"].ToString());
                }


                //bookself_id load
                thisCommand.CommandText =
                    "SELECT * FROM book_self";

                thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbBookSelfID.Items.Add(thisReader["self_ID"].ToString());
                }


                //author_id load
                thisCommand.CommandText =
                    "SELECT * FROM author";

                thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbAuthorID.Items.Add(thisReader["author_ID"].ToString());
                }


                CN.thisConnection.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void cbAuthorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                //author_name_mail load
                thisCommand.CommandText =
                    "SELECT * FROM author where author_id=" + Convert.ToInt32(cbAuthorID.Text);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    txtAuthorName.Text = thisReader["author_name"].ToString();
                    txtAuthorMail.Text = thisReader["author_mail"].ToString();
                }

                CN.thisConnection.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
            }

        }

        private void cbPublisherID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                "SELECT * FROM publisher where publisher_id=" + Convert.ToInt32(cbPublisherID.Text);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    txtPublisherName.Text = thisReader["publisher_name"].ToString();
                    txtPublisherMail.Text = thisReader["publisher_mail"].ToString();
                }

                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void cbBookSelfID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                "SELECT * FROM book_self where self_id=" + Convert.ToInt32(cbBookSelfID.Text);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    txtSelfNo.Text = thisReader["self_no"].ToString();
                    txtSelfName.Text = thisReader["self_name"].ToString();
                }

                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM book", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "book");

            DataRow thisRow = thisDataSet.Tables["book"].NewRow();
            try
            {

                if (string.IsNullOrEmpty(txtBookName.Text))
                {
                    MessageBox.Show("Book name is Empty");
                }
                else if (string.IsNullOrEmpty(txtBookQuantity.Text))
                {
                    MessageBox.Show("Book Quantity is Empty");
                }
                else if (string.IsNullOrEmpty(cbAuthorID.Text))
                {
                    MessageBox.Show("AuthorID is Empty");
                }
                else if (string.IsNullOrEmpty(cbPublisherID.Text))
                {
                    MessageBox.Show("PublisherID is Empty");
                }
                else if (string.IsNullOrEmpty(cbBookSelfID.Text))
                {
                    MessageBox.Show("BookSelfID is Empty");
                }
                else
                {

                    thisRow["Book_NAME"] = txtBookName.Text;
                    thisRow["Book_Quantity"] = Convert.ToInt32(txtBookQuantity.Text);
                    thisRow["Book_Available"] = Convert.ToInt32(txtBookQuantity.Text);
                    thisRow["Author_id"] = cbAuthorID.Text;
                    thisRow["Publisher_ID"] = cbPublisherID.Text;
                    thisRow["Self_ID"] = cbBookSelfID.Text;
                    thisRow["Book_MODE"] = "Enable";

                    thisDataSet.Tables["book"].Rows.Add(thisRow);

                    thisAdapter.Update(thisDataSet, "book");
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
