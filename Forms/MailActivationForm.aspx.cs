using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.BussinessLayer;
using pozicam_web_forms.Appcode.Models;

namespace pozicam_web_forms.Forms
{
    public partial class MailActivationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //activate mail
            //redirect back
            string email = Request.QueryString["mail"];
            string key = Request.QueryString["mail"];

            using (var context = new pozicamskEntities())
            {

                var dbUser = (from usr in context.User
                 where usr.Email == email
                 select usr).First();
                dbUser.IsVerified = true;
                context.SaveChanges();
            }

                Response.Redirect("/default.aspx");
        }
    }
}