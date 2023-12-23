using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace CalendarTool
{
    public partial class MainForm : Form
    {
        private Calendar _calendar;

        public MainForm()
        {
            InitializeComponent();

            this.SetTheme();

            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;

            this.HideInfo();

            this.ShowInTaskbar = false;
            this.TopMost = true;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("nl-NL");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            this.Text = "Info";
            this.label1.Text = this.Text;

            this.notifyIcon1.Text = string.Empty;

            LoadGroupDates();
            AddGroupDates();
            SetToday();
        }

        private void SetTheme()
        {
            int theme = 0;

            try
            {
                theme = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", 0);

                // 0 : dark theme
                // 1 : light theme
            }
            catch
            {
            }

            if (theme == 0) 
            {
                this.Icon = Properties.Resources.CalendarToolDark;
            }

            if (theme == 1)
            {
                this.Icon = Properties.Resources.CalendarToolLight;
            }

            this.notifyIcon1.Icon = this.Icon;

        }

        private const int infoWidth = 266;
        private const int calendarWidth = 251;

        private void HideInfo()
        {
            this.richTextBox1.Width = 0;
            this.Width = calendarWidth;

            this.LocationBottomRight();
        }

        private void ShowInfo()
        {
            this.richTextBox1.Width = infoWidth;
            this.Width = infoWidth + calendarWidth;

            this.LocationBottomRight();
        }

        private void LocationBottomRight()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        private string GetText(Boolean isTitle, DateTime selection)
        {
            DateTime d = selection;

            System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            int week = calendar.GetWeekOfYear(d, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            int quarter = (d.Month - 1) / 3 + 1;

            string day = d.ToString("dd-MM");

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

        private string GetCalendarItemsText(DateTime selection)
        {
            DateTime d = selection;

            string text = string.Empty;

            SortedList<DateTime, string> calendarItems = new();

            foreach (var item in _calendar.Items)
            {
                if (item.Datetime.Date == d.Date)
                {
                    text = string.Empty;
                    text += item.Group;
                    text += ": ";
                    text += item.Info;
                    text += Environment.NewLine;

                    calendarItems.Add(item.Datetime, text);
                }
            }

            text = string.Empty;
            foreach (var item in calendarItems)
            {
                text += item.Key.ToString("g");
                text += Environment.NewLine;
                text += item.Value;
                text += Environment.NewLine;
            }

            return text;
        }

        private void LoadGroupDates()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = Path.GetDirectoryName(path);
            string file = Path.Combine(directory, "CalendarTool.json");

            string json = File.ReadAllText(file);
            _calendar = JsonSerializer.Deserialize<Calendar>(json);
        }

        private void AddGroupDates()
        {
            this.monthCalendar1.SuspendLayout();
            foreach (var item in _calendar.Items)
            {
                monthCalendar1.AddBoldedDate(item.Datetime);
            }

            this.monthCalendar1.ResumeLayout();
        }

        private void SetToday()
        {
            DateTime next1 = DateTime.Now.Date;

            SetDate(next1, true);
        }

        private void SetDate(DateTime date, Boolean setMinDate = false)
        {
            if (setMinDate)
            {
                DateTime minDate = new(date.Year, date.Month, 1);

                DateTime controlMinDate = this.monthCalendar1.MinDate;

                this.monthCalendar1.MinDate = minDate;
                this.monthCalendar1.SetDate(date);

                this.monthCalendar1.MinDate = controlMinDate;
            }
            else
            {
                this.monthCalendar1.SetDate(date);
            }

            this.Text = GetText(true, this.monthCalendar1.SelectionStart);
            this.label1.Text = this.Text;

            this.richTextBox1.Text = GetCalendarItemsText(this.monthCalendar1.SelectionStart);
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            string text = GetText(false, this.monthCalendar1.SelectionStart);
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
                next1 = new DateTime(DateTime.Now.Year + 1, 1, 1);
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            SetDate(e.Start, true);
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            // toggle
            if (this.richTextBox1.Width > 0)
            {
                this.HideInfo();
            }
            else
            {
                this.ShowInfo();
            }
        }
    }
}
