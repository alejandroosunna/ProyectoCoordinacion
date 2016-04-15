using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdUsuario"] != null)
        {
            csUsuario Usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"]));

            if(Usuario.IdRol == 1)
                Response.Redirect("~\\IndexAdmin.aspx");
            else if(Usuario.IdRol == 2)
                Response.Redirect("~\\IndexAlumno.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int result;
        if (Int32.TryParse(txtNumControl.Text, out result))
        {
            csUsuario Usuario = (new csUsuarioHandler()).CheckLogin(result, txtContraseña.Text);
            //(new ObjetoBase()).LogError(Usuario.IdRol.ToString());

            if (Usuario.IdRol == 1)
            {
                Session["IdUsuario"] = Usuario.IdUsuario;
                Session["IdRol"] = Usuario.IdRol;
                Session["IdCarrera"] = Usuario.IdCarrera;
                Response.Redirect("~\\IndexAdmin.aspx");
            }
            else if (Usuario.IdRol == 2)
            {
                Session["IdUsuario"] = Usuario.IdUsuario;
                Session["IdRol"] = Usuario.IdRol;
                Session["IdCarrera"] = Usuario.IdCarrera;
                Response.Redirect("~\\IndexAlumno.aspx");
            }
            else if (Usuario.IdRol == 0)
                Response.Write(@"<script language = 'javascript'>alert('Credenciales incorrectas') </script>");
        }
        else
            Response.Write(@"<script language = 'javascript'>alert('Credenciales incorrectas') </script>");
    }
}