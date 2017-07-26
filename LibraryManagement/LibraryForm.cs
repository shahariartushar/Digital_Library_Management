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
    public partial class LibraryForm : Form
    {
        public LibraryForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            
            this.Hide();
            lf.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAdminFrom uf = new CreateAdminFrom();
            uf.Show();
        }

        private void bookselfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBookSelfFrom uf = new CreateBookSelfFrom();
            uf.Show();
        }

        private void publisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePublisherFrom uf = new CreatePublisherFrom();
            uf.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateBookFrom uf = new CreateBookFrom();
            uf.Show();
        }

        private void bookSelfToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemoveBookSelfFrom uf = new RemoveBookSelfFrom();
            uf.Show();
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateGeneralBookFrom uf = new UpdateGeneralBookFrom();
            uf.Show();

        }

        private void newAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAuthorForm uf = new CreateAuthorForm();
            uf.Show();
        }

        private void addQuanityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateQuantityBookFrom uf = new UpdateQuantityBookFrom();
            uf.Show();
        }

        private void updatePublisherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateBookSelfForm uf = new UpdateBookSelfForm();
            uf.Show();
        }

        private void updatePublisherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdatePublisherForm uf = new UpdatePublisherForm();
            uf.Show();
        }

        private void updateAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAuthorForm uf = new UpdateAuthorForm();
            uf.Show();
        }

        private void memberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemoveMemberForm uf = new RemoveMemberForm();
            uf.Show();
        }

        private void bookToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RemoveBookForm uf = new RemoveBookForm();
            uf.Show();
        }

        private void publisherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RemovePublisherForm uf = new RemovePublisherForm();
            uf.Show();
        }

        private void removeAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAuthorForm uf = new RemoveAuthorForm();
            uf.Show();
        }

        private void viewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchMemberForm uf = new SearchMemberForm();
            uf.Show();
        }

        private void memberToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Common.regForm = true;
            MemberRegisterForm uf = new MemberRegisterForm();
            uf.Show();
        }

        private void updateMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMemberForm uf = new UpdateMemberForm();
            uf.Show();
        }

        private void memberToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ViewAllMemberForm uf = new ViewAllMemberForm();
            uf.Show();
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBookForm yf = new SearchBookForm();
            yf.Show();
        }

        private void bookToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ViewAllBookForm uf = new ViewAllBookForm();
            uf.Show();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBookForm uf = new IssueBookForm();
            uf.Show();
        }



    }
}
