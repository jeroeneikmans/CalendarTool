using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

using Windows.Devices.Pwm;

namespace CalendarTool
{
    internal class Calendar
    {
        public List<CalendarItem> Items { get; set; } = new List<CalendarItem>();
        
        public void ApplyOwner()
        {
            foreach (var item in this.Items)
            {
                item.Owner = this;
            }
        }

        public void AddCalendarItem(CalendarItem calendarItem)
        {
            calendarItem.Owner = this;
            Items.Add(calendarItem);
        }

        public void RemoveCalendarItem(CalendarItem calendarItem)
        {
            Items.Remove(calendarItem);
        }

        public SortedList<DateTime, CalendarItem> Slice(DateTime dateStart, DateTime dateEnd)
        {
            SortedList<DateTime, CalendarItem> slice = new();

            foreach (var item in this.Items)
            {
                if (item.Datetime.Date >= dateStart.Date && item.Datetime.Date <= dateEnd.Date)
                {
                    slice.Add(item.Datetime, item);
                }
            }

            return slice;
        }

        public List<CalendarItem> SortedItems(DateTime dateStart, DateTime dateEnd)
        {
            List<CalendarItem> sortedItems = new();

            var slice = this.Slice(dateStart, dateEnd);

            foreach (var dt in slice) 
            {
                sortedItems.Add(dt.Value);
            }

            return sortedItems;
        }
    }

    internal class CalendarItem
    {
        [JsonIgnore]
        public Calendar Owner { get; set; }
        [JsonIgnore]
        public bool IsChecked { get; set; }
        public string Tag { get; set; }
        public DateTime Datetime { get; set; }
        public string Info { get; set; }

        public string Title => $"{this.Datetime:dd-MM} | {this.Info} | {this.Tag}";
    }
}