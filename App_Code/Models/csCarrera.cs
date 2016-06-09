using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Data.SqlClient;
>>>>>>> refs/remotes/origin/master
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csCarrera
/// </summary>
<<<<<<< HEAD
public class csCarrera
=======
public class csCarrera : ObjetoBase
>>>>>>> refs/remotes/origin/master
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
<<<<<<< HEAD
=======

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdCarrera = (int)CheckDbNull(DataReader["IdCarrera"], TipoDeObjeto.TipoInteger);
        IdReticula = (int)CheckDbNull(DataReader["IdReticula"], TipoDeObjeto.TipoInteger);
        Nombre = (string)CheckDbNull(DataReader["Nombre"], TipoDeObjeto.TipoString);
    }
>>>>>>> refs/remotes/origin/master
}