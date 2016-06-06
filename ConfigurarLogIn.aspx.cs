using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private string sel;
    List<ListItem> archivos = new List<ListItem>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dropImgServer.Items.Clear();
            cargarDrop();
            dropFiles.Items.Clear();
            cargarDropNoticia();
        }        
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        Boolean extensionOK = false;
        string path = Server.MapPath("~/Img/ImgLogIn/Resources/");
        if (fupArchivo.HasFile)
        {
            string fileextension = System.IO.Path.GetExtension(fupArchivo.FileName);
            string[] extensionesp = { ".gif", ".png", ".jpg", ".jpeg",".PNG",".JPG",".JPEG" };
            for (int i = 0; i < extensionesp.Length; i++)
            {
                if (fileextension == extensionesp[i])
                {
                    extensionOK = true;
                    break;
                }
            }
            if (extensionOK)
            {
                try
                {
                    fupArchivo.PostedFile.SaveAs(path + fupArchivo.FileName);
                    Response.Redirect("~/ConfigurarLogIn.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("<script language='JavaScript'>alert('Error al guardar.');</script>");
                    throw;
                }
            }
            else
            {
                Response.Write("<script language='JavaScript'>alert('Tipo de Dato Incorrecto.');</script>");
            }
        }
        else
        {
            Response.Write("<script language='JavaScript'>alert('No selecciono Archivo.');</script>");
        }
    }
    private void cargarDrop()
    {
        List<ListItem> archivos = new List<ListItem>();
        string[] path = Directory.GetFiles(Server.MapPath("~/Img/ImgLogIn/Resources/"));
        foreach (string filepath in path)
        {
            if (!Path.GetFileName(filepath).Equals("logo_ith-bien.png"))
            {
                archivos.Add(new ListItem(Path.GetFileName(filepath), Path.GetFileName(filepath)));
            }            
        }
        dropImgServer.DataSource = archivos;
        dropImgServer.DataBind();
        this.archivos = archivos;
    }

    private void cargarDropNoticia()
    {
        List<ListItem> archivos = new List<ListItem>();
        string[] path = Directory.GetFiles(Server.MapPath("~/Img/ImgLogIn/Noticias"));
        if (path.Length>0)
        {
            foreach (string filepath in path)
            {
                archivos.Add(new ListItem(Path.GetFileName(filepath), Path.GetFileName(filepath)));
            }
            dropFiles.DataSource = archivos;
            dropFiles.DataBind();
        }        
    }
    protected void btnSelectImg_Click(object sender, EventArgs e)
    {
        sel = dropImgServer.Value;
        VistaPrevia.Src = "~/Img/ImgLogIn/Resources/" + dropImgServer.Value;
        cargarDrop();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (!"logo_ith-bien.png".Equals(dropImgServer.Value))
            {
                string delete = Server.MapPath("~/Img/ImgLogIn/Resources/") + dropImgServer.Value;
                File.Delete(delete);
                Response.Redirect("~/ConfigurarLogIn.aspx");
            }
            
        }
        catch (Exception exp)
        {
            Response.Write("<script language='JavaScript'>alert('Error al Eliminar.')</script>");
        }        
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string datos = txttitulo.Text + "|" + txtCuerpo.Text;
            DateTime time = DateTime.Now;
            FileStream archivo;
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(datos);
            archivo = File.Create(Server.MapPath("~/Img/ImgLogIn/Noticias/") + String.Format("{0:dd-MM-yyyy HH-mm}", time) + ".txt");
            archivo.Write(bytes, 0, bytes.Length);
            archivo.Flush();
            archivo.Close();
            archivo.Dispose();
            Response.Write("<script language='JavaScript'>alert('Noticia Agregada Correctamente.')</script>");
            Response.Redirect("~/ConfigurarLogIn.aspx");
        }
        catch (Exception)
        {
            Response.Write("<script language='JavaScript'>alert('Error al Agregar Noticia.')</script>");
        }
    }

    protected void btnVistaNoticia_Click(object sender, EventArgs e)
    {
        try
        {
            using (StreamReader file = new StreamReader(Server.MapPath("~/Img/ImgLogIn/Noticias/") + dropFiles.SelectedValue))
            {
                string contenido = "";
                contenido = file.ReadToEnd();
                string[] dividir = contenido.Split('|');
                if (dividir.Length > 0)
                {
                    tituloSpan.InnerText = dividir[0];
                    Cuerpo.InnerText = dividir[1];
                }
            }
        }
        catch (Exception)
        {
            Response.Write("<script language='JavaScript'>alert('Error al Cargar Noticia.')</script>");
        }
    }

    protected void btnEliminarNoticia_Click(object sender, EventArgs e)
    {
        try
        {
            string delete = Server.MapPath("~/Img/ImgLogIn/Noticias/") + dropFiles.SelectedValue;
            File.Delete(delete);
            Response.Write("<script language='JavaScript'>alert('Noticia Eliminada.')</script>");
            Response.Redirect("~/ConfigurarLogIn.aspx");
        }
        catch (Exception)
        {
            Response.Write("<script language='JavaScript'>alert('Error al Eliminar Noticia.')</script>");
        }
    }
}