using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de clsCitas
/// </summary>
public class csCita : ObjetoBase
{
    public int IdCita { get; set; }
    public int IdCoordinador { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaAgendada { get; set; }
    public DateTime FechaDisponible { get; set; }
    public int Estado { get; set; }
    public string Comentario { get; set; }

	public csCita()
	{
        IdCita = 0;
        IdCoordinador = 0;
        IdUsuario = 0;
        FechaAgendada = DateTime.Now;
        FechaDisponible = DateTime.Now;
        Estado = 0;
        Comentario = "";
	}

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdCita = (int)CheckDbNull(DataReader["IdCita"], TipoDeObjeto.TipoInteger);
        IdCoordinador = (int)CheckDbNull(DataReader["IdCoordinador"], TipoDeObjeto.TipoInteger);
        IdUsuario = (int)CheckDbNull(DataReader["IdUsuario"], TipoDeObjeto.TipoInteger);
        FechaAgendada = (DateTime)CheckDbNull(DataReader["FechaAgendada"], TipoDeObjeto.TipoDateTime);
        FechaDisponible = (DateTime)CheckDbNull(DataReader["FechaDisponible"], TipoDeObjeto.TipoDateTime);
        Estado = (int)CheckDbNull(DataReader["Estado"], TipoDeObjeto.TipoInteger);
        Comentario = (string)CheckDbNull(DataReader["Comentario"], TipoDeObjeto.TipoString);
    }
}