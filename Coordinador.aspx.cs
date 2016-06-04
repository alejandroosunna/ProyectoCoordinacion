using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Coordinador : System.Web.UI.Page
{
    DataTable dt;
    List<csUsuario> listUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Ad"] != null)
        {
            if (Request["Ad"].ToString() == "ex")
                Response.Write(@"<script language = 'javascript'>alert('Se agrego con exito.') </script>");
            else if (Request["Ad"].ToString() == "err")
                Response.Write(@"<script language = 'javascript'>alert('Error al Intentar Agregar.') </script>");
        }

        if (Request["De"] != null)
        {
            if (Request["De"].ToString() == "ex")
                Response.Write(@"<script language = 'javascript'>alert('Se elimino con exito.') </script>");
            else if (Request["De"].ToString() == "err")
                Response.Write(@"<script language = 'javascript'>alert('Error al eliminar.') </script>");
        }

        if (Request["Up"] != null)
        {
            if (Request["Up"].ToString() == "ex")
                Response.Write(@"<script language = 'javascript'>alert('Se edito con exito.') </script>");
            else if (Request["Up"].ToString() == "err")
                Response.Write(@"<script language = 'javascript'>alert('Error al editar.') </script>");
        }

        LlenarDrop();

        int IdRol = 3;
        listUsuario = (new csUsuarioHandler()).GetListUsuario(IdRol);
        IdRol = 1;
        listUsuario.AddRange((new csUsuarioHandler()).GetListUsuario(IdRol));

        dt = new DataTable();
        dt.Columns.Add("IdUsuario");
        dt.Columns.Add("Nombre");
        dt.Columns.Add("Carrera");
        dt.Columns.Add("Contraseña");

        for (int y = 0; y < listUsuario.Count; y++)
        {
            DataRow dr = dt.NewRow();
            dr["IdUsuario"] = listUsuario[y].IdUsuario.ToString();
            dr["Nombre"] = listUsuario[y].Nombre + " " + listUsuario[y].Apellidos;
            dr["Carrera"] = (new csCarreraHandler()).GetCarrera(listUsuario[y].IdCarrera).Nombre;
            dr["Contraseña"] = listUsuario[y].Contraseña;

            dt.Rows.Add(dr);
        }

        GridView_Coordinadores.DataSource = dt;
        GridView_Coordinadores.DataBind();
    }


    private void LlenarDrop()
    {
        DataTable carreras = new DataTable();
        SqlConnection con = new SqlConnection(SqlDataDropDListCarrera.ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM tbCarreras", con);
        SqlDataAdapter sql = new SqlDataAdapter(cmd);
        sql.Fill(carreras);
        con.Close();
        if (carreras.Rows.Count > 0)
        {
            int i = carreras.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                carreraDrop.Items.Add(carreras.Rows[j]["Nombre"].ToString());
                carreraDrop.Items[j].Value = carreras.Rows[j]["IdCarrera"].ToString();
            }
        }
    }
    protected void GridView_Coordinadores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            (new csCitaHandler()).DeleteCita(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("~\\IndexAdmin.aspx");
        }
        else if (e.CommandName == "Editar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            //(new ObjetoBase()).LogError(index.ToString());
            GridViewRow selectedRow = GridView_Coordinadores.Rows[index];
            TableCell citaObject = selectedRow.Cells[0];
            int idUsuario = Convert.ToInt32(citaObject.Text);

            Response.Redirect("~\\UCoordinador.aspx?Id=" + idUsuario);
        }
        else if (e.CommandName == "Eliminar")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            //(new ObjetoBase()).LogError(index.ToString());
            GridViewRow selectedRow = GridView_Coordinadores.Rows[index];
            TableCell citaObject = selectedRow.Cells[0];
            int idUsuario = Convert.ToInt32(citaObject.Text);

            if (!(new csUsuarioHandler()).DeleteUsuario(idUsuario))
                Response.Redirect("~\\Coordinador.aspx?De=ex");
            else
            Response.Redirect("~\\Coordinador.aspx?De=err");
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        csUsuario Usuario = new csUsuario();

        Usuario.IdUsuario = Convert.ToInt32(txtNumControl.Text);
        Usuario.Nombre = txtNombre.Text;
        Usuario.Apellidos = txtApellidos.Text;
        Usuario.IdRol = 1;
        Usuario.IdCarrera = Convert.ToInt32(carreraDrop.Value);
        Usuario.Contraseña = txtNumControl.Text;

        if(!(new csUsuarioHandler()).AddNewUsuario(Usuario))
            Response.Redirect("~\\Coordinador.aspx?Ad=ex");
        else
            Response.Redirect("~\\Coordinador.aspx?Ad=err");

    }
}