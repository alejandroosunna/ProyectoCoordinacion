using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eliminar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdUsuario"] == null || Convert.ToInt32(Session["IdRol"]) == 2)
            Response.Redirect("~\\Login.aspx");

    }
    protected void GridView_Usuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            (new csUsuarioHandler()).DeleteUsuario(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("~\\Eliminar.aspx");
        }
    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["IdAdministrador"] = null;
        Response.Redirect("~\\Login.aspx");
    }

    protected void GridView_Usuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView_Usuarios.SelectedRow;

        int id = Convert.ToInt32(GridView_Usuarios.DataKeys[row.RowIndex].Value);
        if ((new csUsuarioHandler().DeleteUsuario(id)))
        {
            Response.Redirect("~\\Eliminar.aspx");
        }
        else
        {

        }
        (new ObjetoBase()).LogError(id.ToString());
    }
    protected void EliminaT_Click(object sender, EventArgs e)
    {
        string NombreTabla = "tbUsuarios";
        try
        {
            string idcarrer = Session["IdCarrera"].ToString();
            String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            string Query = "DELETE FROM " + NombreTabla + " WHERE IdRol = 2 and IdCarrera = " + idcarrer;

            myConnection.Open();
            SqlCommand cmd = new SqlCommand(Query, myConnection);
            cmd.ExecuteNonQuery();
            myConnection.Close();

        }
        catch (Exception ex)
        {
            Response.Write(@"<script language = 'javascript'>alert('Error al eliminar. Es posible que la base de datos este vacia.') </script>");

        }
        Response.Write(@"<script language = 'javascript'>alert('Eliminado correctamente.') </script>");
        Response.Redirect("~\\Eliminar.aspx");

    }
}