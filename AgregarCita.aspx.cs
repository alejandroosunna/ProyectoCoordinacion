using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgregarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdUsuario"] == null || Convert.ToInt16(Session["IdRol"])==2)
            Response.Redirect("~\\Login.aspx");
    }

    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["IdUsuario"] = null;
        Response.Redirect("~\\Login.aspx");
    }

    protected void btnAgregarCita_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime Date = new DateTime(01/01/0001);
            DateTime finicio = new DateTime();

            finicio = Convert.ToDateTime(txtFecha.Text).AddHours(Convert.ToDouble(txtHora.Text));
           
            

            if (finicio.ToShortDateString() != Date.ToShortDateString() && txtHora.Text != "")
            {
                csCita Cita = new csCita();

                Cita.IdCoordinador = Convert.ToInt32(Session["IdCarrera"]);
                Cita.FechaDisponible = finicio;
                Cita.Estado = 0;

                (new csCitaHandler()).AddNewCita(Cita);
                Response.Redirect("~\\AgregarCita.aspx");
            }
            else
            {
                Response.Write(@"<script language = 'javascript'>alert('Llene todos los campos.') </script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write(@"<script language = 'javascript'>alert('Error al dar de alta la cita. Verefique los datos.') </script>");
        }
    }

    protected void btnGenerarCitas_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime finicio = new DateTime();

            finicio = Convert.ToDateTime(txtFecha.Text).AddHours(Convert.ToDouble(txtHora0.Text));
         
            GenerateDates(finicio, Convert.ToInt16(txtDias.Text), Convert.ToDouble(txtHora1.Text), Convert.ToDouble(txtIntervalo.Text));
        }
        catch
        {
            Response.Write(@"<script language = 'javascript'>alert('Ah ocurrido un error') </script>");
        }
       
    }
    private void GenerateDates(DateTime xfInicio, int xdias, double xhoraFinal, double xintervalo)
    {
        DateTime Date = new DateTime(01 / 01 / 0001);
        DateTime fInicio = xfInicio;
        csCita Cita = new csCita();
        int day = 0;

        try
        {
            for (int i = 1; i <= xdias; i++)
            {
                day++;
                if (fInicio.ToString("dddd", new System.Globalization.CultureInfo("es-Es")) != "sábado" && fInicio.ToString("dddd", new System.Globalization.CultureInfo("es-Es")) != "domingo")
                {
                    for (int j = fInicio.Hour; j < xhoraFinal;)
                    {
                        Cita.IdCoordinador = Convert.ToInt32(Session["IdCarrera"]);
                        Cita.FechaDisponible = fInicio;
                        Cita.Estado = 0;
                        fInicio = fInicio.AddMinutes(xintervalo);
                        j = fInicio.Hour;
                        (new csCitaHandler()).AddNewCita(Cita);
                    }
                    fInicio = xfInicio;
                    fInicio = fInicio.AddDays(day);
                }
                else
                {
                    i--;
                    fInicio = xfInicio;
                    fInicio = fInicio.AddDays(day);
                }
            }
            Response.Redirect("~\\AgregarCita.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(@"<script language = 'javascript'>alert('Error al dar de alta la cita. Verefique los datos.') </script>");
        }
    }

}