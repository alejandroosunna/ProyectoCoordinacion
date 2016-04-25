using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UCoordinador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["Id"] != null)
            {
                int result = 0;
                if (Int32.TryParse(Request["Id"].ToString(), out result))
                {
                    csUsuario Usuario = (new csUsuarioHandler()).GetUsuario(result);
                    //(new ObjetoBase()).LogError(Usuario.IdCarrera.ToString());
                    txtNumControl.Text = Usuario.IdUsuario.ToString();
                    txtNombre.Text = Usuario.Nombre;
                    txtApellidos.Text = Usuario.Nombre;
                    //DropDListCarrera.SelectedItem.Text = (new csCarreraHandler()).GetCarrera(Usuario.IdCarrera).Nombre;
                    txtContraseña.Text = Usuario.Contraseña;
                }
            }
        }
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        int IdUsuario = 0;
        csUsuario Usuario = new csUsuario();

        Usuario.IdUsuario = Convert.ToInt32(txtNumControl.Text);
        Usuario.Nombre = txtNombre.Text;
        Usuario.Apellidos = txtApellidos.Text;
        Usuario.IdRol = 1;
        //Usuario.IdCarrera = Convert.ToInt32(DropDListCarrera.SelectedItem.Value);
        Usuario.Contraseña = txtContraseña.Text;

        if (Request["Id"] != null)
        {
            if (Int32.TryParse(Request["Id"], out IdUsuario))
            {
                if (!(new csUsuarioHandler()).UpdateUsuario(Usuario, IdUsuario))
                    Response.Redirect("~\\Coordinador.aspx?Up=ex");
                else
                    Response.Redirect("~\\Coordinador.aspx?Up=err");
            }
        }
    }
}