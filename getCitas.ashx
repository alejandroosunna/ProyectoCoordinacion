<%@ WebHandler Language="C#" Class="getCitas" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.SessionState;

public class getCitas : IHttpHandler, IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        csCitaHandler CitaHandler = new csCitaHandler();
        csUsuario Usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(context.Session["IdUsuario"]));
        IList<csCita> listCita;
        if(Usuario.IdRol == 1 || Usuario.IdRol == 3)
        {
          listCita  = CitaHandler.GetCitaApartadas(Usuario.IdCarrera);
        }else 
        {
          listCita = CitaHandler.GetListCitas(Usuario.IdCarrera, DateTime.Now);
        }


        //var lista = obtenerCitas(listCita);
        //var rows = lista.ToArray();
        //string jsondata = JsonConvert.SerializeObject(rows);




        List<Cita> lista = new List<Cita>();

        foreach(var item in listCita)
        {
            Cita nueva = new Cita()
            {
                id = item.IdCita,
                title = "Cita" + item.IdCita,
                start = item.FechaDisponible.ToString("s"),
                end = item.FechaDisponible.ToString("s")
            };
            lista.Add(nueva);
            nueva = null;
        }

        System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
         new System.Web.Script.Serialization.JavaScriptSerializer();
        string sJSON = oSerializer.Serialize(lista);
        context.Response.Write(sJSON);


    }


    public bool IsReusable {
        get {
            return false;
        }
    }

}