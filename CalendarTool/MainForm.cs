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
        private int _theme = 0;

        public MainForm()
        {
            InitializeComponent();

            this.SetTheme();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;

            this.HideInfo();

            this.ShowInTaskbar = false;
            this.TopMost = true;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            this.Text = "Info";
            this.label1.Text = this.Text;

            this.notifyIcon1.Text = string.Empty;

            LoadCalendarDates();
            ShowCalendarDates();
            SetToday();
        }

        private void SetTheme()
        {
            try
            {
                _theme = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", 0);

                // 0 : dark theme
                // 1 : light theme
            }
            catch
            {
            }

            if (_theme == 0)
            {
                this.Icon = Properties.Resources.CalendarToolDark;
            }

            if (_theme == 1)
            {
                this.Icon = Properties.Resources.CalendarToolLight;
            }

            this.notifyIcon1.Icon = this.Icon;

        }

        private const int infoWidth = 266;
        private const int calendarWidth = 253;

        private void HideInfo()
        {
            this.btnD.Visible = false;

            //this.richTextBox1.Width = 0;
            this.checkedListBox1.Width = 0;

            this.Width = calendarWidth;

            this.LocationBottomRight();
        }

        private void ShowInfo()
        {
            this.btnD.Visible = true;

            //this.richTextBox1.Width = infoWidth;
            this.checkedListBox1.Width = infoWidth;
            this.Width = infoWidth + calendarWidth;

            this.LocationBottomRight();
        }

        private void LocationBottomRight()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }

        private string GetText(Boolean isTitle, DateTime dateStart, DateTime dateEnd)
        {
            System.Globalization.Calendar calendar = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;

            int weekStart = calendar.GetWeekOfYear(dateStart, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int quarterStart = (dateStart.Month - 1) / 3 + 1;
            string dayStart = dateStart.ToString("dd-MM");
            string dayOfWeekStart = FirstCharToUpper(dateStart.ToString("dddd")).Substring(0, 3);

            int weekEnd = calendar.GetWeekOfYear(dateEnd, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int quarterEnd = (dateEnd.Month - 1) / 3 + 1;
            string dayEnd = dateEnd.ToString("dd-MM");
            string dayOfWeekEnd = FirstCharToUpper(dateEnd.ToString("dddd")).Substring(0, 3);

            string calculation = this.GetCalculation(dateStart, dateEnd);

            string text = string.Empty;
            if (isTitle)
            {
                if (dateStart.Date == dateEnd.Date)
                {
                    text = string.Format("Q{0} W{1} {2} {3}", quarterStart, weekStart, dayStart, dayOfWeekStart);
                }
                else
                {
                    text = string.Format("Q{0} W{1} {2} {3} - Q{4} W{5} {6} {7} ({8})", quarterStart, weekStart, dayStart, dayOfWeekStart, quarterEnd, weekEnd, dayEnd, dayOfWeekEnd, calculation);
                }
            }
            else
            {
                if (dateStart.Date == dateEnd.Date)
                {
                    text = string.Format("Q{0}\nW{1}\n{2} {3}", quarterStart, weekStart, dayStart, dayOfWeekStart);
                }
                else
                {
                    text = string.Format("Q{0}\nW{1}\n{2} {3}\n-\nQ{4}\nW{5}\n{6} {7}", quarterStart, weekStart, dayStart, dayOfWeekStart, quarterEnd, weekEnd, dayEnd, dayOfWeekEnd);
                }
            }

            return text;
        }

        private string GetCalculation(DateTime dateStart, DateTime dateEnd)
        {
            string text = string.Empty;

            TimeSpan timeSpan = dateEnd.Subtract(dateStart);

            text = string.Format("D{0}", timeSpan.Days + 1);

            return text;
        }

        private string GetCalendarItemsText(DateTime dateStart, DateTime dateEnd)
        {
            string text = string.Empty;

            SortedList<DateTime, string> calendarItems = new();

            foreach (var item in _calendar.Items)
            {
                if (item.Datetime.Date >= dateStart.Date && item.Datetime.Date <= dateEnd.Date)
                {
                    text = string.Empty;
                    text += item.Tag;
                    text += ": ";
                    /*
                    if (!string.IsNullOrEmpty(item.Group))
                    {
                        text += item.Group;
                        text += "- ";
                    }
                    */
                    text += item.Info;
                    text += Environment.NewLine;

                    calendarItems.Add(item.Datetime, text);
                }
            }

            text = string.Empty;
            foreach (var item in calendarItems)
            {
                text += item.Key.ToString("s");
                text += Environment.NewLine;
                text += item.Value;
                text += Environment.NewLine;
            }

            return text;
        }

        private string GetCalendarDatesFile()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = Path.GetDirectoryName(path);
            string file = Path.Combine(directory, "CalendarTool.json");

            return file;
        }

        private void LoadCalendarDates()
        {
            string file = this.GetCalendarDatesFile();

            if (!File.Exists(file))
            {
                // create an empty dates file
                _calendar = new Calendar();
                this.SaveCalendarDates();
            }
            else
            {
                string json = File.ReadAllText(file);
                _calendar = JsonSerializer.Deserialize<Calendar>(json);
                _calendar.ApplyOwner();
            }

        }

        private void ShowCalendarDatesRange(DateTime dateStart, DateTime dateEnd)
        {
            ((ListBox)this.checkedListBox1).DataSource = _calendar.SortedItems(dateStart, dateEnd);
            ((ListBox)this.checkedListBox1).DisplayMember = "Title";
            ((ListBox)this.checkedListBox1).ValueMember = "IsChecked";
        }

        private void SaveCalendarDates()
        {
            string file = this.GetCalendarDatesFile();
            string json = JsonSerializer.Serialize<Calendar>(_calendar);
            File.WriteAllText(file, json);
        }

        private void ShowCalendarDates()
        {
            this.monthCalendar1.SuspendLayout();
            this.monthCalendar1.RemoveAllBoldedDates();
            foreach (var item in _calendar.Items)
            {
                monthCalendar1.AddBoldedDate(item.Datetime);
            }
            this.monthCalendar1.ResumeLayout();
        }

        private void SetToday()
        {
            DateTime next1 = DateTime.Now.Date;

            SetDate(next1, next1, true);
        }

        private void SetDate(DateTime dateStart, DateTime dateEnd, Boolean setDate = false)
        {
            DateTime minDate = new(dateStart.Year, dateStart.Month, 1);

            DateTime controlMinDate = this.monthCalendar1.MinDate;

            this.monthCalendar1.MinDate = minDate;
            this.monthCalendar1.MinDate = controlMinDate;

            if (setDate)
            {
                this.monthCalendar1.SetDate(dateStart);
            }

            this.Text = GetText(true, this.monthCalendar1.SelectionStart, this.monthCalendar1.SelectionEnd);
            this.label1.Text = this.Text;

            //this.richTextBox1.Text = GetCalendarItemsText(this.monthCalendar1.SelectionStart, this.monthCalendar1.SelectionEnd);

            this.ShowCalendarDatesRange(dateStart, dateEnd);
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            string text = GetText(false, this.monthCalendar1.SelectionStart, this.monthCalendar1.SelectionEnd);
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

            SetDate(next1, next1, true);
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

            SetDate(next1, next1, true);
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
            SetDate(next1, next1, true);
        }

        private void btnQ4_Click(object sender, EventArgs e)
        {
            DateTime next1;

            next1 = new DateTime(DateTime.Now.Year, 10, 1);

            SetDate(next1, next1, true);
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
            SetDate(e.Start, e.Start);
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            // toggle
            if (this.checkedListBox1.Width > 0)
            {
                this.HideInfo();
            }
            else
            {
                this.ShowInfo();
            }
        }

        public static string FirstCharToUpper(string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            SetDate(e.Start, e.End);
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                SelectionRange selectionRange = this.monthCalendar1.SelectionRange;

                DateTime i = selectionRange.Start;
                while (i <= selectionRange.End)
                {
                    CalendarItem item = new()
                    {
                        Tag = this.textBox1.Text.Trim(),
                        Info = "selectie",
                        Datetime = i
                    };
                    i = i.AddDays(1);

                    _calendar.AddCalendarItem(item);
                }

                this.SaveCalendarDates();
                this.ShowCalendarDates();
                this.ShowCalendarDatesRange(this.monthCalendar1.SelectionStart, this.monthCalendar1.SelectionEnd);

            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in this.checkedListBox1.CheckedItems)
            {
                _calendar.RemoveCalendarItem(selectedItem as CalendarItem);
            }

            this.SaveCalendarDates();
            this.ShowCalendarDates();
            this.ShowCalendarDatesRange(this.monthCalendar1.SelectionStart, this.monthCalendar1.SelectionEnd);
        }
    }
}
