using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.Models;
namespace pozicam_web_forms.Services
{
    public partial class CreateReminderService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new pozicamskEntities())
            {
                context.EmailReminder.Add(new EmailReminder
                {
                    Body = "Reminder test",
                    CreationTime = DateTime.Now,
                    DestMailAddress = "sunvenger@gmail.com",
                    Name = "TestReminder",
                    IsSent = false,
                    SourceMailAddress = "info@pozicam.sk",
                    Subject = "pripomienka",
                    TriggerTime = DateTime.Now.AddSeconds(30)
                });
                context.SaveChanges();   
            }
        }
    }
}