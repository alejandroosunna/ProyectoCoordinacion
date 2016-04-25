using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Descripción breve de clsCitaHandler
/// </summary>
public class csCitaHandler : ObjetoBase
{
	public csCitaHandler()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public csCita GetCita(int IdUsuario)
    {
        csCita Citas = new csCita();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            SqlParameter Data = new SqlParameter("@IdUsuario", IdUsuario);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbCitas where IdUsuario = @IdUsuario;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();
            
            if (DataReader.Read())
            {
                Citas.LoadEventFromDataReader(DataReader);
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

        return Citas;
    }

    public csCita GetCitaByIdCita(int IdCita)
    {
        csCita Citas = new csCita();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            SqlParameter Data = new SqlParameter("@IdCita", IdCita);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbCitas where IdCita = @IdCita;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {
                Citas.LoadEventFromDataReader(DataReader);
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

        return Citas;
    }

    public csCita GetCita(int IdUsuario, int estadoCita)
    {
        csCita Citas = new csCita();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            SqlParameter[] Data = new SqlParameter[2];
            Data[0] = new SqlParameter("@IdUsuario", IdUsuario);
            Data[0].DbType = DbType.Int32;
            Data[1] = new SqlParameter("@Estado", estadoCita);
            Data[1].DbType = DbType.Int32;

            String Query = "select * from tbCitas where IdUsuario = @IdUsuario and Estado = @Estado;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {
                Citas.LoadEventFromDataReader(DataReader);
            }
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

        return Citas;
    }

    public List<csCita> GetListSuperAdmin(DateTime fechaInicial, DateTime fechaFinal)
    {
        List<csCita> listCita = new List<csCita>();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";
            //SqlParameter Data = new SqlParameter("@IdUsuario", IdUsuario);
            //Data.DbType = DbType.Int32;
            SqlParameter[] Data = new SqlParameter[2];
            Data[0] = new SqlParameter("@FechaInicial", fechaInicial);
            Data[0].DbType = DbType.DateTime;
            Data[1] = new SqlParameter("@FechaFinal", fechaFinal);
            Data[1].DbType = DbType.DateTime;

            String Query = "select * from tbCitas where FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal order by IdCoordinador asc, Estado asc, FechaDisponible desc;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                csCita Cita = new csCita();
                Cita.LoadEventFromDataReader(DataReader);
                listCita.Add(Cita);
            }

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

        return listCita;
    }

    public int GetListCitaCount(int IdCoordinador, DateTime fechaInicial, DateTime fechaFinal, bool todasCitas = false, bool todasCitasT = false, bool disponibleCitas = false, bool disponibleCitasT = false, 
        bool ocupadaCitas = false, bool ocupadaCitasT = false, bool expiroCitas = false, bool expiroCitasT = false, bool asistioCitas = false, bool asistioCitasT = false)
    {
        int countCita = 0;
        String Query = string.Empty;
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";

            SqlParameter[] Data = new SqlParameter[3];
            Data[0] = new SqlParameter("@IdCoordinador", IdCoordinador);
            Data[0].DbType = DbType.Int32;
            Data[1] = new SqlParameter("@FechaInicial", fechaInicial);
            Data[1].DbType = DbType.DateTime;
            Data[2] = new SqlParameter("@FechaFinal", fechaFinal);
            Data[2].DbType = DbType.DateTime;

            if(todasCitas)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal;";
            else if(disponibleCitas)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal and Estado = 0;";
            else if(ocupadaCitas)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal and Estado = 1;";
            else if(expiroCitas)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal and Estado = 2;";
            else if(asistioCitas)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal and Estado = 3;";
            if (todasCitasT)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador;";
            else if (disponibleCitasT)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and Estado = 0;";
            else if (ocupadaCitasT)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and Estado = 1;";
            else if (expiroCitasT)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and Estado = 2";
            else if (asistioCitasT)
                Query = "select count(*) as countCita from tbCitas where IdCoordinador = @IdCoordinador and Estado = 3;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
                countCita = (int)CheckDbNull(DataReader["countCita"], TipoDeObjeto.TipoInteger);

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

        return countCita;
    }

    public List<csCita> GetListCitaByIdCoordinador(int IdCoordinador)
    {
        List<csCita> listCita = new List<csCita>();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";
            SqlParameter Data = new SqlParameter("@IdCoordinador", IdCoordinador);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbCitas where IdCoordinador = @IdCoordinador order by FechaDisponible desc, Estado asc;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                csCita Cita = new csCita();
                Cita.LoadEventFromDataReader(DataReader);
                listCita.Add(Cita);
            }

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

