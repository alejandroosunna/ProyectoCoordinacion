using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csCarrera
/// </summary>
public class csCarrera : ObjetoBase
{
    public int IdCarrera { get; set; }
    public int IdReticula { get; set; }
    public string Nombre { get; set; }

    public csCarrera()
    {
        IdCarrera = 0;
        IdReticula = 0;
        Nombre = "";
    }

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdCarrera = (int)CheckDbNull(DataReader["IdCarrera"], TipoDeObjeto.TipoInteger);
        IdReticula = (int)CheckDbNull(DataReader["IdReticula"], TipoDeObjeto.TipoInteger);
        Nombre = (string)CheckDbNull(DataReader["Nombre"], TipoDeObjeto.TipoString);
    }
}