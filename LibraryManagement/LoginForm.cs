using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Oracle.DataAccess.Client;



namespace LibraryManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cboxRole.Text=="Admin")
            {
                try
                {
                    Connection CN = new Connection();
                    CN.thisConnection.Open();
                    
                    OracleCommand thisCommand = new OracleCommand();
                    thisCommand.Connection = CN.thisConnection;

                    thisCommand.CommandText = "select * from admin where username='"+txtUsername.Text+"' and password= '"+txtPassword.Text+"'";
                    OracleDataReader thisReader = thisCommand.ExecuteReader();
                    
                    if(thisReader.Read())
                    {
                        LibraryForm oform = new LibraryForm();
                        oform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("username or password incorrect");
                    }
                    //this.Close();
                    CN.thisConnection.Close();
                }
                catch(Exception es)
                {
                    MessageBox.Show(es.ToString());
                }
            }
            else
            {

            }
                   
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Common.regForm = false;

            MemberRegisterForm mf = new MemberRegisterForm();
            mf.Show();
            this.Hide();
        }
    }
}
