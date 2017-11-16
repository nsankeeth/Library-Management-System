namespace Library_Management_System
{
    partial class DataBE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBE));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.borrowedBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnedBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lostBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.r_ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reBname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r_mID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brrDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.b_ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b_mID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrowedBooksToolStripMenuItem,
            this.returnedBooksToolStripMenuItem,
            this.lostBooksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // borrowedBooksToolStripMenuItem
            // 
            this.borrowedBooksToolStripMenuItem.Name = "borrowedBooksToolStripMenuItem";
            this.borrowedBooksToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.borrowedBooksToolStripMenuItem.Text = "Borrowed Books";
            this.borrowedBooksToolStripMenuItem.Click += new System.EventHandler(this.borrowedBooksToolStripMenuItem_Click);
            // 
            // returnedBooksToolStripMenuItem
            // 
            this.returnedBooksToolStripMenuItem.Name = "returnedBooksToolStripMenuItem";
            this.returnedBooksToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.returnedBooksToolStripMenuItem.Text = "Returned Books";
            this.returnedBooksToolStripMenuItem.Click += new System.EventHandler(this.returnedBooksToolStripMenuItem_Click);
            // 
            // lostBooksToolStripMenuItem
            // 
            this.lostBooksToolStripMenuItem.Name = "lostBooksToolStripMenuItem";
            this.lostBooksToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.lostBooksToolStripMenuItem.Text = "Lost Books";
            this.lostBooksToolStripMenuItem.Click += new System.EventHandler(this.lostBooksToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(565, 463);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 24);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBN,
            this.bName,
            this.mID,
            this.brDate,
            this.lDate,
            this.fine});
            this.dataGridView3.Location = new System.Drawing.Point(8, 83);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(631, 376);
            this.dataGridView3.TabIndex = 16;
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.Name = "ISBN";
            this.ISBN.ReadOnly = true;
            // 
            // bName
            // 
            this.bName.HeaderText = "Book Name";
            this.bName.Name = "bName";
            this.bName.ReadOnly = true;
            // 
            // mID
            // 
            this.mID.HeaderText = "Member ID";
            this.mID.Name = "mID";
            this.mID.ReadOnly = true;
            // 
            // brDate
            // 
            this.brDate.HeaderText = "Borrow Date";
            this.brDate.Name = "brDate";
            this.brDate.ReadOnly = true;
            // 
            // lDate
            // 
            this.lDate.HeaderText = "Lost Date";
            this.lDate.Name = "lDate";
            this.lDate.ReadOnly = true;
            // 
            // fine
            // 
            this.fine.HeaderText = "Fine";
            this.fine.Name = "fine";
            this.fine.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.r_ISBN,
            this.reBname,
            this.r_mID,
            this.brrDate,
            this.rDate,
            this.charges});
            this.dataGridView2.Location = new System.Drawing.Point(8, 83);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(631, 376);
            this.dataGridView2.TabIndex = 17;
            // 
            // r_ISBN
            // 
            this.r_ISBN.HeaderText = "ISBN";
            this.r_ISBN.Name = "r_ISBN";
            this.r_ISBN.ReadOnly = true;
            // 
            // reBname
            // 
            this.reBname.HeaderText = "Book Name";
            this.reBname.Name = "reBname";
            this.reBname.ReadOnly = true;
            // 
            // r_mID
            // 
            this.r_mID.HeaderText = "Member ID";
            this.r_mID.Name = "r_mID";
            this.r_mID.ReadOnly = true;
            // 
            // brrDate
            // 
            this.brrDate.HeaderText = "Borrowed Date";
            this.brrDate.Name = "brrDate";
            this.brrDate.ReadOnly = true;
            // 
            // rDate
            // 
            this.rDate.HeaderText = "Returned Date";
            this.rDate.Name = "rDate";
            this.rDate.ReadOnly = true;
            // 
            // charges
            // 
            this.charges.HeaderText = "Charges";
            this.charges.Name = "charges";
            this.charges.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.b_ISBN,
            this.b_mID,
            this.bDate});
            this.dataGridView1.Location = new System.Drawing.Point(8, 83);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(631, 376);
            this.dataGridView1.TabIndex = 18;
            // 
            // b_ISBN
            // 
            this.b_ISBN.HeaderText = "ISBN";
            this.b_ISBN.Name = "b_ISBN";
            this.b_ISBN.ReadOnly = true;
            // 
            // b_mID
            // 
            this.b_mID.HeaderText = "Member ID";
            this.b_mID.Name = "b_mID";
            this.b_mID.ReadOnly = true;
            // 
            // bDate
            // 
            this.bDate.HeaderText = "Borrow Date";
            this.bDate.Name = "bDate";
            this.bDate.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(217, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 39);
            this.label1.TabIndex = 19;
            this.label1.Text = "Borrowed Books";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(221, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 39);
            this.label2.TabIndex = 20;
            this.label2.Text = "Returned Books";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(248, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 39);
            this.label3.TabIndex = 21;
            this.label3.Text = "Lost Books";
            // 
            // DataBE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(647, 501);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataBE";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database";
            this.Load += new System.EventHandler(this.DataBE_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem borrowedBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnedBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lostBooksToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn b_ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn b_mID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn bName;
        private System.Windows.Forms.DataGridViewTextBoxColumn mID;
        private System.Windows.Forms.DataGridViewTextBoxColumn brDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn lDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fine;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn reBname;
        private System.Windows.Forms.DataGridViewTextBoxColumn r_mID;
        private System.Windows.Forms.DataGridViewTextBoxColumn brrDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn rDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn charges;
    }
}