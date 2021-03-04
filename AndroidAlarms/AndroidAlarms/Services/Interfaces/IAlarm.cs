using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidAlarms.Services.Interfaces
{
    public interface IAlarm
    {
        void SetAlarm(int hour, int minute, string message);
        void SetAlarm(TimeSpan time, string message);
        void SetDayOfWeekAlarm(DateTime dateAndTime, string message);
    }
}
