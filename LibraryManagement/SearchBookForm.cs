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
    public partial class SearchBookForm : Form
    {
        public SearchBookForm()
        {
            InitializeComponent();
        }

        private void SearchBookForm_Load(object sender, EventArgs e)
        {
            lblCatagory.Visible = false;
            txtSearch.Visible = false;
            btnSearch.Visible = false;
            cbAuthor.Visible = false;
            cbCatagory.Visible = false;
            cbmode.Visible = false;
            cbPublisher.Visible = false;
            cbSelf.Visible = false;


            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                //publisher_id load
                thisCommand.CommandText =
                    "SELECT * FROM publisher";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbPublisher.Items.Add(thisReader["publisher_name"].ToString());
                }


                //bookself_id load
                thisCommand.CommandText =
                    "SELECT * FROM book_self";

                thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbSelf.Items.Add(thisReader["self_name"].ToString());
                }


                //author_id load
                thisCommand.CommandText =
                    "SELECT * FROM author";

                thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbAuthor.Items.Add(thisReader["author_name"].ToString());
                }


                //
                listView1.Items.Clear();

                thisCommand.CommandText =
                    "SELECT * FROM view_book";

                thisReader= thisCommand.ExecuteReader();



                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["book_name"].ToString();
                    lsvItem.SubItems.Add(Convert.ToInt32(thisReader["book_quantity"]).ToString());
                    lsvItem.SubItems.Add(Convert.ToInt32(thisReader["book_available"]).ToString());
                    lsvItem.SubItems.Add(thisReader["author_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["publisher_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["self_name"].ToString());

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
            lblCatagory.Visible = true;
            txtSearch.Visible = true;
            btnSearch.Visible = true;
            //cbAuthor.Visible = true;
            cbCatagory.Visible = true;
            //cbmode.Visible = true;
            //cbPublisher.Visible = true;
            //cbSelf.Visible = true;

            listView1.Items.Clear();
        }

        private void cbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCatagory.Text == "Book Name")
            {
                txtSearch.Visible = true;
                btnSearch.Visible = true;

                cbAuthor.Visible = false;
                cbmode.Visible = false;
                cbPublisher.Visible = false;
                cbSelf.Visible = false;
            }
            else if (cbCatagory.Text == "Book Mode")
            {
                txtSearch.Visible = false;
                btnSearch.Visible = false;

                cbAuthor.Visible = false;
                cbmode.Visible = true;
                cbPublisher.Visible = false;
                cbSelf.Visible = false;
            }
            else if (cbCatagory.Text == "Author Name")
            {
                txtSearch.Visible = false;
                btnSearch.Visible = false;

                cbAuthor.Visible = true;
                cbmode.Visible = false;
                cbPublisher.Visible = false;
                cbSelf.Visible = false;
            }
            else if (cbCatagory.Text == "Publisher Name")
            {
                txtSearch.Visible = false;
                btnSearch.Visible = false;

                cbAuthor.Visible = false;
                cbmode.Visible = false;
                cbPublisher.Visible = true;
                cbSelf.Visible = false;
            }
            else if (cbCatagory.Text == "Self Name")
            {
                txtSearch.Visible = false;
                btnSearch.Visible = false;

                cbAuthor.Visible = false;
                cbmode.Visible = false;
                cbPublisher.Visible = false;
                cbSelf.Visible = true;
            }
        }
    }
}
