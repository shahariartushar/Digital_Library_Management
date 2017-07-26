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
    public partial class RemoveBookForm : Form
    {
        private bool found = false;
        public RemoveBookForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bno = Convert.ToInt32(txtBookID.Text.ToString());

            found = false;
            txtBookName.Clear();
            txtBookQty.Clear();
            txtAuthorName.Clear();
            txtPublisherName.Clear();

            try
            {

                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "Select * from book b,author a,publisher p where b.author_id=a.author_id and b.publisher_id=p.publisher_id and b.book_id=" + bno;

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    txtBookName.Text = thisReader["book_name"].ToString();
                    txtBookQty.Text = thisReader["book_quantity"].ToString();
                    txtAuthorName.Text = thisReader["author_name"].ToString();
                    txtPublisherName.Text = thisReader["publisher_name"].ToString();
                }
                else
                {
                    MessageBox.Show("data not found");
                }

                thisCommand.CommandText =
                    "SELECT * FROM issue i,book b where i.book_id=b.book_id and i.book_id =" + bno;

                thisReader = thisCommand.ExecuteReader();

                if(thisReader.Read())
                {
                    found = true;
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
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "delete from book where book_id= " + Convert.ToInt32(txtBookID.Text.ToString());

                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandType = CommandType.Text;

                if (!found)
                {
                    thisCommand.ExecuteNonQuery();
                    MessageBox.Show("delete successfully");
                }
                else
                {

                    DialogResult result = MessageBox.Show("Do you want to remove book forcefully?",
                                                        "Delete",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);

                    if (result.ToString() == "OK")
                    {
                        int bid = Convert.ToInt32(txtBookID.Text.ToString());

                        OracleCommand ora_cmd = new OracleCommand("book_del", CN.thisConnection);
                        ora_cmd.BindByName = true;
                        ora_cmd.CommandType = CommandType.StoredProcedure;

                        ora_cmd.Parameters.Add("bid", OracleDbType.Int32, bid, ParameterDirection.Input);
                        ora_cmd.ExecuteNonQuery();

                    }

                }
                CN.thisConnection.Close();

                txtBookID.Clear();
                txtBookName.Clear();
                txtBookQty.Clear();
                txtAuthorName.Clear();
                txtPublisherName.Clear();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
