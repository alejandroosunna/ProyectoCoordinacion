using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csCarrera
/// </summary>
public class csRol : ObjetoBase
{

    public int IdRol { get; set; }
    public string Tipo { get; set; }

    public csRol()
    {
        IdRol = 0;
        Tipo = "";
    }

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdRol = (int)CheckDbNull(DataReader["IdRol"], TipoDeObjeto.TipoInteger);
        Tipo = (string)CheckDbNull(DataReader["Tipo"], TipoDeObjeto.TipoString);
    }
}