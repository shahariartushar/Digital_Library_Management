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
    public partial class ViewAllMemberForm : Form
    {
        public ViewAllMemberForm()
        {
            InitializeComponent();
        }

        private void ViewAllMemberForm_Load(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * from member";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["member_id"].ToString();
                    lsvItem.SubItems.Add(thisReader["member_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mail"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_username"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_password"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_phone"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mode"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_city"].ToString());

                    listView1.Items.Add(lsvItem);
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