        return listCita;
    }

    public List<csCita> GetListCitaById(int IdUsuario)
    {
        List<csCita> listCita = new List<csCita>();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";
            SqlParameter Data = new SqlParameter("@IdUsuario", IdUsuario);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbCitas where IdUsuario = @IdUsuario order by FechaDisponible desc;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                csCita Cita = new csCita();
                Cita.LoadEventFromDataReader(DataReader);
                listCita.Add(Cita);
            }

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

        return listCita;
    }

    public List<csCita> GetListCitas(int idCarrera)
    {
        List<csCita> listCita = new List<csCita>();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";
            SqlParameter Data = new SqlParameter("@IdCarrera", idCarrera);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbCitas where IdCoordinador = @IdCarrera and Estado = 0 order by FechaDisponible asc;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                csCita Cita = new csCita();
                Cita.LoadEventFromDataReader(DataReader);
                listCita.Add(Cita);
            }

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

        return listCita;
    }
    public List<csCita> GetListCitas(int idCarrera, DateTime dateTime)
    {
        List<csCita> listCita = new List<csCita>();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";
            SqlParameter[] Data = new SqlParameter[2];
            Data[0] = new SqlParameter("@IdCarrera", idCarrera);
            Data[0].DbType = DbType.Int32;
            Data[1] = new SqlParameter("@FechaDisponible", dateTime);
            Data[1].DbType = DbType.DateTime;

            String Query = "select * from tbCitas where IdCoordinador = @IdCarrera and FechaDisponible > @FechaDisponible and Estado = 0 order by FechaDisponible asc;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                csCita Cita = new csCita();
                Cita.LoadEventFromDataReader(DataReader);
                listCita.Add(Cita);
            }

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

        return listCita;
    }

    public List<csCita> GetListCitas(int idCarrera, DateTime fechaInicial, DateTime fechaFinal)
    {
        List<csCita> listCita = new List<csCita>();

        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();
            //String Query = "select * from tbCitas where IdAdministrador = @IdAdministrador and Disponible = 1;";
            SqlParameter[] Data = new SqlParameter[3];
            Data[0] = new SqlParameter("@IdCarrera", idCarrera);
            Data[0].DbType = DbType.Int32;
            Data[1] = new SqlParameter("@FechaInicial", fechaInicial);
            Data[1].DbType = DbType.DateTime;
            Data[2] = new SqlParameter("@FechaFinal", fechaFinal);
            Data[2].DbType = DbType.DateTime;

            //String Query = "select * from tbCitas where IdCoordinador = @IdCarrera and FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal and Estado <> 0 order by FechaDisponible asc;";
            String Query = "select * from tbCitas where IdCoordinador = @IdCarrera and FechaDisponible > @FechaInicial and FechaDisponible < @FechaFinal and Estado = 1 order by FechaDisponible asc;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            while (DataReader.Read())
            {
                csCita Cita = new csCita();
                Cita.LoadEventFromDataReader(DataReader);
                listCita.Add(Cita);
            }

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

        return listCita;
    }

    public int CheckCitaAndAddCita(csCita Cita)//CheckCitaAndAddCitaMotivo(csCita Cita, int IdMotivo)
    {
        int checkCita = 0; // 0 se la ganaron, 1 se agendo, 2 ya tiene una cita
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);

        try
        {
            Connection.Open();

            SqlParameter Data = new SqlParameter("@IdCita", Cita.IdCita);
            Data.DbType = DbType.Int32;

            String Query = "select * from tbCitas where IdCita = @IdCita and Estado = 0;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();

            if (DataReader.Read())
            {
                DataReader.Dispose();

                Data = new SqlParameter("@IdUsuario", Cita.IdUsuario);
                Data.DbType = DbType.Int32;

                Query = "select * from tbCitas where IdUsuario = @IdUsuario and Estado = 1;";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Add(Data);
                DataReader = Command.ExecuteReader();

                if (DataReader.Read())
                    checkCita = 2;
                else
                {
                    DataReader.Dispose();
                    
                    SqlParameter[] _Data = new SqlParameter[4];
                    _Data[0] = new SqlParameter("@IdUsuario", Cita.IdUsuario);
                    _Data[0].DbType = DbType.Int32;
                    _Data[1] = new SqlParameter("@FechaAgendada", Cita.FechaAgendada);
                    _Data[1].DbType = DbType.DateTime;
                    _Data[2] = new SqlParameter("@Estado", Cita.Estado);
                    _Data[2].DbType = DbType.Int32;
                    _Data[3] = new SqlParameter("@IdCita", Cita.IdCita);
                    _Data[3].DbType = DbType.Int32;

                    Query = "update tbCitas set IdUsuario = @IdUsuario, FechaAgendada = @FechaAgendada, Estado = @Estado where IdCita = @IdCita;";

                    Command = new SqlCommand(Query, Connection);
                    Command.Parameters.AddRange(_Data);
                    DataReader = Command.ExecuteReader();

                    //_Data = new SqlParameter[2];
                    //_Data[0] = new SqlParameter("@IdMotivo", IdMotivo);
                    //_Data[0].DbType = DbType.Int32;
                    //_Data[1] = new SqlParameter("@IdCita", Cita.IdCita);
                    //_Data[1].DbType = DbType.Int32;

                    //DataReader.Dispose();

                    //Query = "insert into tbRelacionMotivosCitas (IdCita, IdMotivo) values (@IdCita, @IdMotivo);";

                    //Command = new SqlCommand(Query, Connection);
                    //Command.Parameters.AddRange(_Data);
                    //DataReader = Command.ExecuteReader();

                    DataReader.Dispose();

                    checkCita = 1;
                }
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

        return checkCita;
    }

    public void AddNewCita(csCita Cita)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        if (Cita.FechaDisponible >= DateTime.Now && CheckDate(Cita.FechaDisponible))
        {
            try
            {
                Connection.Open();

                SqlParameter[] Data = new SqlParameter[2];
                Data[0] = new SqlParameter("@IdCoordinador", Cita.IdCoordinador);
                Data[0].DbType = DbType.Int32;
                Data[1] = new SqlParameter("@FechaDisponible", Cita.FechaDisponible);
                Data[1].DbType = DbType.Date;

                String Query = "insert into tbCitas (IdCoordinador, FechaDisponible) values (@IdCoordinador, @FechaDisponible);";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddRange(Data);
                Command.ExecuteReader();

            }
            catch (Exception ex)
            {
                LogError(ex.Message + ex.StackTrace + ex.Source);
            }
            finally
            {
                Connection.Close();
                Connection = null;
            }
        }
      
    }
    public bool CheckDate(DateTime fdisponible)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);
        try
        {
            Connection.Open();

            SqlParameter[] Data = new SqlParameter[1];
            Data[0] = new SqlParameter("@FechaDisponible", fdisponible);
            Data[0].DbType = DbType.Date;
            String Query = "select * from tbcitas where tbcitas.fechadisponible = @FechaDisponible ";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            int res = Convert.ToInt16(Command.ExecuteScalar());
            if (res>0) 
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        catch
        {
            return false;
        }
      

        
    }
    public bool UpdateCita(csCita Cita)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);

        bool error = false;

        try
        {
            Connection.Open();
            String Query = "update tbCitas set IdUsuario = @IdUsuario, FechaAgendada = @FechaAgendada, Estado = @Estado, Comentario = @Comentario where IdCita = @IdCita;";
            SqlParameter[] Data = new SqlParameter[5];
            Data[0] = new SqlParameter("@IdUsuario", Cita.IdUsuario);
            Data[0].DbType = DbType.Int32;
            Data[1] = new SqlParameter("@FechaAgendada", Cita.FechaAgendada);
            Data[1].DbType = DbType.DateTime;
            Data[2] = new SqlParameter("@Estado", Cita.Estado);
            Data[2].DbType = DbType.Int32;
            Data[3] = new SqlParameter("@Comentario", Cita.Comentario);
            Data[3].DbType = DbType.String;
            Data[4] = new SqlParameter("@IdCita", Cita.IdCita);
            Data[4].DbType = DbType.Int32;

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            Command.ExecuteReader();
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
            error = true;
        }
        finally
        {
            Connection.Close();
            Connection = null;
        }

        return error;
    }

    public bool DeleteCita(int IdCita)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);

        bool error = false;

        try
        {
            Connection.Open();
            String Query = "delete from tbCitas where IdCita = @IdCita;";
            SqlParameter Data = new SqlParameter("@IdCita", IdCita);
            Data.DbType = DbType.Int32;
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add(Data);
            SqlDataReader DataReader = Command.ExecuteReader();
        }
        catch (Exception ex)
        {
            LogError(ex.Message);
            error = true;
        }
        finally
        {
            Connection.Close();
            Connection = null;
        }

        return error;
    }

    public bool Delete(int IdCita, int estadoCita)
    {
        String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;
        SqlConnection Connection = new SqlConnection(ConnectionString);

        bool error = false;

        try
        {
            Connection.Open();

            SqlParameter[] Data = new SqlParameter[2];
            Data[0] = new SqlParameter("@IdCita", IdCita);
            Data[0].DbType = DbType.Int32;
            Data[1] = new SqlParameter("@Estado", estadoCita);
            Data[1].DbType = DbType.Int32;

            LogError(IdCita.ToString());
            String Query = "update tbCitas set Estado = @Estado where IdCita = @IdCita;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddRange(Data);
            SqlDataReader DataReader = Command.ExecuteReader();
        }
        catch (Exception ex)
        {
            LogError(ex.Message + ex.StackTrace);
            error = true;
        }
        finally
        {
            Connection.Close();
            Connection = null;
        }

        return error;
    }
}