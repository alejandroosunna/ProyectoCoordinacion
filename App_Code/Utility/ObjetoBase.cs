using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ObjetoBase
/// </summary>
public class ObjetoBase
{
    public enum TipoDeObjeto
    {
        TipoString = 0,
        TipoInteger = 1,
        TipoDouble = 2,
        TipoDateTime = 3,
        TipoBoolean = 4
    }

	public ObjetoBase()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public void LogError(string sError)
    {
        System.IO.StreamWriter ArchivoW;
        string strLineaTMP;
        string Minuto;
        //DateTime dt = DateTime.Now;

        Minuto = DateTime.Now.Minute.ToString();
        if (Minuto.Length == 1)
            Minuto = "0" + Minuto;

        strLineaTMP = "\n" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " " + DateTime.Now.Hour + ":" + Minuto + ". " + sError + "\n";
        try
        {
            ArchivoW = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Log.txt", true, System.Text.Encoding.UTF8);

            try
            {
                ArchivoW.Write(strLineaTMP);
            }
            catch (Exception)
            {
            }
            ArchivoW.Close();
        }
        catch (UnauthorizedAccessException)
        {
        }
    }

    public Object CheckDbNull(Object Objeto, TipoDeObjeto _TipoDeObjeto)
    {
        if (_TipoDeObjeto == TipoDeObjeto.TipoString && DBNull.Value == Objeto)
            return "";
        else if (_TipoDeObjeto == TipoDeObjeto.TipoInteger && DBNull.Value == Objeto)
            return 0;
        else if (_TipoDeObjeto == TipoDeObjeto.TipoDouble && DBNull.Value == Objeto)
            return 0.0;
        else if (_TipoDeObjeto == TipoDeObjeto.TipoDateTime && DBNull.Value == Objeto)
            return DateTime.Now;
        else if (_TipoDeObjeto == TipoDeObjeto.TipoBoolean && DBNull.Value == Objeto)
            return false;

        return Objeto;
    }
}