using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Alumno : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["IdUsuario"] != null && Session["IdRol"] != null)
        {
            if (Convert.ToInt32(Session["IdRol"]) == 2)
            {

                bool result = bool.TryParse(Request["IdLogin"], out result);
                if (result)
                {
                    Session["IdUsuario"] = null;
                    Session["IdRol"] = null;
                    Response.Redirect("~\\Login.aspx");
                }
                else
                {
                    

                }
            }
            else
                Response.Redirect("~\\IndexAdmin.aspx");
        }
        else
            Response.Redirect("~\\Login.aspx");

    }
}
