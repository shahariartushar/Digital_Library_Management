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
    public partial class RemoveMemberForm : Form
    {
        private bool found = false;
        public RemoveMemberForm()
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
            txtMemberName.Clear();
            listView1.Items.Clear();

            string sno = txtMemberID.Text;

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText=
                    "Select * from member where member_id="+Convert.ToInt32(sno);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if(thisReader.Read())
                {
                    txtMemberName.Text = thisReader["member_name"].ToString();
                }
                else
                {
                    MessageBox.Show("data not found");
                }
                
                
                
                
                thisCommand.CommandText =
                    "SELECT * FROM issue i,member m,book b,author a,publisher p where i.member_id=m.member_id and i.book_id=b.book_id and b.author_id=a.author_id and b.publisher_id=p.publisher_id and m.member_id="+Convert.ToInt32(sno);

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
                    "delete from member where member_id= " + Convert.ToInt32(txtMemberID.Text);

                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandType = CommandType.Text;
            
                if(!found)
                {
                    thisCommand.ExecuteNonQuery();
                    MessageBox.Show("delete successfully");
                }
                else
                {
                   
                    DialogResult result = MessageBox.Show("Do you want to remove member forcfully?",
                                                        "Delete",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2);

                    if (result.ToString() == "OK")
                    {
                        int mid = Convert.ToInt32(txtMemberID.Text);

                        OracleCommand ora_cmd = new OracleCommand("member_del", CN.thisConnection);
                        ora_cmd.BindByName = true;
                        ora_cmd.CommandType = CommandType.StoredProcedure;

                        ora_cmd.Parameters.Add("mid", OracleDbType.Int32, mid, ParameterDirection.Input);
                        ora_cmd.ExecuteNonQuery();

                    }

                    listView1.Items.Clear();
                    txtMemberName.Clear();
                    txtMemberID.Clear();

                }
                CN.thisConnection.Close();
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
