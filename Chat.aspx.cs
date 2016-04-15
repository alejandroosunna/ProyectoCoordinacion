using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chat : System.Web.UI.Page
{
    private static string nombre;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdUsuario"] == null)
        {
            Response.Redirect("~\\Login.aspx");
        }
        nombre = null;
        csUsuario usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"]));
        nombre = usuario.Nombre + " " + usuario.Apellidos + " (" + usuario.IdUsuario + ")";
        if (usuario.IdRol == 1)
        {
            nombre = "[Coordinador]" + usuario.Nombre +" " +usuario.Apellidos;
        }
        usuario = null;
        
    }

    [WebMethod]
    public static string ObtenerUsuario()
    {
        string jsondata;
        jsondata = JsonConvert.ToString(nombre);
        return jsondata;
    }

}