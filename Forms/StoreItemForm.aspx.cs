using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using pozicam_web_forms.Appcode.BussinessLayer;
namespace pozicam_web_forms.Forms
{
    public partial class StoreItemForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var mode = Request.QueryString.Get("mode");
                if (mode != null)
                {

                    string urlToBackup = Request.RawUrl.ToString();
                    Session["urlToBackup"] = urlToBackup;
                    if (mode == "new")
                    {
                        if (AppSecurity.CheckUser(Session["CurrentUser"] as User))
                        {
                            panelNotLoggedIn.Visible = false;
                            panelNew.Visible = true;
                            lblHeader.Text = "Pridanie nového inzerátu";
                            UpdateCategoryList();

                        }
                        else
                        {
                            panelNotLoggedIn.Visible = true;
                        }

                    }
                }
            }
        }
        private void UpdateCategoryList()
        {
            var context = new pozicamskEntities();
            var categories = context.Category.ToList();
            ddCategory.DataSource = categories;
            ddCategory.DataTextField = "Name";
            ddCategory.DataValueField = "Id";
            ddCategory.DataBind();

            
        }
    }
}