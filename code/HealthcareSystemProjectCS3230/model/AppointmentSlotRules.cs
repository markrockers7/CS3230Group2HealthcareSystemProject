using System;
using System.Collections.Generic;

namespace HealthcareSystemProjectCS3230.model
{
    public static class AppointmentSlotRules
    {
        public static readonly TimeSpan StartTime = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan EndTime = new TimeSpan(16, 45, 0);
        public const int SlotIntervalMinutes = 15;

        /// <summary>
        /// Returns a list of all available appointment slots for a given doctor in 15 minute intervals between 8:00 AM and 4:45 PM.
        /// </summary>
        /// <returns>A list of available appointment slots.</returns>
        public static List<TimeSpan> GetDailySlots()
        {
            var slots = new List<TimeSpan>();
            for (TimeSpan current = StartTime; current <= EndTime; current = current.Add(TimeSpan.FromMinutes(SlotIntervalMinutes)))
            {
                slots.Add(current);
            }

            return slots;
        }
        /// <summary>
        /// Validates if a given DateTime is a valid appointment slot.
        /// </summary>
        /// <param name="appointmentDateTime">The DateTime to validate.</param>
        /// <returns>true if the DateTime is a valid appointment slot, false otherwise.</returns>
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
