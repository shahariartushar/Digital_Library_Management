using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace LibraryManagement
{
    public partial class UpdateBookSelfForm : Form
    {
        public UpdateBookSelfForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sno = txtSelfID.Text;

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * FROM book_self where self_id="+Convert.ToInt32(sno);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
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
            try
            {
                Connection sv = new Connection();
                sv.thisConnection.Open();
                OracleCommand thisCommand = sv.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "update book_self set self_no='" + txtSelfNo.Text + "', self_name='" + txtSelfName.Text + "' where self_id= '" + txtSelfID.Text + "'";

                thisCommand.Connection = sv.thisConnection;
                thisCommand.CommandType = CommandType.Text;


                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");
                this.Close();

                sv.thisConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
