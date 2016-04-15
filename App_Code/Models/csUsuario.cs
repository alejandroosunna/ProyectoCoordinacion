using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de clsAlumnos
/// </summary>
public class csUsuario : ObjetoBase
{
    public int IdUsuario { get; set; }
	public int IdCarrera { get; set; }
    public int IdRol { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Contraseña { get; set; }

	public csUsuario()
	{
        IdUsuario = 0;
        IdCarrera = 0;
        IdRol = 0;
        Nombre = " ";
        Apellidos = " ";
        Contraseña = " ";
	}

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdUsuario = (int)CheckDbNull(DataReader["IdUsuario"], TipoDeObjeto.TipoInteger);
        IdCarrera = (int)CheckDbNull(DataReader["IdCarrera"], TipoDeObjeto.TipoInteger);
        IdRol = (int)CheckDbNull(DataReader["IdRol"], TipoDeObjeto.TipoInteger);
        Nombre = (string)CheckDbNull(DataReader["Nombre"], TipoDeObjeto.TipoString);
        Apellidos = (string)CheckDbNull(DataReader["Apellidos"], TipoDeObjeto.TipoString);
        Contraseña = (string)CheckDbNull(DataReader["Contraseña"], TipoDeObjeto.TipoString);
    }
}