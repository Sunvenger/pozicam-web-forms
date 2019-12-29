using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.BussinessLayer;
using pozicam_web_forms.Appcode.Models;
using System.Text;

namespace pozicam_web_forms.Forms
{
    public partial class PleaseVerifyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {
                if ((Session["CurrentUser"] as Appcode.Models.User).IsVerified == true)
                {
                    if (Session["urlToBackup"] != null)
                    {
                        Response.Redirect(Session["urlToBackup"] as string);
                    }
                    else
                    {
                        Response.Redirect("/default.aspx");
                    }
                }

            }
        }

        protected void btnResend_Click(object sender, EventArgs e)
        {

            string UserEmail = (Session["CurrentUserUnverified"] as pozicam_web_forms.Appcode.Models.User).Email;
            pozicam_web_forms.Appcode.Models.User DbUser;
            using (var context = new pozicamskEntities())
            {
                DbUser = (from user in context.User
                          where user.Email == UserEmail
                          select user).ToList().First();
                DbUser.ActivationKey = MailUtils.VerifyUser(DbUser.Email);
                context.SaveChanges();
            }
        }

    }
}