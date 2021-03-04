using AndroidAlarms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AndroidAlarms.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _alarmReason;

        public string AlarmReason
        {
            get { return _alarmReason; }
            set { _alarmReason = value; }
        }

        private TimeSpan _alarmTime;

        public TimeSpan AlarmTime
        {
            get { return _alarmTime; }
            set { _alarmTime = value; }
        }

        private DateTime _alarmDate;

        public DateTime AlarmDate
        {
            get { return _alarmDate; }
            set { _alarmDate = value; }
        }

        private int _alarmMinute;

        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set { _alarmMinute = value; }
        }

        private int _alarmHour;

        public int AlarmHour
        {
            get { return _alarmHour; }
            set { _alarmHour = value; }
        }

        public ICommand SetStandardAlarmCommand { get; set; }
        public ICommand SetDateTimeAlarmCommand { get; set; }
        public ICommand SetDateTimeDayOfWeekRecurringAlarmCommand { get; set; }

        public MainViewModel(INavigation navigation) : base(navigation)
        {
            SetStandardAlarmCommand = new Command(() => SetStandardAlarm());
            SetDateTimeAlarmCommand = new Command(() => SetDateTimeAlarm());
            SetDateTimeDayOfWeekRecurringAlarmCommand = new Command(() => SetDateTimeDayOfWeekRecurringAlarm());

            AlarmReason = "Test Alarm";

            AlarmHour = 10;
            var currentDate = DateTime.Now;
            AlarmTime = new TimeSpan(currentDate.Hour,currentDate.Minute,0);
            AlarmDate = DateTime.Now;
        }

        private void SetStandardAlarm()
        {
                var alarm = DependencyService.Get<IAlarm>();

                alarm.SetAlarm(AlarmHour, AlarmMinute, AlarmReason);
        }

        private void SetDateTimeAlarm()
        {
            var alarm = DependencyService.Get<IAlarm>();
            alarm.SetAlarm(AlarmTime, AlarmReason);
        }

        private void SetDateTimeDayOfWeekRecurringAlarm()
        {
            var alarm = DependencyService.Get<IAlarm>();
            alarm.SetDayOfWeekAlarm(AlarmDate, AlarmReason);
        }
    }
}