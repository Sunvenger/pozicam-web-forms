using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.BussinessLayer;
using pozicam_web_forms.Appcode.Models;
using System.Text;
namespace pozicam_web_forms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ShowLoginError"] != null)
            {
                if (Request.QueryString["ShowLoginError"] == "true")
                {
                    panelPopup.Visible = true;
                }
            }
            if (!IsPostBack)
            {



                if (Session["CurrentUser"] == null)
                {
                    btnLogin.Visible = true;
                    btnLogOut.Visible = false;
                }
                else
                {
                    lblUserMail.Visible = true;
                    lblUserMail.Text = (Session["CurrentUser"] as User).Email;
                    btnLogOut.Visible = true;
                    btnLogin.Visible = false;
                }


            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            panelPopup.Visible = false;
        }

        protected void btnProceedLogin_Click(object sender, EventArgs e)
        {

        }

        protected void OnLoginFail()
        {
            panelPopup.Visible = true;
        }
        protected void OnLoginSuccess()
        {
            panelPopup.Visible = false;
            lblUserMail.Visible = true;
            lblUserMail.Text = (Session["CurrentUser"] as User).Email;

        }

        protected bool Login()
        {

            string userEmail = tbEmailLogin.Text;
            string userPassword = ViewState["LoginPassword"] as String;

            var context = new pozicamskEntities();
            var result = (from user in context.User
                          where user.Email == tbEmailLogin.Text
                          where user.Password == userPassword
                          select user).ToList();
            if (result.Count == 1)
            {
                if (result[0].IsVerified == true)
                {
                    Session["CurrentUser"] = result[0];
                    OnLoginSuccess();
                    return true;
                }
                else
                {//user is not verified
                    Session["CurrentUserUnverified"] = result[0];

                    string urlToBackup = Request.RawUrl.ToString();
                    Session["urlToBackup"] = urlToBackup;
                    Response.Redirect(@"~/forms/pleaseverifyForm.aspx");
                }

            }
            else
            {
                OnLoginFail();
            }

            //      var blogs = from b in context.Blogs
            //where b.Name.StartsWith("B")
            //select b;

            return false;
        }

        protected void tbPassword_TextChanged(object sender, EventArgs e)
        {
            ViewState["LoginPassword"] = (sender as TextBox).Text;

            panelLogin.Visible = false;
            string url = Request.RawUrl.ToString();
            if (Login())
            {
                lblUserMail.Visible = true;
                lblUserMail.Text = (Session["CurrentUser"] as User).Email;
                url = url.Replace("?ShowLoginError=true", "");
                url = url.Replace("&ShowLoginError=true", "");
                Response.Redirect(url); // redirect on itself
            }
            else
            {
                if (!url.Contains("?ShowLoginError"))

                {

                    if (url.Contains("?"))
                    {
                        Response.Redirect(url + $"&ShowLoginError=true");
                    }
                    else
                    {
                        Response.Redirect(url + $"?ShowLoginError=true"); // redirect on itself
                    }
                }
            }

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["CurrentUser"] = null;
            string url = Request.RawUrl.ToString();
            lblUserMail.Visible = false;
            Response.Redirect(url); // redirect on itself

        }
    }
}