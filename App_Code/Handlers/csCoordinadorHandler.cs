using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de clsAdministradorHandler
/// </summary>
public class csCoordinadorHandler : ObjetoBase
{
	public csCoordinadorHandler()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public csCoordinador CheckLogin(int NumControl, string Contraseña)
    {
        csCoordinador Coordinador = new csCoordinador();
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();

            SqlParameter[] Data = new SqlParameter[2];
            Data[0] = new SqlParameter("@IdUsuario", NumControl);
            Data[0].DbType = DbType.Int32;
            Data[1] = new SqlParameter("@Contraseña", Contraseña);
            Data[1].DbType = DbType.String;

            String Query = "select * from tbUsuario where IdUsuario = @IdUsuario and Contraseña = @Contraseña;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {
                Coordinador.LoadEventFromDataReader(DataReader);
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

        return Coordinador;
    }

    public csCoordinador GetAdministrador(int IdCoordinador)
    {
        csCoordinador Coordinador = new csCoordinador();
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();

            SqlParameter Data = new SqlParameter("@IdUsuario", IdCoordinador);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbUsuarios where IdUsuario = @IdUsuario;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {
                Coordinador.LoadEventFromDataReader(DataReader);
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

        return Coordinador;
    }
}