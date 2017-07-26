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
    public partial class UpdateMemberForm : Form
    {
        public UpdateMemberForm()
        {
            InitializeComponent();
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
                    txtUsername.Text = thisReader["member_username"].ToString();
                    txtPassword.Text = thisReader["member_password"].ToString();
                    txtCity.Text = thisReader["member_city"].ToString();
                    txtPhoneno.Text = thisReader["member_phone"].ToString();
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Connection sv = new Connection();
                sv.thisConnection.Open();
                OracleCommand thisCommand = sv.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "update member set member_name='" + txtName.Text + "', member_mail='" + txtMail.Text + "', member_username='" + txtUsername.Text + "', member_password='" + txtPassword.Text + "', member_city='" + txtCity.Text + "', member_phone='" + txtPhoneno.Text + "' where member_id=" + Convert.ToInt32(txtMemberID.Text.ToString());

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
