using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pozicam_web_forms.Appcode.Models;

namespace pozicam_web_forms.Appcode.BussinessLayer
{
    public class MainEvents
    {
        public static void UpdateEvent(object session)
        {
            ProcessEmailReminders();
        }

        public static void ProcessEmailReminders()
        {
            using (var context = new pozicamskEntities())
            {
                var remindersToCheck = (from reminders in context.EmailReminder
                                        where reminders.IsSent == false &&
                                        reminders.TriggerTime <= DateTime.Now
                                        select reminders);
                foreach (var reminder in remindersToCheck)
                {
                    reminder.IsSent = true;
                    MailUtils.SendReminder(reminder);
                }
                context.SaveChanges();
            }
        }
    }
}