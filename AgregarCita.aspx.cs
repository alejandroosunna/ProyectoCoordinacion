﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgregarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
<<<<<<< HEAD
        if (Session["IdUsuario"] == null || Convert.ToInt16(Session["IdRol"])==2)
            Response.Redirect("~\\Login.aspx");

    }


=======
        if (Request["Cita"] != null)
        {
            if (Request["Cita"] == "err")
                Response.Write(@"<script language = 'javascript'>alert('Error al agregar citas.') </script>");
            else if (Request["Cita"] == "ex")
                Response.Write(@"<script language = 'javascript'>alert('Citas agregadas con exito.') </script>");
        }
    }

>>>>>>> refs/remotes/origin/master
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["IdUsuario"] = null;
        Response.Redirect("~\\Login.aspx");
    }

    protected void btnAgregarCita_Click(object sender, EventArgs e)
    {
<<<<<<< HEAD
        try
        {
            DateTime Date = new DateTime(01/01/0001);
            DateTime finicio = new DateTime();

            finicio = Convert.ToDateTime(txtFecha.Text).AddHours(Convert.ToDouble(txtHora.Text));
           
            

            if (finicio.ToShortDateString() != Date.ToShortDateString() && txtHora.Text != "")
=======
        if (txtHora.Text != "" && txtFecha.Text != "")
        {
            DateTime Date = new DateTime(01 / 01 / 0001);
            DateTime finicio = new DateTime();

            string[] hora = txtHora.Text.Split(':');

            if (Convert.ToInt32(hora[0]) >= 13 && Convert.ToInt32(hora[0]) <= 23)
            {
                string fechaHora = Convert.ToDateTime(txtFecha.Text).ToString("dd/MM/yyyy") + " " +  hora[0] + ":" + hora[1] + ":00 PM";
                finicio = Convert.ToDateTime(fechaHora);
            }
            else if (Convert.ToInt32(hora[0]) >= 00 && Convert.ToInt32(hora[0]) < 13)
            {
                if (Convert.ToInt32(hora[0]) == 00)
                    hora[0] = "12";

                string fechaHora = Convert.ToDateTime(txtFecha.Text).ToString("dd/MM/yyyy") + " " +  hora[0] + ":" + hora[1] + ":00 AM";
                finicio = Convert.ToDateTime(fechaHora);
            }

            if (finicio.ToShortDateString() != Date.ToShortDateString())
>>>>>>> refs/remotes/origin/master
            {
                csCita Cita = new csCita();

                Cita.IdCoordinador = Convert.ToInt32(Session["IdCarrera"]);
                Cita.FechaDisponible = finicio;
                Cita.Estado = 0;

<<<<<<< HEAD
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
=======
                if (!(new csCitaHandler()).AddNewCita(Cita))
                    Response.Redirect("~\\AgregarCita.aspx?Cita=ex");
                else
                    Response.Redirect("~\\AgregarCita.aspx?Cita=err");
            }
            else
                Response.Write(@"<script language = 'javascript'>alert('Llene todos los campos..............') </script>");
        }
        else
            Response.Write(@"<script language = 'javascript'>alert('Llene todos los campos.') </script>");
>>>>>>> refs/remotes/origin/master
    }

    protected void btnGenerarCitas_Click(object sender, EventArgs e)
    {
<<<<<<< HEAD
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
        try
        {
            for (int i = 1; i <= xdias; i++)
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
                fInicio = fInicio.AddDays(i);
            }
            Response.Redirect("~\\AgregarCita.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(@"<script language = 'javascript'>alert('Error al dar de alta la cita. Verefique los datos.') </script>");
        }
=======
        int resultDias;
        int resulIntervalo;
        if (txtFecha.Text != "" && txtDias.Text != "" && txtHora0.Text != "" && txtHora1.Text != "" && txtIntervalo.Text != "")
        {
            if (Int32.TryParse(txtDias.Text, out resultDias) && Int32.TryParse(txtIntervalo.Text, out resulIntervalo))
            {
                if (resultDias > 0 && resulIntervalo > 0)
                {
                    DateTime Date = new DateTime(01 / 01 / 0001);
                    DateTime finicio = new DateTime();

                    string[] hora = txtHora0.Text.Split(':');

                    if (Convert.ToInt32(hora[0]) >= 13 && Convert.ToInt32(hora[0]) <= 23)
                    {
                        string fechaHora = Convert.ToDateTime(txtFecha.Text).ToString("dd/MM/yyyy") + " " + hora[0] + ":" + hora[1] + ":00 PM";
                        finicio = Convert.ToDateTime(fechaHora);
                    }
                    else if (Convert.ToInt32(hora[0]) >= 00 && Convert.ToInt32(hora[0]) < 13)
                    {
                        if (Convert.ToInt32(hora[0]) == 00)
                            hora[0] = "12";

                        string fechaHora = Convert.ToDateTime(txtFecha.Text).ToString("dd/MM/yyyy") + " " + hora[0] + ":" + hora[1] + ":00 AM";
                        finicio = Convert.ToDateTime(fechaHora);
                    }

                    if (finicio.ToShortDateString() != Date.ToShortDateString())
                    {
                        hora = txtHora1.Text.Split(':');

                        TimeSpan timeHoraFinal = new TimeSpan(Convert.ToInt32(hora[0]), Convert.ToInt32(hora[1]), 00);

                        this.GenerateDates(finicio, resultDias, timeHoraFinal, resulIntervalo);
                    }
                    else
                        Response.Write(@"<script language = 'javascript'>alert('Llene todos los campos..............') </script>");
                }
                else
                    Response.Write(@"<script language = 'javascript'>alert('Dias e Intervalo debe ser mayor a 0 (Cero).') </script>");
            }
            else
                Response.Write(@"<script language = 'javascript'>alert('Formato invalido para Dias y/o Intervalo.') </script>");
        }
        else
            Response.Write(@"<script language = 'javascript'>alert('Llene todos los campos.') </script>");

    }
    private void GenerateDates(DateTime xfInicio, int xdias, TimeSpan xhoraFinal, double xintervalo)
    {
        DateTime Date = new DateTime(01 / 01 / 0001);
        DateTime fInicio = xfInicio;
        DateTime hoy = DateTime.Now;

        int day = 0;

        List<csCita> Citas = new List<csCita>();
        
        for (int i = 1; i <= xdias; i++)
        {
            day++;
            if (fInicio.ToString("dddd", new System.Globalization.CultureInfo("es-Es")) != "sábado" && fInicio.ToString("dddd", new System.Globalization.CultureInfo("es-Es")) != "domingo")
            {
                for (TimeSpan j = new TimeSpan(fInicio.Hour, fInicio.Minute, 00); j <= xhoraFinal;)
                {
                    if (fInicio >= hoy)
                    {
                        csCita Cita = new csCita();

                        Cita.IdCoordinador = Convert.ToInt32(Session["IdCarrera"]);
                        Cita.FechaDisponible = fInicio;
                        Cita.Estado = 0;

                        //(new ObjetoBase()).LogError(j.ToString() + "-------------" + xhoraFinal.ToString() + "     RES --> " + fInicio.ToString());
                        Citas.Add(Cita);
                    }

                    fInicio = fInicio.AddMinutes(xintervalo);
                    j = new TimeSpan(fInicio.Hour, fInicio.Minute, 00);
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

        if (!(new csCitaHandler()).AddCitas(Citas))
            Response.Redirect("~\\AgregarCita.aspx?Cita=ex");
        else
            Response.Redirect("~\\AgregarCita.aspx?Cita=err");
>>>>>>> refs/remotes/origin/master
    }

}