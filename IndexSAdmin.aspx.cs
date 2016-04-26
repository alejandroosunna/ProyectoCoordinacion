using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexSAdmin : System.Web.UI.Page
{
    csUsuario Usuario;
    csCarrera Carrera;
    DateTime fechaInicio;
    DateTime fechaFinal;
    int idCarrera;
    public DataTable dt;
    public DataTable dtt;
    public bool result;

    protected void Page_Load(object sender, EventArgs e)
    {
        csUsuarioHandler UsuarioHandler = new csUsuarioHandler();
        csCitaHandler CitaHandler = new csCitaHandler();
        csCarreraHandler CarreraHandler = new csCarreraHandler();
        List<csCita> listCita = new List<csCita>();
        List<int> ListIdCarrera = new List<int>();
        int IdRol = 1;

        if (Request["CitaA"] != null)
        {
            if (Request["CitaA"] == "err")
                Response.Write(@"<script language = 'javascript'>alert('Error al finalizar cita.') </script>");
            else if (Request["CitaA"] == "ex")
                Response.Write(@"<script language = 'javascript'>alert('Cita finalizada con exito.') </script>");
        }
        else if (Request["CitaF"] != null)
        {
            if (Request["CitaF"] == "err")
                Response.Write(@"<script language = 'javascript'>alert('Error al finalizar cita.') </script>");
            else if (Request["CitaF"] == "ex")
                Response.Write(@"<script language = 'javascript'>alert('Cita finalizada con exito.') </script>");
        }

        //(new ObjetoBase()).LogError(txtNumControl.Text);
        if (txtNumControl.Text == "")
        {
            if (Request["Fecha"] == null)
            {
                fechaInicio = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy") + " 12:00:00 AM");
                fechaFinal = Convert.ToDateTime(DateTime.Today.ToString("dd/MM/yyyy") + " 11:59:59 PM");
                idCarrera = UsuarioHandler.GetUsuario(Convert.ToInt32(Session["IdUsuario"])).IdCarrera;
            }
            else
            {
                if (Request["Fecha"].ToString() != "")
                {
                    fechaInicio = Convert.ToDateTime(Convert.ToDateTime(Request["Fecha"]).ToString("dd/MM/yyyy") + " 12:00:00 AM");
                    fechaFinal = Convert.ToDateTime(Convert.ToDateTime(Request["Fecha"]).ToString("dd/MM/yyyy") + " 11:59:59 PM");
                    idCarrera = UsuarioHandler.GetUsuario(Convert.ToInt32(Session["IdUsuario"])).IdCarrera;
                }
            }

            if (fechaFinal.ToString("dd/MM/yyyy") != "01/01/0001" || txtNumControl.Text != "")
            {
                listCita = CitaHandler.GetListSuperAdmin(fechaInicio, fechaFinal);
                            
                dt = new DataTable();
                dt.Columns.Add("IdCita");
                dt.Columns.Add("Carrera");
                dt.Columns.Add("IdUsuario");
                dt.Columns.Add("FechaDisponible");
                dt.Columns.Add("Estado");

                for (int y = 0; y < listCita.Count; y++)
                {
                    DataRow dr = dt.NewRow();
                    dr["IdCita"] = listCita[y].IdCita.ToString();
                    //Usuario = UsuarioHandler.GetUsuario(listCita[y].IdUsuario, IdRol);
                    dr["Carrera"] = CarreraHandler.GetCarrera(listCita[y].IdCoordinador).Nombre;
                    if (!ListIdCarrera.Contains(listCita[y].IdCoordinador))
                        ListIdCarrera.Add(listCita[y].IdCoordinador);
                    //(new ObjetoBase()).LogError((new csUsuarioHandler()).GetUsuario(listCita[y].IdUsuario).IdCarrera.ToString());
                    dr["IdUsuario"] = listCita[y].IdUsuario.ToString();
                    dr["FechaDisponible"] = listCita[y].FechaDisponible.ToString();
                    if (listCita[y].Estado == 0)
                        dr["Estado"] = "Disponible";
                    else if (listCita[y].Estado == 1)
                        dr["Estado"] = "Ocupado";
                    else if (listCita[y].Estado == 2)
                        dr["Estado"] = "Expiro";
                    else if (listCita[y].Estado == 3)
                        dr["Estado"] = "Eliminado";

                    dt.Rows.Add(dr);
                }

                dtt = new DataTable();
                dtt.Columns.Add("Carrera");
                dtt.Columns.Add("Numero de Citas");
                dtt.Columns.Add("Numero de Citas Disponibles");
                dtt.Columns.Add("Numero de Citas Ocupadas");
                dtt.Columns.Add("Numero de Citas Expiradas/Eliminadas");
                dtt.Columns.Add("Numero de Citas Asistidas");

                for (int y = 0; y < ListIdCarrera.Count; y++)
                {
                    DataRow dr = dtt.NewRow();
                    csCarrera Carrera = CarreraHandler.GetCarrera(ListIdCarrera[y]);
                    dr["Carrera"] = Carrera.Nombre;
                    dr["Numero de Citas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, todasCitas:true);
                    dr["Numero de Citas Disponibles"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, disponibleCitas:true);
                    dr["Numero de Citas Ocupadas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, ocupadaCitas:true);
                    dr["Numero de Citas Expiradas/Eliminadas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, expiroCitas:true);
                    dr["Numero de Citas Asistidas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, asistioCitas:true);

                    dtt.Rows.Add(dr);
                }

                GridView_Citas.DataSource = dt;
                GridView_Citas.DataBind();

                GridView_CountCitas.DataSource = dtt;
                GridView_CountCitas.DataBind();
            }
        }
        else
        {
            int intResult = 0;
            IdRol = 1;
            Usuario = new csUsuario();

            if (Int32.TryParse(txtNumControl.Text, out intResult))
            {
                Usuario = UsuarioHandler.GetUsuario(intResult, IdRol);
                listCita = CitaHandler.GetListCitaByIdCoordinador(Usuario.IdCarrera);
            }

            csCarrera Carrera = CarreraHandler.GetCarrera(Usuario.IdCarrera);

            //(new ObjetoBase()).LogError(listCita[0].IdCita.ToString());

            dt = new DataTable();
            dt.Columns.Add("IdCita");
            dt.Columns.Add("Carrera");
            dt.Columns.Add("IdUsuario");
            dt.Columns.Add("FechaDisponible");
            dt.Columns.Add("Estado");

            for (int y = 0; y < listCita.Count; y++)
            {
                DataRow dr = dt.NewRow();
                dr["IdCita"] = listCita[y].IdCita.ToString();
                dr["Carrera"] = Carrera.Nombre;
                if (!ListIdCarrera.Contains(Carrera.IdCarrera))
                    ListIdCarrera.Add(Carrera.IdCarrera);
                dr["IdUsuario"] = listCita[y].IdUsuario.ToString();
                dr["FechaDisponible"] = listCita[y].FechaDisponible.ToString();
                if (listCita[y].Estado == 0)
                    dr["Estado"] = "Disponible";
                else if (listCita[y].Estado == 1)
                    dr["Estado"] = "Ocupado";
                else if (listCita[y].Estado == 2)
                    dr["Estado"] = "Expiro";
                else if (listCita[y].Estado == 3)
                    dr["Estado"] = "Asistio";

                dt.Rows.Add(dr);
            }

            dtt = new DataTable();
            dtt.Columns.Add("Carrera");
            dtt.Columns.Add("Numero de Citas");
            dtt.Columns.Add("Numero de Citas Disponibles");
            dtt.Columns.Add("Numero de Citas Ocupadas");
            dtt.Columns.Add("Numero de Citas Expiradas/Eliminadas");
            dtt.Columns.Add("Numero de Citas Asistidas");

            fechaInicio = DateTime.Now;
            fechaFinal = DateTime.Now;

            for (int y = 0; y < ListIdCarrera.Count; y++)
            {
                DataRow dr = dtt.NewRow();
                Carrera = CarreraHandler.GetCarrera(ListIdCarrera[y]);
                dr["Carrera"] = Carrera.Nombre;
                dr["Numero de Citas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, todasCitasT:true);
                dr["Numero de Citas Disponibles"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, disponibleCitasT: true);
                dr["Numero de Citas Ocupadas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, ocupadaCitasT: true);
                dr["Numero de Citas Expiradas/Eliminadas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, expiroCitasT: true);
                dr["Numero de Citas Asistidas"] = CitaHandler.GetListCitaCount(Carrera.IdCarrera, fechaInicio, fechaFinal, asistioCitasT: true);

                dtt.Rows.Add(dr);
            }

            GridView_Citas.DataSource = dt;
            GridView_Citas.DataBind();

            GridView_CountCitas.DataSource = dtt;
            GridView_CountCitas.DataBind();
        }
    }

    protected void GridView_Citas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            (new csCitaHandler()).DeleteCita(Convert.ToInt32(e.CommandArgument));
            Response.Redirect("~\\IndexAdmin.aspx");
        }
        else if (e.CommandName == "Asistio")
        {
            csCitaHandler CitaHandler = new csCitaHandler();

            int index = Convert.ToInt32(e.CommandArgument);
            //(new ObjetoBase()).LogError(index.ToString());
            GridViewRow selectedRow = GridView_Citas.Rows[index];
            TableCell citaObject = selectedRow.Cells[0];
            int idCita = Convert.ToInt32(citaObject.Text);

            csCita Cita = CitaHandler.GetCitaByIdCita(idCita);
            Cita.Estado = 3;

            if (CitaHandler.UpdateCita(Cita))
            {
                Response.Write(@"<script language = 'javascript'>alert('Cita finalizada con exito.') </script>");
                Response.Redirect("IndexAdmin.aspx");
            }
            else
            {
                Response.Write(@"<script language = 'javascript'>alert('Error al finalizar cita.') </script>");
                Response.Redirect("IndexAdmin.aspx");
            }
        }
        else if (e.CommandName == "Falto")
        {
            csCitaHandler CitaHandler = new csCitaHandler();

            int index = Convert.ToInt32(e.CommandArgument);
            //(new ObjetoBase()).LogError(index.ToString());
            GridViewRow selectedRow = GridView_Citas.Rows[index];
            TableCell citaObject = selectedRow.Cells[0];
            int idCita = Convert.ToInt32(citaObject.Text);

            csCita Cita = CitaHandler.GetCitaByIdCita(idCita);
            Cita.Estado = 2;

            if (CitaHandler.UpdateCita(Cita))
            {
                Response.Write(@"<script language = 'javascript'>alert('Cita finalizada con exito.') </script>");
                Response.Redirect("IndexAdmin.aspx");
            }
            else
            {
                Response.Write(@"<script language = 'javascript'>alert('Error al finalizar cita.') </script>");
                Response.Redirect("IndexAdmin.aspx");
            }
        }
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

    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["IdUsuario"] = null;
        Response.Redirect("~\\Login.aspx");
    }
}