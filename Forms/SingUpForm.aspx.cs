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
    public partial class SingUpForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (AppSecurity.CheckUser(Session["CurrentUser"] as User))
            {
                panelNew.Visible = false;
                if (Session["UrlToBackup"] != null)
                {
                    Response.Redirect(Session["UrlToBackup"] as string);
                }
                else
                {
                    Response.Redirect("~/default.aspx");
                }
            }

        }

        protected void tbPasswordComfirm_TextChanged(object sender, EventArgs e)
        {
            ViewState["PasswordConfirm"] = tbPasswordComfirm.Text;
            tbPassword.Attributes["Placeholder"] = "••••••••";
            tbPasswordComfirm.Attributes["Placeholder"] = "••••••••";
            if ((tbPassword.Text) == (tbPasswordComfirm.Text))
            {
                lbPasswordAreSame.Visible = true;
                lbPasswordAreNotSame.Visible = false;
                btnRegistrate.Enabled = true;
            }
            else
            {
                btnRegistrate.Enabled = false;
                lbPasswordAreSame.Visible = false;
                lbPasswordAreNotSame.Visible = true;
            }
        }


        protected void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegistrate_Click(object sender, EventArgs e)
        {

            if ((tbPassword.Text) == (tbPasswordComfirm.Text))
            {
                CreateDraftUser();

            };
        }

        private void CreateDraftUser()
        {



            List<pozicam_web_forms.Appcode.Models.User> duplicates;
            using (var context = new pozicamskEntities())
            {
                var query = from usr in context.User
                            where usr.Email == tbEmail.Text
                            select usr;

                duplicates = query.ToList<User>();
            }
            if (duplicates.Count == 0)
            {


                var newUser = new pozicam_web_forms.Appcode.Models.User
                {
                    Email = tbEmail.Text,
                    Password = ViewState["PasswordConfirm"].ToString(),
                    IsVerified = false,
                };

                using (var context = new pozicamskEntities())
                {
                    string key = MailUtils.VerifyUser(newUser.Email);
                    newUser.ActivationKey = key;
                    context.User.Add(newUser);
                    context.SaveChanges();
                    Response.Redirect("ThanksForRegistrationForm.aspx");
                }
            }
            else
            {

                tbEmail.CssClass = "cssTextBoxBad";
                lblBadMail.Visible = true;
            }
        }
    }
}