using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Capa.BE;
using Capa.DAO;

namespace Capa.BL
{
    public class RegisterBL
    {
        RegisterDAO _instance = RegisterDAO.GetInstance();

        public bool CreateUser(UsuarioBE usuarioBE, string cnn)
        {
            if(usuarioBE.firstName == string.Empty && usuarioBE.lastName == string.Empty)
            {
                return false;
            }
            if(usuarioBE.email == string.Empty && usuarioBE.pass == string.Empty)
            {
                return false;
            }
            return _instance.CreateUser(usuarioBE, cnn);
        }
        public async Task enviarCorreo(UsuarioBE usuarioBE)
        {
            try
            {
                string addressto = "miCorreo@gmail.com";
                string password = "MiContraseña1111";
                int port = 587;
                string subject = "Tiendas URBAN te da la Bienvenida";
                string body = "Bienvenido "+usuarioBE.firstName+" "+usuarioBE.lastName+",\nTiendas Urban te informa que por ser nuevo cliente tienes muchos cupones de descuento."+
                              "\nNo dejes pasar esta increible oportunidad.\n\nMensaje de Prueba";
                string server = "smtp.gmail.com";
                SmtpClient SmtpServer = new SmtpClient(server);
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(usuarioBE.email);
                mail.Subject = subject;
                mail.Body = body;
                mail.To.Add(usuarioBE.email);
                

                SmtpServer.Port = port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(addressto, password);
                SmtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);
                await SmtpServer.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
