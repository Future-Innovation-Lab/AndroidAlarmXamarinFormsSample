using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidAlarms.Services.Interfaces;
using Java.Lang;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidAlarms.Droid.Services.AndroidAlarm))]
namespace AndroidAlarms.Droid.Services
{
    public class AndroidAlarm : IAlarm
    {
        public void SetAlarm(int hour, int minute, string message)
        {
            var context = Android.App.Application.Context;
            Intent intent = new Intent(AlarmClock.ActionSetAlarm);
            intent.PutExtra(AlarmClock.ExtraHour, hour);
            intent.PutExtra(AlarmClock.ExtraMinutes, minute);
            intent.PutExtra(AlarmClock.ExtraMessage, message);
            intent.PutExtra(AlarmClock.ExtraSkipUi, true);
            context.StartActivity(intent);
        }

        public void SetAlarm(TimeSpan time, string message)
        {
            var context = Android.App.Application.Context;
            Intent intent = new Intent(AlarmClock.ActionSetAlarm);
            intent.PutExtra(AlarmClock.ExtraHour, time.Hours);
            intent.PutExtra(AlarmClock.ExtraMinutes, time.Minutes);
            intent.PutExtra(AlarmClock.ExtraMessage, message);
            intent.PutExtra(AlarmClock.ExtraSkipUi, true);
            context.StartActivity(intent);
        }

        public void SetDayOfWeekAlarm(DateTime dateAndTime, string message)
        {
            ArrayList alarmDays = new ArrayList();

            switch (dateAndTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    alarmDays.Add(Calendar.Monday);
                    break;
                case DayOfWeek.Tuesday:
                    alarmDays.Add(Calendar.Tuesday);
                    break;
                case DayOfWeek.Wednesday:
                    alarmDays.Add(Calendar.Wednesday);
                    break;
                case DayOfWeek.Thursday:
                    alarmDays.Add(Calendar.Thursday);
                    break;
                case DayOfWeek.Friday:
                    alarmDays.Add(Calendar.Friday);
                    break;
                case DayOfWeek.Saturday:
                    alarmDays.Add(Calendar.Saturday);
                    break;
                case DayOfWeek.Sunday:
                    alarmDays.Add(Calendar.Sunday);
                    break;


            }

            var context = Android.App.Application.Context;
            Intent intent = new Intent(AlarmClock.ActionSetAlarm);
            intent.PutExtra(AlarmClock.ExtraHour, dateAndTime.Hour);
            intent.PutExtra(AlarmClock.ExtraMinutes, dateAndTime.Minute);
            intent.PutExtra(AlarmClock.ExtraMessage, message);
            intent.PutExtra(AlarmClock.ExtraDays, alarmDays);
            intent.PutExtra(AlarmClock.ExtraSkipUi, true);
            context.StartActivity(intent);
        }
    }
}