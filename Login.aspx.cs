using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cargarNoticias();
            cargarImg();
        }
        catch (Exception)
        {
            Response.Write("<script language='JavaScript'>alert('Error al cargar.')</script>");
        }
        if (Session["IdUsuario"] != null)
        {
            csUsuario Usuario = (new csUsuarioHandler()).GetUsuario(Convert.ToInt32(Session["IdUsuario"]));

            if (Usuario.IdRol == 1)
                Response.Redirect("~\\IndexAdmin.aspx");
            else if (Usuario.IdRol == 2)
                Response.Redirect("~\\IndexAlumno.aspx");
            else if (Usuario.IdRol == 3)
                Response.Redirect("~\\IndexSAdmin.aspx");
        }
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int result;
        if (Int32.TryParse(txtNumControl.Text, out result))
        {
            csUsuario Usuario = (new csUsuarioHandler()).CheckLogin(result, txtContraseña.Text);
            //(new ObjetoBase()).LogError(Usuario.IdRol.ToString());

            if (Usuario.IdRol == 1)
            {
                Session["IdUsuario"] = Usuario.IdUsuario;
                Session["IdRol"] = Usuario.IdRol;
                Session["IdCarrera"] = Usuario.IdCarrera;
                Response.Redirect("~\\IndexAdmin.aspx");
            }
            else if (Usuario.IdRol == 2)
            {
                Session["IdUsuario"] = Usuario.IdUsuario;
                Session["IdRol"] = Usuario.IdRol;
                Session["IdCarrera"] = Usuario.IdCarrera;
                Response.Redirect("~\\IndexAlumno.aspx");
            }
            else if (Usuario.IdRol == 3)
            {
                Session["IdUsuario"] = Usuario.IdUsuario;
                Session["IdRol"] = Usuario.IdRol;
                Session["IdCarrera"] = Usuario.IdCarrera;
                Response.Redirect("~\\IndexSAdmin.aspx");
            }
            else if (Usuario.IdRol == 0)
                Response.Write(@"<script language = 'javascript'>alert('Credenciales incorrectas') </script>");
        }
        else
            Response.Write(@"<script language = 'javascript'>alert('Credenciales incorrectas') </script>");
    }
    private void cargarImg()
    {
        string[] files = Directory.GetFiles(Server.MapPath("~/Img/ImgLogIn/Resources/"));
        if (files.Length > 0)
        {
            slides.InnerHtml = "";
            for (int i = 0; i < files.Length; i++)
            {
                string img ="~/Img/ImgLogIn/Resources/"+  Path.GetFileName(files[i]);
                HtmlImage image = new HtmlImage();
                image.Src = img;
                image.Attributes.Add("class", "responsive-image");
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Controls.Add(image);
                slides.Controls.Add(li);
            }
        }  
    }
    private void cargarNoticias()
    {
        string[] files = Directory.GetFiles(Server.MapPath("~/Img/ImgLogIn/Noticias/"));
        if (files.Length > 0)
        {
            for (int i = 0; i < files.Length; i++)
            {
                using (StreamReader reader = new StreamReader(files[i]))
                {
                    string linea = reader.ReadToEnd();
                    string[] contenido = linea.Split('|');
                    HtmlGenericControl divtitle = new HtmlGenericControl("div");
                    HtmlGenericControl divbody = new HtmlGenericControl("div");
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    HtmlGenericControl head = new HtmlGenericControl("h5");
                    divtitle.Attributes.Add("class", "collapsible-header");
                    divbody.Attributes.Add("class", "collapsible-body");
                    head.InnerText = contenido[0];
                    divbody.InnerText = contenido[1];
                    divtitle.Controls.Add(head);
                    li.Controls.Add(divtitle);
                    li.Controls.Add(divbody);
                    noticias.Controls.Add(li);
                }
            }
        }
        else
        {
            HtmlGenericControl divtitle = new HtmlGenericControl("div");
            HtmlGenericControl divbody = new HtmlGenericControl("div");
            HtmlGenericControl li = new HtmlGenericControl("li");
            HtmlGenericControl head = new HtmlGenericControl("h5");
            divtitle.Attributes.Add("class", "collapsible-header");
            divbody.Attributes.Add("class", "collapsible-body");
            head.InnerText = "No hay Avisos o Noticias.";
            divbody.InnerText = "Sin noticias.";
            divtitle.Controls.Add(head);
            li.Controls.Add(divtitle);
            li.Controls.Add(divbody);
            noticias.Controls.Add(li);
        }
    }
}