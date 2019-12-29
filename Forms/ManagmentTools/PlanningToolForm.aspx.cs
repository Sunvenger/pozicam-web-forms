using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.BussinessLayer;
using pozicam_web_forms.Appcode.Models;
namespace pozicam_web_forms.Forms.ManagmentTools
{
    public partial class PlanningToolForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AppSecurity.CheckAdmin(Session["CurrentUser"] as User))
            {
                formPleaseLogin.Visible = false;
                panelPlanningTool.Visible = true;
            }
            else
            {
                formPleaseLogin.Visible = true;
                panelPlanningTool.Visible = false;
            }
        }
    }
}