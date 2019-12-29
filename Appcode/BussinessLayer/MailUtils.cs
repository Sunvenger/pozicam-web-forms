using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
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