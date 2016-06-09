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
<<<<<<< HEAD
            if (Convert.ToInt32(Session["IdRol"]) == 1)
=======
            if (Convert.ToInt32(Session["IdRol"]) == 1 )
>>>>>>> refs/remotes/origin/master
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
<<<<<<< HEAD

                }
            }
            else
                Response.Redirect("~\\IndexAlumno.aspx");
=======
                }
            }
            else if (Convert.ToInt32(Session["IdRol"]) == 3)
                Response.Redirect("~\\IndexSAdmin.aspx");
            else if(Convert.ToInt32(Session["IdRol"]) == 2)
                Response.Redirect("~\\IndexAlumno.aspx");
            else
                Response.Redirect("~\\Login.aspx");
>>>>>>> refs/remotes/origin/master
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
