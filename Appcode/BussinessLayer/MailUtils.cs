using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using pozicam_web_forms.Appcode.BussinessLayer;
using pozicam_web_forms.Appcode.Models;

namespace pozicam_web_forms.Appcode.BussinessLayer
{
    public class MailUtils
    {

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static string VerifyUser(string emailAddress)
        {
            String randomCode = RandomString(20);
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("info@pozicam.sk", "s2!e3UPkTf");
            string url = $@"https://pozicam.sk/forms/MailActivationForm?key={randomCode}&mail={emailAddress}";
            string body = $@"Dobrý deň, Pre overenie kliknite na následujúci link: <a href=""{url}"">Chcem aktivovať účet</a>";
            MailMessage msg = new MailMessage("info@pozicam.sk", emailAddress, "Potvrdenie registrácie", body);
            msg.IsBodyHtml = true;
            smtp.Host = "smtp.forpsi.com";
            smtp.Send(msg);
            return randomCode;
        }

        public static void SendApprovementRequest(ManagmentTask task)
        {
            var admins = new List<User>();
            using (var context = new pozicamskEntities())
            {
                admins = (from users in context.User
                          where users.IsAdmin == true
                          select users).ToList();


                foreach (var admin in admins)
                {
                    String randomCode = RandomString(20);
                    admin.ActivationKey = randomCode;
                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("info@pozicam.sk", "s2!e3UPkTf");
                    string url = $@"https://www.pozicam.sk/Forms/ManagmentTools/PlanningToolForm.aspx?taskid={task.Id}";
                    string body = $@"Dobrý deň, Bola pridaná nová úloha: ""{task.Name}"" : <a href=""{url}"">Spravovať úlohu</a>";
                    MailMessage msg = new MailMessage("info@pozicam.sk", admin.Email, "Niekto zadal novú úlohu", body);
                    msg.IsBodyHtml = true;
                    smtp.Host = "smtp.forpsi.com";
                    smtp.Send(msg);

                }
            }
        }


        public static void SendApprovementComfirmation(ManagmentTask input_task)
        {

            using (var context = new pozicamskEntities())
            {

                //taskOwner
                var userId = (from task in context.ManagmentTask
                              where task.Id == input_task.Id
                              select task.CreatorUserId).FirstOrDefault();
                string ownerEmail = (from user in context.User
                                 where user.Id == userId
                                 select user.Email).FirstOrDefault();

                String randomCode = RandomString(20);

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("info@pozicam.sk", "s2!e3UPkTf");
                string url = $@"https://www.pozicam.sk/Forms/ManagmentTools/PlanningToolForm.aspx?taskid={input_task.Id}";
                string body = $@"Dobrý deň, Bola Bola schválená úloha, ktorú ste vytvorili: ""{input_task.Name}"" : <a href=""{url}"">Zobraziť úlohu</a>";
                MailMessage msg = new MailMessage("info@pozicam.sk", ownerEmail, "Vaša úloha bola schválená", body);
                msg.IsBodyHtml = true;
                smtp.Host = "smtp.forpsi.com";
                smtp.Send(msg);


            }
        }
        public static void CreateTestMessage2(string server)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("info@pozicam.sk", "s2!e3UPkTf");
            smtp.Host = "smtp.forpsi.com";
            smtp.Send("info@pozicam.sk", "sunvenger@gmail.com", "tst", "tstBody");
        }
    }

}