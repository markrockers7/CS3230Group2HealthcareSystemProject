using System;
using System.Collections.Generic;

namespace HealthcareSystemProjectCS3230.model
{
    public static class AppointmentSlotRules
    {
        public static readonly TimeSpan StartTime = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan EndTime = new TimeSpan(16, 45, 0);
        public const int SlotIntervalMinutes = 15;

        public static List<TimeSpan> GetDailySlots()
        {
            var slots = new List<TimeSpan>();
            for (TimeSpan current = StartTime; current <= EndTime; current = current.Add(TimeSpan.FromMinutes(SlotIntervalMinutes)))
            {
                slots.Add(current);
            }

            return slots;
        }

        public static bool IsValidSlotDateTime(DateTime appointmentDateTime)
        {
            TimeSpan time = appointmentDateTime.TimeOfDay;
            if (time < StartTime || time > EndTime)
            {
                return false;
            }

            return appointmentDateTime.Second == 0 && appointmentDateTime.Minute % SlotIntervalMinutes == 0;
        }
    }
}
