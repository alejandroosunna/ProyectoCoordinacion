﻿<%@ WebHandler Language="C#" Class="ActualizarCita" %>

using System;
using System.Web;
using System.Web.SessionState;

public class ActualizarCita : IHttpHandler, IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        string accion = context.Request.Form["Accion"];
        csCitaHandler CitaHandler = new csCitaHandler();
        int idCita = Convert.ToInt32(context.Request.Form["IdCita"]);
        csCita Cita = CitaHandler.GetCitaByIdCita(idCita);

        if (accion == "Asistio")
        {

            Cita.Estado = 3;

        }
        else if (accion == "Falto")
        {

            Cita.Estado = 2;

        }
       
        System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
         new System.Web.Script.Serialization.JavaScriptSerializer();
         string sJSON = oSerializer.Serialize(!CitaHandler.UpdateCita(Cita));
         context.Response.Write(sJSON);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}