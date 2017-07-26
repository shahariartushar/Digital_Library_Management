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
    public partial class RemovePublisherForm : Form
    {
        private bool found = false;
        public RemovePublisherForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            found = false;
            txtPublisherName.Clear();
            txtPublisherMail.Clear();
            listView1.Items.Clear();

            string sno = txtPublisherID.Text.ToString();

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "Select * from publisher where publisher_id=" + Convert.ToInt32(sno);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    txtPublisherName.Text = thisReader["Publisher_name"].ToString();
                    txtPublisherMail.Text = thisReader["Publisher_mail"].ToString();
                }
                else
                {
                    MessageBox.Show("data not found");
                }




                thisCommand.CommandText =
                    "SELECT * FROM book b,publisher p,author a where a.author_id=b.author_id and b.publisher_id=p.publisher_id and b.publisher_id=" + Convert.ToInt32(sno);

                thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    ListViewItem lsvItem = new ListViewItem();
                    lsvItem.Text = thisReader["book_name"].ToString();
                    lsvItem.SubItems.Add(thisReader["author_name"].ToString());
                    lsvItem.SubItems.Add(thisReader["publisher_name"].ToString());

                    listView1.Items.Add(lsvItem);

                    found = true;
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

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "delete from publisher where publisher_id= " + Convert.ToInt32(txtPublisherID.Text.ToString());

                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandType = CommandType.Text;

                if (!found)
                {
                    thisCommand.ExecuteNonQuery();
                    MessageBox.Show("delete successfully");
                }
                else
                {

                    DialogResult resul = MessageBox.Show("Do you want to remove publisher forcfully with books?",
                                                        "Delete",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);

                    if (resul.ToString() == "OK")
                    {
                        int pid = Convert.ToInt32(txtPublisherID.Text.ToString());

                        OracleCommand ora_cmd = new OracleCommand("publisher_del", CN.thisConnection);
                        ora_cmd.BindByName = true;
                        ora_cmd.CommandType = CommandType.StoredProcedure;

                        ora_cmd.Parameters.Add("pid", OracleDbType.Int32, pid, ParameterDirection.Input);
                        ora_cmd.ExecuteNonQuery();

                    }



                }
                CN.thisConnection.Close();

                listView1.Items.Clear();
                txtPublisherName.Clear();
                txtPublisherMail.Clear();
                txtPublisherID.Clear();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
