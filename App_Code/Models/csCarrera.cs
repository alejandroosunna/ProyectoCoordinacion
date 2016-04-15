using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de csCarrera
/// </summary>
public class csCarrera
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
}