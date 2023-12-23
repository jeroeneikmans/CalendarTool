using System;
using System.Collections.Generic;

namespace CalendarTool
{
    internal class Calendar
    {
        public List<CalendarItem> Items { get; set; }
    }

    internal class CalendarItem
    {
        public string Group { get; set; }
        public DateTime Datetime { get; set; }
        public string Info { get; set; }
    }
}
