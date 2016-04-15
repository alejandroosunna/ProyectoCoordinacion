using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexAdmin : System.Web.UI.Page
{
    List<int> seleccionados = new List<int>();

    DateTime fechaInicio;
    DateTime fechaFinal;
    int idCarrera;
    public DataTable dt;
    public bool result;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Fecha"] == null)
        {
            fechaInicio = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy") + " 12:00:00 AM");
            fechaFinal = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy") + " 11:59:59 PM");
            idCarrera = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"])).IdCarrera;
        }
        else
        {
            try
            { fechaInicio = Convert.ToDateTime(Convert.ToDateTime(Request["Fecha"]).ToString("dd/MM/yyyy") + " 12:00:00 AM");

                fechaFinal = Convert.ToDateTime(Convert.ToDateTime(Request["Fecha"]).ToString("dd/MM/yyyy") + " 11:59:59 PM");
                idCarrera = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"])).IdCarrera;
            }
            catch(Exception ex)
            {

            }
        }

        List<csCita> listCita = listCita = (new csCitaHandler()).GetListCitas(idCarrera, fechaInicio, fechaFinal);

        dt = new DataTable();
        dt.Columns.Add("IdCita");
        dt.Columns.Add("IdUsuario");
        dt.Columns.Add("FechaDisponible");
        dt.Columns.Add("Estado");

        for (int y = 0; y < listCita.Count; y++)
        {
            DataRow dr = dt.NewRow();
            dr["IdCita"] = listCita[y].IdCita.ToString();
            dr["IdUsuario"] = listCita[y].IdUsuario.ToString();
            dr["FechaDisponible"] = listCita[y].FechaDisponible.ToString("t");
            dr["Estado"] = "Pendiente";

            dt.Rows.Add(dr);
        }

        GridView_Citas.DataSource = dt;
        GridView_Citas.DataBind();
    }

    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["IdUsuario"] = null;
        Response.Redirect("~\\Login.aspx");
    }
    protected void GridView_Citas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            (new csCitaHandler()).DeleteCita(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("~\\IndexAdmin.aspx");
        }
    }
    protected void btnNuevaCita_Click(object sender, EventArgs e)
    {
        Response.Redirect("~\\AgregarCita.aspx");
    }

    protected void GridView_Citas_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView_Citas.SelectedRow;

        int id = Convert.ToInt32(GridView_Citas.DataKeys[row.RowIndex].Value);

        if (!buscarRepetido(id))
        {
            seleccionados.Add(id);
        }
        
        
    }

    protected void SqlDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    private bool buscarRepetido(int id)
    {
     
        for (int i = 0; i < seleccionados.Count; i++)
        {
            if (seleccionados[i] == id)
            {
                seleccionados.Remove(i);
                return true;
            }
        }
        return false;
    }

    protected void btnElinarCitas_Click(object sender, EventArgs e)
    {
        foreach (var item in seleccionados)
        {
            (new csCitaHandler()).DeleteCita(item);
        }

        Response.Redirect("~\\IndexAdmin.aspx");
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //if(Request["Fecha"] != null)
        //{
        //    DateTime fechaInicio = Convert.ToDateTime(Convert.ToDateTime(Request["Fecha"]).ToString("dd/MM/yyyy") + " 12:00:00 AM");
        //    DateTime fechaFinal = Convert.ToDateTime(Convert.ToDateTime(Request["Fecha"]).ToString("dd/MM/yyyy") + " 11:59:59 PM");

        //    int idCarrera = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"])).IdCarrera;

        //    List<csCita> listCita = (new csCitaHandler()).GetListCitas(idCarrera, fechaInicio, fechaFinal);

        //    dt = new DataTable();
        //    dt.Columns.Add("IdCita");
        //    dt.Columns.Add("IdUsuario");
        //    dt.Columns.Add("FechaDisponible");
        //    dt.Columns.Add("Estado");

        //    for (int y = 0; y < listCita.Count; y++)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["IdCita"] = listCita[y].IdCita.ToString();
        //        dr["IdUsuario"] = listCita[y].IdUsuario.ToString();
        //        dr["FechaDisponible"] = listCita[y].FechaDisponible.ToString("t");
        //        dr["Estado"] = "Pendiente";

        //        dt.Rows.Add(dr);
        //    }

        //    GridView_Citas.DataSource = dt;
        //    GridView_Citas.DataBind();
        //}
    }
}