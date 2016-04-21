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
       
        
    }

    [WebMethod]
    public static string ObtenerUsuario(string usu)
    {
        string jsondata = "";
        csUsuario usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(usu));
        if (usuario.IdRol == 1)
        {
            jsondata = usuario.IdCarrera +" "+ "[Coordinador]" + usuario.Nombre + " " + usuario.Apellidos;
        }else
        {
            jsondata = usuario.IdCarrera + " " + usuario.Nombre +" "+ usuario.Apellidos;
        }
        
        jsondata = JsonConvert.ToString(jsondata);
        return jsondata;
    }

}