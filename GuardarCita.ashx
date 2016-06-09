<%@ WebHandler Language="C#" Class="GuardarCita" %>

using System;
using System.Web;
    using System.Web.SessionState;
public class GuardarCita : IHttpHandler, IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;


        csCita Cita = new csCita();
        Cita.IdCita = Convert.ToInt32(context.Request.Form["IdCita"]);
        Cita.IdUsuario = Convert.ToInt32(Convert.ToInt32(context.Session["IdUsuario"]));
        Cita.FechaAgendada = DateTime.Now;
        Cita.Estado = 1;

        int checkCita = (new csCitaHandler()).CheckCitaAndAddCita(Cita);

         System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
         new System.Web.Script.Serialization.JavaScriptSerializer();
         string sJSON = oSerializer.Serialize(checkCita);
         context.Response.Write(sJSON);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}