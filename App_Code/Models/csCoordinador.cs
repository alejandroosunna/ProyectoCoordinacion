using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de clsAdministrador
/// </summary>
public class csCoordinador : ObjetoBase
{
    public int IdCoordinador { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Contraseña { get; set; }

	public csCoordinador()
	{
        IdCoordinador = 0;
        Nombre = "";
        Apellidos = "";
        Contraseña = "";
	}

    public void LoadEventFromDataReader(SqlDataReader DataReader)
    {
        IdCoordinador = (int)CheckDbNull(DataReader["IdUsuario"], TipoDeObjeto.TipoInteger);
        Nombre = (string)CheckDbNull(DataReader["Nombre"], TipoDeObjeto.TipoString);
        Apellidos = (string)CheckDbNull(DataReader["Apellidos"], TipoDeObjeto.TipoString);
        Contraseña = (string)CheckDbNull(DataReader["Contraseña"], TipoDeObjeto.TipoString);
    }
}