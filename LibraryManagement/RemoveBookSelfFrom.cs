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
    public partial class RemoveBookSelfFrom : Form
    {
        private bool found = false;
        private int bsid = 0;
        public RemoveBookSelfFrom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            found = false;
            txtBookSelfName.Clear();
            listView1.Items.Clear();

            string sno = txtBookSelfNo.Text;

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "Select * from book_self where self_no='" + sno + "'";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    txtBookSelfName.Text = thisReader["self_name"].ToString();
                    bsid = Convert.ToInt32(thisReader["self_id"].ToString());
                }
                else
                {
                    MessageBox.Show("data not found");
                }




                thisCommand.CommandText =
                    "SELECT * FROM book b,book_self bs,publisher p,author a where a.author_id=b.author_id and b.self_id=bs.self_id and b.publisher_id=p.publisher_id and bs.self_no='" + sno + "'";

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
                    "delete from book_self where self_id= " + bsid;

                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandType = CommandType.Text;
            
                if(!found)
                {
                    thisCommand.ExecuteNonQuery();
                    MessageBox.Show("delete successfully");
                }
                else
                {
                   
                    DialogResult resul = MessageBox.Show("Do you want to remove book self forcfully?",
                                                        "Delete",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);

                    if (resul.ToString() == "OK")
                    {
                        OracleCommand ora_cmd = new OracleCommand("self_del", CN.thisConnection);
                        ora_cmd.BindByName = true;
                        ora_cmd.CommandType = CommandType.StoredProcedure;

                        ora_cmd.Parameters.Add("sid", OracleDbType.Int32, bsid, ParameterDirection.Input);
                        ora_cmd.ExecuteNonQuery();

                    }

                    

                }
                CN.thisConnection.Close();

                listView1.Items.Clear();
                txtBookSelfName.Clear();
                txtBookSelfNo.Clear();
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
