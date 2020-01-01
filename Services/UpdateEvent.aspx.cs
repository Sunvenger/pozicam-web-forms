using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.BussinessLayer;

namespace pozicam_web_forms.Services
{
    public partial class UpdateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MainEvents.UpdateEvent(Session);
        }
    }
}