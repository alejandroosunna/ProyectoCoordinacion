using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Web.Services;


public partial class IndexAlumno : System.Web.UI.Page
{
    public DataTable dt;
    public int estadoCita;
    public bool result;
    public string sesion;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdUsuario"] != null && Session["IdRol"] != null)
        {
            if (Convert.ToInt32(Session["IdRol"]) == 2)
            {
                result = bool.TryParse(Request["Logout"], out result);
                if (result)
                {
                    Session["IdUsuario"] = null;
                    Session["IdRol"] = null;
                    Session["IdCarrera"] = null;
                    Response.Redirect("~\\Login.aspx");
                }
                else if (Request["Cita"] != null)
                {
                    if (Request["Cita"] == "err")
                        Response.Write(@"<script language = 'javascript'>alert('Esta cita ya esta ocupada. Seleccione otra.') </script>");
                    else if (Request["Cita"] == "ex")
                        Response.Write(@"<script language = 'javascript'>alert('Cita agendada Exitosamente.') </script>");
                    else if (Request["Cita"] == "pen")
                        Response.Write(@"<script language = 'javascript'>alert('Ya tienes una cita pendiente.') </script>");
                }
                else if (Request["De"] != null)
                {
                    if (Request["De"] == "ex")
                        Response.Write(@"<script language = 'javascript'>alert('Cita eliminada con exito.') </script>");
                    if (Request["De"] == "err")
                        Response.Write(@"<script language = 'javascript'>alert('Error al eliminar la cita.') </script>");
                }
                else if (Request["Exp"] != null)
                {
                    result = bool.TryParse(Request["Logout"], out result);
                    if (result)
                        Response.Write(@"<script language = 'javascript'>alert('Tu cita ya expiro.') </script>");
                    else
                        Response.Write(@"<script language = 'javascript'>alert('Tu cita ya expiro.') </script>");
                }

                csCitaHandler CitaHandler = new csCitaHandler();
                csUsuario Usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"]));

                lblNombre.Text = "Alumno: " + Usuario.Nombre + " " + Usuario.Apellidos + ".";
                lblNumControl.Text = "Numero de Control: " + Usuario.IdUsuario + ".";

                estadoCita = 1; //Agendada
                csCita Cita = CitaHandler.GetCita(Convert.ToInt32(Session["IdUsuario"]), estadoCita);

                if (Cita.Estado == 1)
                {
                    if (DateTime.Now > Cita.FechaDisponible)
                    {
                        estadoCita = 3; //Update cita con error.
                        if (!(CitaHandler.Delete(Cita.IdCita, estadoCita)))
                            Response.Redirect("~//IndexAlumno.aspx?Exp=true");
                        else
                            Response.Redirect("~//IndexAlumno.aspx?Logout=true");
                    }
                    else
                    {
                        lblPDiaCita.Text = "Fecha: " + Cita.FechaDisponible.ToString("dd / MM / yyyy");
                        lblPHoraCita.Text = "Hora: " + Cita.FechaDisponible.ToString("t");
                        btnEliminarCita.Visible = true;
                        //GridViewCitas.Visible = false;
                        //DropDListMotivos.Visible = false;
                    }
                }
                //else
                //{
                //    lblPDiaCita.Text = "Ningun pendiente.";
                //    lblPHoraCita.Text = "";
                //    btnEliminarCita.Visible = false;
                //    GridViewCitas.Visible = true;
                //    //DropDListMotivos.Visible = true;
                //    sesion = Session["IdUsuario"].ToString();
                //    List<csCita> listCita = CitaHandler.GetListCitas(Usuario.IdCarrera, DateTime.Now);

                //    dt = new DataTable();
                //    dt.Columns.Add("Apartar");
                //    dt.Columns.Add("NumeroCita");
                //    dt.Columns.Add("Hora");
                //    dt.Columns.Add("Dia");

                //    for (int y = 0; y < listCita.Count; y++)
                //    {
                //        DataRow dr = dt.NewRow();
                //        dr["Apartar"] = listCita[y].IdCita.ToString();
                //        dr["NumeroCita"] = listCita[y].IdCita.ToString();
                //        dr["Hora"] = listCita[y].FechaDisponible.ToString("t");
                //        dr["Dia"] = listCita[y].FechaDisponible.ToString("dd / MM / yyyy");

                //        dt.Rows.Add(dr);
                //    }

                //    GridViewCitas.DataSource = dt;
                //    GridViewCitas.DataBind();

                //    //DataTable Dt = new DataTable();
                //    //DataView Dv = default(DataView);
                //    //Dv = (DataView)SqlDataDropDListMotivos.Select(DataSourceSelectArguments.Empty);
                //    //Dt = Dv.ToTable();
                //    //DropDListMotivos.Items.Clear();

                //    //for (int i = 0; i < Dt.Rows.Count; i++)
                //    //{
                //    //    //DropDListMotivos.Items.Add("op" + i.ToString());
                //    //    DropDListMotivos.Items.Add(Dt.Rows[i]["Motivo"].ToString());
                //    //    DropDListMotivos.Items[i].Value = Dt.Rows[i]["IdMotivo"].ToString();
                //    //    DropDListMotivos.Items[i].Text = Dt.Rows[i]["Motivo"].ToString();
                //    //}
                //}

            }
            else
                Response.Redirect("~\\IndexAdmin.aspx");
        }
        else
            Response.Redirect("~\\Login.aspx");
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        enviarCorrreo();
    }

    protected void btnEliminarCita_Click(object sender, EventArgs e)
    {
        int IdCita = (new csCitaHandler()).GetCita(Convert.ToInt32(Session["IdUsuario"])).IdCita;
        estadoCita = 3;

        if (!(new csCitaHandler()).Delete(IdCita, estadoCita))
            Response.Redirect("~\\IndexAlumno.aspx?De=ex");
        else
            Response.Redirect("~\\IndexAlumno.aspx?De=err");
    }

    public void enviarCorrreo()
    {
        string name = txtName.Text;
        string email = txtEmail.Text;
        string msg = txtMesg.Text;

        if (new Emailhtml().enviarcorreo(name, email, msg))
            Response.Write(@"<script language = 'javascript'>alert('Correo enviado') </script>");
        else
            Response.Write(@"<script language = 'javascript'>alert('Correo no enviado') </script>");
    }

    //protected void GridViewCitas_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    csCita Cita = new csCita();
    //    Cita.IdCita = Convert.ToInt32(GridViewCitas.DataKeys[GridViewCitas.SelectedRow.RowIndex].Value);
    //    Cita.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
    //    Cita.FechaAgendada = DateTime.Now;
    //    Cita.Estado = 1;

    //    //int idMotivo = Convert.ToInt32(DropDListMotivos.SelectedItem.Value);
    //    int checkCita = (new csCitaHandler()).CheckCitaAndAddCita(Cita); //CheckCitaAndAddCitaMotivo(Cita, idMotivo);

    //    if (checkCita == 1)
    //        Response.Redirect("IndexAlumno.aspx?Cita=ex");
    //    else if (checkCita == 0)
    //        Response.Redirect("IndexAlumno.aspx?Cita=err");
    //    else if (checkCita == 2)
    //        Response.Redirect("IndexAlumno.aspx?Cita=pen");
    //}
  
   
   
}