namespace LibraryManagement
{
    partial class SearchMemberForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnSearch = new System.Windows.Forms.RadioButton();
            this.cbCatagory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Member_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Member_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Member_Mail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Member_City = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Member_PhnNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCatagory = new System.Windows.Forms.Label();
            this.cbmode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Location = new System.Drawing.Point(10, 18);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(36, 17);
            this.rbtnAll.TabIndex = 0;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // rbtnSearch
            // 
            this.rbtnSearch.AutoSize = true;
            this.rbtnSearch.Location = new System.Drawing.Point(57, 18);
            this.rbtnSearch.Name = "rbtnSearch";
            this.rbtnSearch.Size = new System.Drawing.Size(59, 17);
            this.rbtnSearch.TabIndex = 1;
            this.rbtnSearch.TabStop = true;
            this.rbtnSearch.Text = "Search";
            this.rbtnSearch.UseVisualStyleBackColor = true;
            this.rbtnSearch.CheckedChanged += new System.EventHandler(this.rbtnSearch_CheckedChanged);
            // 
            // cbCatagory
            // 
            this.cbCatagory.FormattingEnabled = true;
            this.cbCatagory.Items.AddRange(new object[] {
            "Name",
            "City",
            "Mode"});
            this.cbCatagory.Location = new System.Drawing.Point(139, 17);
            this.cbCatagory.Name = "cbCatagory";
            this.cbCatagory.Size = new System.Drawing.Size(138, 21);
            this.cbCatagory.TabIndex = 2;
            this.cbCatagory.SelectedIndexChanged += new System.EventHandler(this.cbCatagory_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(300, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(137, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(455, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 21);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Member_ID,
            this.Member_Name,
            this.Member_Mail,
            this.Member_City,
            this.Member_PhnNo,
            this.Mode});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(10, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(684, 333);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Member_ID
            // 
            this.Member_ID.Text = "ID";
            // 
            // Member_Name
            // 
            this.Member_Name.Text = "Name";
            this.Member_Name.Width = 160;
            // 
            // Member_Mail
            // 
            this.Member_Mail.Text = "Mail";
            this.Member_Mail.Width = 180;
            // 
            // Member_City
            // 
            this.Member_City.Text = "City";
            this.Member_City.Width = 100;
            // 
            // Member_PhnNo
            // 
            this.Member_PhnNo.Text = "Phn No";
            this.Member_PhnNo.Width = 100;
            // 
            // Mode
            // 
            this.Mode.Text = "Mode";
            this.Mode.Width = 80;
            // 
            // lblCatagory
            // 
            this.lblCatagory.AutoSize = true;
            this.lblCatagory.Location = new System.Drawing.Point(136, 1);
            this.lblCatagory.Name = "lblCatagory";
            this.lblCatagory.Size = new System.Drawing.Size(48, 13);
            this.lblCatagory.TabIndex = 6;
            this.lblCatagory.Text = "catagory";
            // 
            // cbmode
            // 
            this.cbmode.FormattingEnabled = true;
            this.cbmode.Items.AddRange(new object[] {
            "Active",
            "Registered",
            "Inactive"});
            this.cbmode.Location = new System.Drawing.Point(300, 18);
            this.cbmode.Name = "cbmode";
            this.cbmode.Size = new System.Drawing.Size(138, 21);
            this.cbmode.TabIndex = 7;
            this.cbmode.SelectedIndexChanged += new System.EventHandler(this.cbmode_SelectedIndexChanged);
            // 
            // SearchMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(704, 419);
            this.Controls.Add(this.cbmode);
            this.Controls.Add(this.lblCatagory);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbCatagory);
            this.Controls.Add(this.rbtnSearch);
            this.Controls.Add(this.rbtnAll);
            this.Name = "SearchMemberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewMemberForm";
            this.Load += new System.EventHandler(this.ViewMemberForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.RadioButton rbtnSearch;
        private System.Windows.Forms.ComboBox cbCatagory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Member_ID;
        private System.Windows.Forms.ColumnHeader Member_Name;
        private System.Windows.Forms.ColumnHeader Member_Mail;
        private System.Windows.Forms.ColumnHeader Member_City;
        private System.Windows.Forms.ColumnHeader Member_PhnNo;
        private System.Windows.Forms.ColumnHeader Mode;
        private System.Windows.Forms.Label lblCatagory;
        private System.Windows.Forms.ComboBox cbmode;
    }
}