namespace CalendarTool
{

    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnM = new System.Windows.Forms.Button();
            this.btnQ4 = new System.Windows.Forms.Button();
            this.btnQ3 = new System.Windows.Forms.Button();
            this.btnQ2 = new System.Windows.Forms.Button();
            this.btnQ1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(98, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
            this.toolStripMenuItem1.Text = "Quit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.Window;
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 3);
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnM);
            this.panel2.Controls.Add(this.btnQ4);
            this.panel2.Controls.Add(this.btnQ3);
            this.panel2.Controls.Add(this.btnQ2);
            this.panel2.Controls.Add(this.btnQ1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 27);
            this.panel2.TabIndex = 2;
            // 
            // btnM
            // 
            this.btnM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM.Location = new System.Drawing.Point(1, 0);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(45, 23);
            this.btnM.TabIndex = 0;
            this.btnM.Text = "T";
            this.btnM.UseVisualStyleBackColor = true;
            this.btnM.Click += new System.EventHandler(this.btnT_Click);
            // 
            // btnQ4
            // 
            this.btnQ4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQ4.Location = new System.Drawing.Point(203, 0);
            this.btnQ4.Name = "btnQ4";
            this.btnQ4.Size = new System.Drawing.Size(45, 23);
            this.btnQ4.TabIndex = 4;
            this.btnQ4.Text = "Q4";
            this.btnQ4.UseVisualStyleBackColor = true;
            this.btnQ4.Click += new System.EventHandler(this.btnQ4_Click);
            // 
            // btnQ3
            // 
            this.btnQ3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQ3.Location = new System.Drawing.Point(154, 0);
            this.btnQ3.Name = "btnQ3";
            this.btnQ3.Size = new System.Drawing.Size(45, 23);
            this.btnQ3.TabIndex = 3;
            this.btnQ3.Text = "Q3";
            this.btnQ3.UseVisualStyleBackColor = true;
            this.btnQ3.Click += new System.EventHandler(this.btnQ3_Click);
            // 
            // btnQ2
            // 
            this.btnQ2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQ2.Location = new System.Drawing.Point(103, 0);
            this.btnQ2.Name = "btnQ2";
            this.btnQ2.Size = new System.Drawing.Size(45, 23);
            this.btnQ2.TabIndex = 2;
            this.btnQ2.Text = "Q2";
            this.btnQ2.UseVisualStyleBackColor = true;
            this.btnQ2.Click += new System.EventHandler(this.btnQ2_Click);
            // 
            // btnQ1
            // 
            this.btnQ1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQ1.Location = new System.Drawing.Point(52, 0);
            this.btnQ1.Name = "btnQ1";
            this.btnQ1.Size = new System.Drawing.Size(45, 23);
            this.btnQ1.TabIndex = 1;
            this.btnQ1.Text = "Q1";
            this.btnQ1.UseVisualStyleBackColor = true;
            this.btnQ1.Click += new System.EventHandler(this.btnQ1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(250, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.monthCalendar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQ3;
        private System.Windows.Forms.Button btnQ2;
        private System.Windows.Forms.Button btnQ1;
        private System.Windows.Forms.Button btnM;
        private System.Windows.Forms.Button btnQ4;
        private System.Windows.Forms.Label label1;
    }
}

