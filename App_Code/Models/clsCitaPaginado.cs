using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de clsCitaPaginado
/// </summary>
public class clsCitaPaginado
{

    public List<csCita> listCitas { get; set; }

    public clsCitaPaginado()
    {
        listCitas = new List<csCita>();
    }
}