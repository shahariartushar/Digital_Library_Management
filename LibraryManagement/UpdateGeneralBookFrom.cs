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
    public partial class UpdateGeneralBookFrom : Form
    {
        public UpdateGeneralBookFrom()
        {
            InitializeComponent();
        }

        private void loadcb()
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sno = txtBookID.Text;

            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();
                
                thisCommand.CommandText =
                    "SELECT * FROM book b,book_self bs,publisher p,author a where a.author_id=b.author_id and b.self_id=bs.self_id and b.publisher_id=p.publisher_id and b.Book_id='" + sno + "'";

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                if(thisReader.Read())
                {
                    txtBookName.Text = thisReader["book_name"].ToString();
                    
                    cbAuthorID.Text = thisReader["Author_id"].ToString();
                    txtAuthorName.Text = thisReader["author_name"].ToString();
                    txtAuthorMail.Text = thisReader["author_mail"].ToString();
                    
                    cbPublisherID.Text = thisReader["Publisher_ID"].ToString();
                    txtPublisherName.Text = thisReader["Publisher_name"].ToString();
                    txtPublisherMail.Text = thisReader["Publisher_mail"].ToString();
                    
                    cbBookSelfID.Text = thisReader["Self_id"].ToString();
                    txtBookSelfNo.Text = thisReader["Self_no"].ToString();
                    txtBookSelfName.Text = thisReader["self_name"].ToString();
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
                    "update book set book_name = '" + txtBookName.Text + "', author_id=" + Convert.ToInt32(cbAuthorID.Text) + ",publisher_ID=" + Convert.ToInt32(cbPublisherID.Text) + ",self_ID=" + Convert.ToInt32(cbBookSelfID.Text) + "where book_id= '" + txtBookID.Text + "'";

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

        private void UpdateGeneralBookFrom_Load(object sender, EventArgs e)
        {
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
                    cbPublisherID.Items.Add(thisReader["publisher_ID"].ToString());
                }


                //bookself_id load
                thisCommand.CommandText =
                    "SELECT * FROM book_self";

                thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbBookSelfID.Items.Add(thisReader["self_ID"].ToString());
                }


                //author_id load
                thisCommand.CommandText =
                    "SELECT * FROM author";

                thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    cbAuthorID.Items.Add(thisReader["author_ID"].ToString());
                }


                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void cbAuthorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                //author_name_mail load
                thisCommand.CommandText =
                    "SELECT * FROM author where author_id=" + Convert.ToInt32(cbAuthorID.Text);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    txtAuthorName.Text = thisReader["author_name"].ToString();
                    txtAuthorMail.Text = thisReader["author_mail"].ToString();
                }

                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void cbPublisherID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                "SELECT * FROM publisher where publisher_id=" + Convert.ToInt32(cbPublisherID.Text);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    txtPublisherName.Text = thisReader["publisher_name"].ToString();
                    txtPublisherMail.Text = thisReader["publisher_mail"].ToString();
                }

                CN.thisConnection.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void cbBookSelfID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();

                OracleCommand thisCommand = CN.thisConnection.CreateCommand();

                thisCommand.CommandText =
                "SELECT * FROM book_self where self_id=" + Convert.ToInt32(cbBookSelfID.Text);

                OracleDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    txtBookSelfNo.Text = thisReader["self_no"].ToString();
                    txtBookSelfName.Text = thisReader["self_name"].ToString();
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
