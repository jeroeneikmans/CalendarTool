namespace CalendarTool
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;

            // left
            //int y = Screen.PrimaryScreen.Bounds.Bottom - this.Height;
            //this.Location = new Point(0, y);

            // right
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);

            this.ShowInTaskbar = false;
            this.TopMost = true;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("nl-NL");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            this.Text = "Info";
            this.label1.Text = this.Text;

            this.notifyIcon1.Text = string.Empty;
            SetToday();
        }

        private static string GetText(Boolean isTitle)
        {
            System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            int week = calendar.GetWeekOfYear(DateTime.Now, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int quarter = (DateTime.Now.Month - 1) / 3 + 1;

            string day = DateTime.Now.ToString("dd-MM");

            string text = string.Empty;
            if (isTitle)
            {
                text = string.Format("Q{0} W{1} {2}", quarter, week, day);
            }
            else
            {
                text = string.Format("Q{0}\nW{1}\n{2}", quarter, week, day);
            }

            return text;
        }

        private void SetToday()
        {
            DateTime next1 = DateTime.Now.Date;

            SetDate(next1, true);
            this.Text = GetText(true);
            this.label1.Text = this.Text;
        }

        private void SetDate(DateTime date, Boolean setMinDate = false)
        {
            if (setMinDate)
            {
                DateTime minDate = new DateTime(date.Year, date.Month, 1);

                DateTime controlMinDate = this.monthCalendar1.MinDate;
                
                this.monthCalendar1.MinDate = minDate;
                this.monthCalendar1.SetDate(date);

                this.monthCalendar1.MinDate = controlMinDate;
            }
            else
            {
                this.monthCalendar1.SetDate(date);
            }
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            string text = GetText(false);
            this.notifyIcon1.Text = text;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            SetToday();
        }

        private void btnQ1_Click(object sender, EventArgs e)
        {
            DateTime next1;

            if (DateTime.Now.Month <= 3)
            {
                next1 = new DateTime(DateTime.Now.Year, 1, 1);
            }
            else
            {
                next1 = new DateTime(DateTime.Now.Year+1, 1, 1);
            }

            SetDate(next1, true);
        }

        private void btnQ2_Click(object sender, EventArgs e)
        {
            DateTime next1;

            if (DateTime.Now.Month <= 6)
            {
                next1 = new DateTime(DateTime.Now.Year, 4, 1);
            }
            else
            {
                next1 = new DateTime(DateTime.Now.Year + 1, 4, 1);
            }
                
            SetDate(next1, true);
        }

        private void btnQ3_Click(object sender, EventArgs e)
        {
            DateTime next1;

            if (DateTime.Now.Month <= 9)
            {
                next1 = new DateTime(DateTime.Now.Year, 7, 1);
            }
            else
            {
                next1 = new DateTime(DateTime.Now.Year + 1, 7, 1);
            }
            SetDate(next1, true);
        }

        private void btnQ4_Click(object sender, EventArgs e)
        {
            DateTime next1;

            next1 = new DateTime(DateTime.Now.Year, 10, 1);

            SetDate(next1, true);
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.SetToday();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Hide();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
