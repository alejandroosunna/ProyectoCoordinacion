using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CitaEdit
/// </summary>
public class CitaEdit
{
    public int id { get; set; }
    public int idUsuario { get; set; }
    public System.DateTime fechaDisponible { get; set; }
    public int estado { get; set; }
    public string comentario { get; set; }
}