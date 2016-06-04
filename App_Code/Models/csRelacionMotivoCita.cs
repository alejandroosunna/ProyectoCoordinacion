using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csRelacionMotivoCita
/// </summary>
public class csRelacionMotivoCita : ObjetoBase
{

    public int IdCita { get; set; }
    public int IdMotivo { get; set; }

    public csRelacionMotivoCita()
    {
        IdCita = 0;
        IdMotivo = 0;
    }

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdCita = (int)CheckDbNull(DataReader["IdCita"], TipoDeObjeto.TipoInteger);
        IdMotivo = (int)CheckDbNull(DataReader["IdMotivo"], TipoDeObjeto.TipoInteger);
    }
}