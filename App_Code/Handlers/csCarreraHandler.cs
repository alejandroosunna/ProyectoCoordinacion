using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csCarreraHandler
/// </summary>
public class csCarreraHandler : ObjetoBase
{
    public csCarreraHandler()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public csCarrera GetCarrera(int IdCarrera)
    {
        csCarrera Carrera = new csCarrera();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            SqlParameter Data = new SqlParameter("@IdCarrera", IdCarrera);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbCarreras where IdCarrera = @IdCarrera;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {
                Carrera.LoadEventFromDataReader(DataReader);
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

        return Carrera;
    }

    public int GetCount()
    {
        int countCarreras = 0;

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";
            //SqlParameter Data = new SqlParameter("@IdCoordinador", IdCoordinador);
            //Data.DbType = DbType.Int32;

            String Query = "select count(*) as countCarreras from tbCarreras;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            //Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
                countCarreras = (int)CheckDbNull(DataReader["countCarreras"], TipoDeObjeto.TipoInteger);

            DataReader.Close();
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

        return countCarreras;
    }

    //public csCita GetCarrera(int IdCarrera)
    //{
    //    csCita Citas = new csCita();

    //    String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
    //    SqlConnection Connection = new SqlConnection(ConnectionString);
    //    try
    //    {
    //        Connection.Open();
    //        SqlParameter Data = new SqlParameter("@IdCarrera", IdCarrera);
    //        Data.DbType = DbType.Int32;

    //        String Query = "select * from tbCitas where IdCarrera = @IdCarrera;";

    //        SqlCommand Command = new SqlCommand(Query, Connection);
    //        Command.Parameters.Add(Data);
    //        SqlDataReader DataReader = Command.ExecuteReader();

    //        if (DataReader.Read())
    //        {
    //            Citas.LoadEventFromDataReader(DataReader);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        LogError(ex.Message);
    //    }
    //    finally
    //    {
    //        Connection.Close();
    //        Connection = null;
    //    }

    //    return Citas;
    //}
}