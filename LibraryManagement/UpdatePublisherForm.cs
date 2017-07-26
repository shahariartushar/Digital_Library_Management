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
    public partial class UpdatePublisherForm : Form
    {
        public UpdatePublisherForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sno = txtPublisherID.Text;

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * FROM publisher where publisher_id=" + Convert.ToInt32(sno);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    txtPublisherName.Text = thisReader["publisher_name"].ToString();
                    txtPublisherMail.Text = thisReader["publisher_mail"].ToString();
                }
                else
                {
                    MessageBox.Show("no data");
                    txtPublisherID.Text = "";
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
                    "update publisher set publisher_name='" + txtPublisherName.Text + "', publisher_mail='" + txtPublisherMail.Text + "' where publisher_id= '" + txtPublisherID.Text + "'";

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
