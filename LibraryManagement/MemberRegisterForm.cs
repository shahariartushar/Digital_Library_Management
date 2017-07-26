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
    public partial class MemberRegisterForm : Form
    {
        public MemberRegisterForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM member", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "member");

            DataRow thisRow = thisDataSet.Tables["member"].NewRow();
            try
            {

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Name is Empty");
                }
                else if (string.IsNullOrEmpty(txtMail.Text))
                {
                    MessageBox.Show("Mail is Empty");
                }
                else if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("Username is Empty");
                }
                else if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Password is Empty");
                }
                else if (string.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show("City is Empty");
                }
                else if (string.IsNullOrEmpty(txtPhoneno.Text))
                {
                    MessageBox.Show("Phone No is Empty");
                }
                else
                {

                    thisRow["MEMBER_NAME"] = txtName.Text;
                    thisRow["MEMBER_PHONE"] = txtPhoneno.Text;
                    thisRow["MEMBER_MAIL"] = txtMail.Text;
                    thisRow["MEMBER_USERNAME"] = txtUsername.Text;
                    thisRow["MEMBER_PASSWORD"] = txtPassword.Text;
                    thisRow["MEMBER_CITY"] = txtCity.Text;
                    thisRow["MEMBER_MODE"] = "Registered";
                    

                    thisDataSet.Tables["member"].Rows.Add(thisRow);



                    thisAdapter.Update(thisDataSet, "member");
                    MessageBox.Show("Submitted");

                    if (Common.regForm)
                    {
                        this.Close();
                    }
                    else
                    {
                        LoginForm ob = new LoginForm();
                        ob.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Common.regForm)
            {
                this.Close();
            }
            else
            {
                LoginForm ob = new LoginForm();
                ob.Show();
                this.Close();
            }

        }
    }
}
