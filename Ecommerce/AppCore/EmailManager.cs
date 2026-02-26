using Entities_DTOs;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace AppCore
{
    public class EmailManager
    {
        private readonly IConfiguration _config;

        // Se inyecta IConfiguration desde Program.cs
        public EmailManager(IConfiguration config)
        {
            _config = config;
        }

        public void SendWelcomeEmail(User u)
        {
            try
            {
                // Leer configuración desde appsettings.json
                var server = _config["SmtpSettings:Server"];
                var port = int.Parse(_config["SmtpSettings:Port"]);
                var user = _config["SmtpSettings:User"];
                var password = _config["SmtpSettings:Password"];
                var enableSsl = bool.Parse(_config["SmtpSettings:EnableSsl"]);

                // Configura el mensaje
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(user);
                mail.To.Add(u.Email);
                mail.Subject = "Bienvenido al sistema";
                mail.Body = $"Hola {u.Name}\n\n¡Bienvenid@! Gracias por registrarte en nuestra App.";

                // Configura el servidor SMTP
                SmtpClient smtp = new SmtpClient(server, port);
                smtp.Credentials = new NetworkCredential(user, password);
                smtp.EnableSsl = enableSsl;

                // Envía el correo
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error enviando correo: " + ex.Message);
            }
        }
    }
}

