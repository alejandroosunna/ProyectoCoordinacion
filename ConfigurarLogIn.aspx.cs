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
        }        
    }

    protected void btnSubir_Click(object sender, EventArgs e)
    {
        Boolean extensionOK = false;
        string path = Server.MapPath("~/Img/ImgLogIn/Resources/");
        if (fupArchivo.HasFile)
        {
            string fileextension = System.IO.Path.GetExtension(fupArchivo.FileName);
            string[] extensionesp = { ".gif", ".png", ".jpg", ".jpeg" };
            for (int i = 0; i < extensionesp.Length; i++)
            {
                if (fileextension == extensionesp[i])
                {
                    extensionOK = true;
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
            Response.Write("<script language='JavaScript'>alert('Error al Eliminar.');</script>");
            throw;
        }        
    }

    protected void btnOp1_Click(object sender, EventArgs e)
    {
        try
        {
            sel = Path.GetFileName(VistaPrevia.Src);
            if (!sel.Equals("logo_ith-bien.png"))
            {
                string fileToCopy = Server.MapPath("~/Img/ImgLogIn/Resources/") + sel;
                string fileDest = Server.MapPath("~/Img/ImgLogIn/Selected/" + "opt1" + Path.GetExtension(Server.MapPath("~/Img/ImgLogIn/Resources/") + sel));
                File.Copy(fileToCopy, fileDest, true);
                Response.Write("<script language='JavaScript'>alert('Imagen Seleccionada en Opcion 1.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language='JavaScript'>alert('No se pudo Seleccionar Imagen.');</script>");
            throw;
        }      
    }

    protected void btbOp2_Click(object sender, EventArgs e)
    {
        try
        {
            sel = Path.GetFileName(VistaPrevia.Src);
            if (!sel.Equals("logo_ith-bien.png"))
            {
                string fileToCopy = Server.MapPath("~/Img/ImgLogIn/Resources/") + sel;
                string fileDest = Server.MapPath("~/Img/ImgLogIn/Selected/" + "opt2" + Path.GetExtension(Server.MapPath("~/Img/ImgLogIn/Resources/") + sel));
                File.Copy(fileToCopy, fileDest, true);
                Response.Write("<script language='JavaScript'>alert('Imagen Seleccionada en Opcion 2.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language='JavaScript'>alert('No se pudo Seleccionar Imagen.');</script>");
            throw;
        }
    }

    protected void btnOp3_Click(object sender, EventArgs e)
    {
        try
        {
            sel = Path.GetFileName(VistaPrevia.Src);
            if (!sel.Equals("logo_ith-bien.png"))
            {
                string fileToCopy = Server.MapPath("~/Img/ImgLogIn/Resources/") + sel;
                string fileDest = Server.MapPath("~/Img/ImgLogIn/Selected/" + "opt3" + Path.GetExtension(Server.MapPath("~/Img/ImgLogIn/Resources/") + sel));
                File.Copy(fileToCopy, fileDest, true);
                Response.Write("<script language='JavaScript'>alert('Imagen Seleccionada en Opcion 3.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language='JavaScript'>alert('No se pudo Seleccionar Imagen.');</script>");
            throw;
        }
    }
}