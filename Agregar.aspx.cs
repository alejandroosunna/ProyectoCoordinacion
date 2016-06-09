using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Drawing;
using System.Configuration;
public partial class Agregar : System.Web.UI.Page
{
    String ConnectionString = ConfigurationManager.ConnectionStrings["dbProyectoCoordinacion"].ConnectionString;

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        var idCarrera = Convert.ToInt32(Session["IdCarrera"]);


        if ((new csUsuarioHandler()).ObtenerLista().Count == 0)
        {
            if (FileUpload1.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if ((extension == ".xls") || (extension == ".xlsx"))
                {
                    try
                    {


                        string ruta = string.Concat((Server.MapPath("~/Temp/" + FileUpload1.FileName)));
                        FileUpload1.PostedFile.SaveAs(ruta);


                        OleDbConnection OleDcon = new OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source =" + ruta + ";Extended Properties=Excel 12.0");
                        OleDbCommand cmd = new OleDbCommand("select IdUsuario," + idCarrera + ",2,Nombre,Apellidos,Contraseña  from [Hoja1$]", OleDcon);
                        OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);


                        //configurar con el apuntador de base de datos indicado
                        OleDcon.Open();
                        DbDataReader dr = cmd.ExecuteReader();


                        SqlBulkCopy bulkInsert = new SqlBulkCopy(ConnectionString);
                        bulkInsert.DestinationTableName = "tbUsuarios";
                        bulkInsert.WriteToServer(dr);
                        OleDcon.Close();
                        Array.ForEach(Directory.GetFiles((Server.MapPath("~/Temp/"))), File.Delete);
                        Label1.ForeColor = Color.Green;
                        Label1.Text = " Listo";

                    }
                    catch (Exception ex)
                    {
                        Response.Write(@"<script language = 'javascript'>alert('Error al subir el archivo.') </script>");


                    }

                }
                else
                {
                    Response.Write(@"<script language = 'javascript'>alert('Error, el tipo de archivo no es valido') </script>");
                }
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "seleccionar archivo";
            }
        }
        else
        {
            Response.Write(@"<script language = 'javascript'>alert('Error, debe eliminar los alumnos ya registrados para continuar.') </script>");
            //Response.Write(@"<script language = 'javascript'>swal('Error','debe eliminar','error') </script>");
        }
    }
    
}