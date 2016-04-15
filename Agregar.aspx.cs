using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agregar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdUsuario"] == null || Convert.ToInt16(Session["IdRol"])==2) 
            Response.Redirect("~\\Login.aspx");

    }
    protected void txtNumControl_TextChanged(object sender, EventArgs e)
    {
        txtContraseña.Text = Server.HtmlEncode(txtNumControl.Text);
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            csUsuario Usuario = new csUsuario();
            Usuario.IdCarrera = Convert.ToInt32(Session["IdCarrera"]);
            Usuario.IdRol = 2;
            Usuario.Nombre = txtNombre.Text;
            Usuario.Apellidos = txtApellidoPaterno.Text +  txtApellidoMaterno.Text;
            Usuario.Contraseña = txtContraseña.Text;
            Usuario.IdUsuario = Convert.ToInt32(txtNumControl.Text);


            (new csUsuarioHandler()).AddNewUsuario(Usuario);

            Response.Redirect("~\\Agregar.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(@"<script language = 'javascript'>alert('Error al agregar el usuario. Verifica que los datos sean los correctos.') </script>");
        }
    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session["IdAdministrador"] = null;
        Response.Redirect("~\\Login.aspx");
    }
}