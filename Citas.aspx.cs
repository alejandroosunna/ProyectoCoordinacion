using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Services;
using Newtonsoft.Json;

public partial class Citas : System.Web.UI.Page 
{
    public static DataTable TableData = new DataTable();
    protected static int coord;
    protected void Page_Load(object sender, EventArgs e)
    {
        coord = Convert.ToInt32(Session["IdCarrera"]);
        if (!IsPostBack)
        {
            GetAllData();
        }
    }

    private void GetAllData()
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        using (var con = new SqlConnection(ConnectionString))
        {
            con.Open();
            SqlParameter Data = new SqlParameter("@IdCoordina", coord);
            Data.DbType = DbType.Int32;
            const string query = "select * from tbCitas where IdCoordinador = @IdCoordina";
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(Data);
                using (var sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (TableData)
                    {
                        TableData.Clear();
                        sda.Fill(TableData);
                    }
                }
            }
        }
    }

    [WebMethod]
    public static csCita[] GetData()
    {
        var details = new List<csCita>();
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        using (var con = new SqlConnection(ConnectionString)) {
            SqlParameter Data = new SqlParameter("@IdCoordina", coord);
            Data.DbType = DbType.Int32;
            const string query = "select * from tbCitas where IdCoordinador =  @IdCoordina order by FechaDisponible";
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(Data);
                using (var sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    TableData.Clear();
                    sda.Fill(TableData);
                    details.AddRange(from DataRow dtrow in TableData.Rows
                                     select new csCita
                                     {
                                         IdCita = Convert.ToInt32(dtrow["IdCita"]),
                                         IdUsuario = Convert.ToInt32(dtrow["IdUsuario"]),
                                         FechaAgendada = Convert.ToDateTime(dtrow["FechaAgendada"]),
                                         FechaDisponible = Convert.ToDateTime(dtrow["FechaDisponible"]),
                                         Estado = Convert.ToInt32(dtrow["Estado"]),
                                         Comentario = dtrow["Comentario"].ToString()
                                     });
                }
            }
        }
        return details.ToArray();
    }
    [WebMethod]
    public static string EditCita(int cid)
    {
        string jsondata = null;
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        using (var con = new SqlConnection(ConnectionString))
        {
            con.Open();

            SqlParameter Data = new SqlParameter("@idCita", cid);
            Data.DbType = DbType.Int32;

            var query = "select * from tbCitas where idCita = @idCita";

            SqlCommand Command = new SqlCommand(query, con);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();
    
                if (DataReader.Read())
                {
                    CitaEdit citaEditar = new CitaEdit();
                   
                   
                    citaEditar.id = (int)CheckDbNull(DataReader["IdCita"], TipoDeObjeto.TipoInteger);
                    citaEditar.idUsuario = (int)CheckDbNull(DataReader["IdUsuario"], TipoDeObjeto.TipoInteger);
                    citaEditar.estado = (int)CheckDbNull(DataReader["Estado"], TipoDeObjeto.TipoInteger);
                    citaEditar.comentario = (string)CheckDbNull(DataReader["Comentario"], TipoDeObjeto.TipoString);
                    citaEditar.fechaDisponible = (DateTime)CheckDbNull(DataReader["FechaDisponible"], TipoDeObjeto.TipoDateTime);
               
                    jsondata = JsonConvert.SerializeObject(citaEditar);

                    return jsondata;
                }else
                {
                    return jsondata;
                } 
            
        }
        
    }
    public enum TipoDeObjeto
    {
        TipoString = 0,
        TipoInteger = 1,
        TipoDouble = 2,
        TipoDateTime = 3,
        TipoBoolean = 4
    }
    public static Object CheckDbNull(Object Objeto, TipoDeObjeto _TipoDeObjeto)
    {
        if (_TipoDeObjeto == TipoDeObjeto.TipoString && DBNull.Value == Objeto)
            return "";
        else if (_TipoDeObjeto == TipoDeObjeto.TipoInteger && DBNull.Value == Objeto)
            return 0;
        else if (_TipoDeObjeto == TipoDeObjeto.TipoDouble && DBNull.Value == Objeto)
            return 0.0;
        else if (_TipoDeObjeto == TipoDeObjeto.TipoDateTime && DBNull.Value == Objeto)
            return DateTime.Now;
        else if (_TipoDeObjeto == TipoDeObjeto.TipoBoolean && DBNull.Value == Objeto)
            return false;

        return Objeto;
    }
    [WebMethod]
    public static void UpdateData(citaUpdate cita, int cid)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        using (var con = new SqlConnection(ConnectionString))
        {
   
            var query = "update tbCitas set idCita = " + cita.id + ", idUsuario = " + cita.idUsuario + ", fechaAgendada='" +
                System.DateTime.Now + "',fechaDisponible = " + cita.fechaDisponible + "', estado= " + cita.estado +
                ", comentario= '" + cita.comentario + "' where idCita = " + cita.id + "";
            var queryComprobacion = "select * from tbCitas where fechaDisponible = " + cita.fechaDisponible + ";";

            con.Open();
            //var cmdcomprobacion = new SqlCommand(queryComprobacion, con);
            //if(cmdcomprobacion.ExecuteNonQuery() == 0)
            //{
                var cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            //}
            con.Close();


        }
    }

    [WebMethod]
    public static void RemoveCita(int cid)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        using (var con = new SqlConnection(ConnectionString))
        {
            var query = "delete from tbcitas where idCita='" + cid + "'";
            con.Open();
            var cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}