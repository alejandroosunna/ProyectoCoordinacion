using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csMotivoHandler
/// </summary>
public class csMotivoHandler : ObjetoBase
{
    public csMotivoHandler()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public csMotivo Get(int IdMotivo)
    {
        csMotivo Motivo = new csMotivo();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            SqlParameter Data = new SqlParameter("@IdMotivo", IdMotivo);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbMotivos where IdMotivo = @IdMotivo;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {
                Motivo.LoadEventFromDataReader(DataReader);
            }
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
        }
        finally
        {
            Connection.Close();
            Connection = null;
        }

        return Motivo;
    }

    public List<csMotivo> GetList(int IdCarrera)
    {
        List<csMotivo> listMotivo = new List<csMotivo>();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();

            SqlParameter Data = new SqlParameter("@IdCarrera", IdCarrera);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbMotivos where IdCarrera = @IdCarrera;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                csMotivo Motivo = new csMotivo();
                Motivo.LoadEventFromDataReader(DataReader);
                listMotivo.Add(Motivo);
            }

            DataReader.Close();
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
        }
        finally
        {
            Connection.Close();
            Connection = null;
        }

        return listMotivo;
    }

    public DataTable GetDataSet(int IdCarrera)
    {
        DataTable dt = new DataTable();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();

            String Query = "select * from tbMotivos where IdCarrera = @IdCarrera;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@IdCarrera", IdCarrera);

            SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
            DataAdapter.Fill(dt);
        }
        catch (Exception ex)
        {
            LogError(ex.Message + ex.StackTrace);
        }
        finally
        {
            Connection.Close();
            Connection = null;
        }

        return dt;
    }
}