using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csMotivo
/// </summary>
public class csMotivo : ObjetoBase
{
    public int IdMotivo { get; set; }
    public string Motivo { get; set; }

    public csMotivo()
    {
        IdMotivo = 0;
        Motivo = "";
    }

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdMotivo = (int)CheckDbNull(DataReader["IdMotivo"], TipoDeObjeto.TipoInteger);
        Motivo = (string)CheckDbNull(DataReader["Motivo"], TipoDeObjeto.TipoString);
    }
}