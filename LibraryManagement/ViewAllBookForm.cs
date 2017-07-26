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
    public partial class ViewAllBookForm : Form
    {
        public ViewAllBookForm()
        {
            InitializeComponent();
        }

        private void ViewAllBookForm_Load(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "SELECT * from view_allbook";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["book_id"].ToString();
                    lsvItem.SubItems.Add(thisReader["book_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["author_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["publisher_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["self_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["book_quantity"].ToString());
                    lsvItem.SubItems.Add(thisReader["book_available"].ToString());
                    lsvItem.SubItems.Add(thisReader["book_mode"].ToString());

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
