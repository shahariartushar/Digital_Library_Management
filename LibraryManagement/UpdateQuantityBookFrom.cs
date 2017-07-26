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
    public partial class UpdateQuantityBookFrom : Form
    {
        public UpdateQuantityBookFrom()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sno = txtBookID.Text;

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();
                
                thisCommand.CommandText =
                    "SELECT * FROM book b,book_self bs,publisher p,author a where a.author_id=b.author_id and b.self_id=bs.self_id and b.publisher_id=p.publisher_id and b.Book_id='" + sno + "'";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if(thisReader.Read())
                {
                    txtBookName.Text = thisReader["book_name"].ToString();
                    txtAuthorName.Text = thisReader["author_name"].ToString();
                    txtPublisherName.Text = thisReader["publisher_name"].ToString();
                    txtSelfName.Text = thisReader["self_name"].ToString();
                    txtBookQuantity.Text = thisReader["book_quantity"].ToString();
                    txtBookAvailable.Text = thisReader["book_available"].ToString();
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

                int bid = Convert.ToInt32(txtBookID.Text);
                int qty = Convert.ToInt32(txtAddQuantity.Text);

                OracleCommand ora_cmd = new OracleCommand("add_bookqty", CN.thisConnection);
                ora_cmd.BindByName = true;
                ora_cmd.CommandType = CommandType.StoredProcedure;

                ora_cmd.Parameters.Add("bid", OracleDbType.Int32, bid, ParameterDirection.Input);
                ora_cmd.Parameters.Add("qty", OracleDbType.Int32, qty, ParameterDirection.Input);
                ora_cmd.ExecuteNonQuery();

                CN.thisConnection.Close();

                MessageBox.Show("updated");

                txtBookID.Clear();
                txtBookName.Clear();
                txtAuthorName.Clear();
                txtPublisherName.Clear();
                txtSelfName.Clear();
                txtBookQuantity.Clear();
                txtBookAvailable.Clear();
                txtAddQuantity.Clear();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
