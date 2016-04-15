using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Descripción breve de Emailhtml
/// </summary>
public class Emailhtml
{
     MailMessage msg = new MailMessage();
     SmtpClient smtp = new SmtpClient();

	
    public bool enviarcorreo(string nombre, string email, string mensaje)
    {
        try
        {
            msg.From = new MailAddress("sugerenciassiac@outlook.com");
            msg.To.Add(new MailAddress("soportesiac@outlook.com"));
            msg.Body = "Nombre: "+ nombre + "\n E-mail: " + email + "\n Mensage: " + mensaje;
            msg.Subject = email;
            smtp.Host = "smtp.live.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("sugerenciassiac@outlook.com", "SIAC2015");
            smtp.EnableSsl = true;
            smtp.Send(msg);
            //msg.IsBodyHtml = true;
            return true;

        }
        catch
        {
            return false;
        }
       
    }
}