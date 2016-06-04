using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["IdUsuario"] != null && Session["IdRol"] != null)
        {
            if (Convert.ToInt32(Session["IdRol"]) == 1 )
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
                    csUsuario Usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"]));                    
                    lblNombre.Text = "Coordinador: " + Usuario.Nombre + " " + Usuario.Apellidos + ".";
                }
            }
            else if (Convert.ToInt32(Session["IdRol"]) == 3)
                Response.Redirect("~\\IndexSAdmin.aspx");
            else if(Convert.ToInt32(Session["IdRol"]) == 2)
                Response.Redirect("~\\IndexAlumno.aspx");
            else
                Response.Redirect("~\\Login.aspx");
        }
        else
            Response.Redirect("~\\Login.aspx");
    }
    protected void ClickSalir()
    {
        
    }

    protected void Salir_Click(object sender, EventArgs e)
    {
        Session["IdUsuario"] = null;
        Response.Redirect("~\\Login.aspx");
    }
}
