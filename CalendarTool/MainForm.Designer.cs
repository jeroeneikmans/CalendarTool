﻿namespace CalendarTool
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            panel1 = new System.Windows.Forms.Panel();
            btnD = new System.Windows.Forms.Button();
            checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            textBox1 = new System.Windows.Forms.TextBox();
            btnA = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            btnM = new System.Windows.Forms.Button();
            btnQ4 = new System.Windows.Forms.Button();
            btnQ3 = new System.Windows.Forms.Button();
            btnQ2 = new System.Windows.Forms.Button();
            btnQ1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            notifyIcon1.MouseMove += notifyIcon1_MouseMove;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(98, 26);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
            toolStripMenuItem1.Text = "Quit";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(btnD);
            panel1.Controls.Add(checkedListBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnA);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(monthCalendar1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(516, 491);
            panel1.TabIndex = 5;
            // 
            // btnD
            // 
            btnD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnD.Location = new System.Drawing.Point(3, 20);
            btnD.Name = "btnD";
            btnD.Size = new System.Drawing.Size(45, 23);
            btnD.TabIndex = 13;
            btnD.Text = "-";
            btnD.UseVisualStyleBackColor = true;
            btnD.Click += btnD_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.HorizontalScrollbar = true;
            checkedListBox1.Location = new System.Drawing.Point(3, 45);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.ScrollAlwaysVisible = true;
            checkedListBox1.Size = new System.Drawing.Size(250, 416);
            checkedListBox1.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            textBox1.Location = new System.Drawing.Point(266, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(195, 23);
            textBox1.TabIndex = 11;
            // 
            // btnA
            // 
            btnA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnA.Location = new System.Drawing.Point(466, 20);
            btnA.Name = "btnA";
            btnA.Size = new System.Drawing.Size(45, 23);
            btnA.TabIndex = 10;
            btnA.Text = "+";
            btnA.UseVisualStyleBackColor = true;
            btnA.Click += btnA_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnM);
            panel2.Controls.Add(btnQ4);
            panel2.Controls.Add(btnQ3);
            panel2.Controls.Add(btnQ2);
            panel2.Controls.Add(btnQ1);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 462);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(514, 27);
            panel2.TabIndex = 8;
            // 
            // btnM
            // 
            btnM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnM.Location = new System.Drawing.Point(266, 0);
            btnM.Name = "btnM";
            btnM.Size = new System.Drawing.Size(45, 23);
            btnM.TabIndex = 5;
            btnM.Text = "T";
            btnM.UseVisualStyleBackColor = true;
            btnM.Click += btnT_Click;
            // 
            // btnQ4
            // 
            btnQ4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQ4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQ4.Location = new System.Drawing.Point(466, 0);
            btnQ4.Name = "btnQ4";
            btnQ4.Size = new System.Drawing.Size(45, 23);
            btnQ4.TabIndex = 9;
            btnQ4.Text = "Q4";
            btnQ4.UseVisualStyleBackColor = true;
            btnQ4.Click += btnQ4_Click;
            // 
            // btnQ3
            // 
            btnQ3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQ3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQ3.Location = new System.Drawing.Point(416, 0);
            btnQ3.Name = "btnQ3";
            btnQ3.Size = new System.Drawing.Size(45, 23);
            btnQ3.TabIndex = 8;
            btnQ3.Text = "Q3";
            btnQ3.UseVisualStyleBackColor = true;
            btnQ3.Click += btnQ3_Click;
            // 
            // btnQ2
            // 
            btnQ2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQ2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQ2.Location = new System.Drawing.Point(366, 0);
            btnQ2.Name = "btnQ2";
            btnQ2.Size = new System.Drawing.Size(45, 23);
            btnQ2.TabIndex = 7;
            btnQ2.Text = "Q2";
            btnQ2.UseVisualStyleBackColor = true;
            btnQ2.Click += btnQ2_Click;
            // 
            // btnQ1
            // 
            btnQ1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnQ1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQ1.Location = new System.Drawing.Point(316, 0);
            btnQ1.Name = "btnQ1";
            btnQ1.Size = new System.Drawing.Size(45, 23);
            btnQ1.TabIndex = 6;
            btnQ1.Text = "Q1";
            btnQ1.UseVisualStyleBackColor = true;
            btnQ1.Click += btnQ1_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.Window;
            label1.Location = new System.Drawing.Point(265, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 7;
            label1.Text = "label1";
            label1.MouseClick += label1_MouseClick;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            monthCalendar1.BackColor = System.Drawing.SystemColors.Window;
            monthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 3);
            monthCalendar1.Location = new System.Drawing.Point(265, 21);
            monthCalendar1.MaxSelectionCount = 100;
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.ShowToday = false;
            monthCalendar1.ShowWeekNumbers = true;
            monthCalendar1.TabIndex = 6;
            monthCalendar1.DateSelected += monthCalendar1_DateSelected;
            // 
            // MainForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size(516, 491);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "MainForm";
            Text = "MainForm";
            VisibleChanged += MainForm_VisibleChanged;
            KeyDown += MainForm_KeyDown;
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnM;
        private System.Windows.Forms.Button btnQ4;
        private System.Windows.Forms.Button btnQ3;
        private System.Windows.Forms.Button btnQ2;
        private System.Windows.Forms.Button btnQ1;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnD;
    }
}

