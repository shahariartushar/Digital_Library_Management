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
    public partial class SearchMemberForm : Form
    {
        public SearchMemberForm()
        {
            InitializeComponent();
        }

        private void ViewMemberForm_Load(object sender, EventArgs e)
        {
            cbCatagory.Visible = false;
            txtSearch.Visible = false;
            lblCatagory.Visible = false;
            btnSearch.Visible = false;
            cbmode.Visible = false;

            listView1.Items.Clear();

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * FROM view_member";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["member_id"].ToString();
                    lsvItem.SubItems.Add(thisReader["member_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mail"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_city"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_phone"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mode"].ToString());

                    listView1.Items.Add(lsvItem);
                }


                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }

        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            cbCatagory.Visible = false;
            txtSearch.Visible = false;
            lblCatagory.Visible = false;
            btnSearch.Visible = false;
            cbmode.Visible = false;

            listView1.Items.Clear();

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * FROM view_member";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["member_id"].ToString();
                    lsvItem.SubItems.Add(thisReader["member_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mail"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_city"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_phone"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mode"].ToString());

                    listView1.Items.Add(lsvItem);
                }


                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void rbtnSearch_CheckedChanged(object sender, EventArgs e)
        {
            cbCatagory.Visible = true;
            txtSearch.Visible = true;
            btnSearch.Visible = true;
            lblCatagory.Visible = true;

            listView1.Items.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (cbCatagory.Text == "Name")
            {
                try
                {
                    Connection CN = new Connection();
                    CN.thisConnection.Open();

                    OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                    thisCommand.CommandText =
                        "select * from view_member where member_name like '" + txtSearch.Text + "%' or member_name like '%" + txtSearch.Text + "%' or member_name like '%" + txtSearch.Text + "'";

                    OracleDataReader thisReader = thisCommand.ExecuteReader();

                    while (thisReader.Read())
                    {
                        ListViewItem lsvItem = new ListViewItem();
                        lsvItem.Text = thisReader["member_id"].ToString();
                        lsvItem.SubItems.Add(thisReader["member_name"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_mail"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_city"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_phone"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_mode"].ToString());

                        listView1.Items.Add(lsvItem);
                    }


                    CN.thisConnection.Close();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                }
            }
            else if (cbCatagory.Text == "City")
            {
                try
                {
                    Connection CN = new Connection();
                    CN.thisConnection.Open();

                    OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                    thisCommand.CommandText =
                        "select * from view_member where member_city like '" + txtSearch.Text + "%' or member_name like '%" + txtSearch.Text + "%' or member_name like '%" + txtSearch.Text + "'";

                    OracleDataReader thisReader = thisCommand.ExecuteReader();

                    while (thisReader.Read())
                    {
                        ListViewItem lsvItem = new ListViewItem();
                        lsvItem.Text = thisReader["member_id"].ToString();
                        lsvItem.SubItems.Add(thisReader["member_name"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_mail"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_city"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_phone"].ToString());
                        lsvItem.SubItems.Add(thisReader["member_mode"].ToString());

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

        private void cbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCatagory.Text == "Mode")
            {
                cbmode.Visible = true;
                txtSearch.Visible = false;
                btnSearch.Visible = false;
            }
            else
            {
                cbmode.Visible = false;
                txtSearch.Visible = true;
                btnSearch.Visible = true;
            }
        }

        private void cbmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "select * from view_member where member_mode='" + cbmode.Text + "'";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["member_id"].ToString();
                    lsvItem.SubItems.Add(thisReader["member_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mail"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_city"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_phone"].ToString());
                    lsvItem.SubItems.Add(thisReader["member_mode"].ToString());

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
