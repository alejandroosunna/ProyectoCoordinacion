using Newtonsoft.Json;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
>>>>>>> refs/remotes/origin/master
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
<<<<<<< HEAD
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
=======
       
        
    }

    [WebMethod]
    public static string ObtenerUsuario(string usu)
    {
        string jsondata = "";
        csUsuario usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(usu));
        if (usuario.IdRol == 1)
        {
            jsondata = usuario.Nombre + " " + usuario.Apellidos + " [Coordinador]" ;
        }else
        {
            jsondata = usuario.Nombre +" "+ usuario.Apellidos;
        }
        
        jsondata = JsonConvert.ToString(jsondata);
        return jsondata;
    }

    [WebMethod]
    public static string ObtenerCarrera(string id)
    {
        string jsondata = null;
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        using (var con = new SqlConnection(ConnectionString))
        {
            con.Open();

            SqlParameter Data = new SqlParameter("@idCarrera", id);
            Data.DbType = DbType.Int32;

            var query = "select Nombre from tbCarreras where IdCarrera = @idCarrera";

            SqlCommand Command = new SqlCommand(query, con);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {

                jsondata = JsonConvert.ToString(DataReader["Nombre"]);

                return jsondata;
            }
            else
            {
                return jsondata;
            }
        }
>>>>>>> refs/remotes/origin/master
    }

}