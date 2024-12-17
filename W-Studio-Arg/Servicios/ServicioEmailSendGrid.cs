using System.Net;
using System.Net.Mail;
using W_Studio_Arg.Models;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmail : IServicioEmail
    {
        private readonly IConfiguration _configuration;

        public ServicioEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            // Obtener configuración desde appsettings.json
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_configuration["EmailSettings:Port"]);
            var fromEmail = _configuration["EmailSettings:From"];
            var password = _configuration["EmailSettings:Password"];
            var enableSsl = bool.Parse(_configuration["EmailSettings:EnableSsl"]);

            // Configurar cliente SMTP
            var smtpClient = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = enableSsl
            };

            // Crear mensaje
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = $"Nuevo mensaje de {contacto.Nombre}",
                Body = $"<strong>Nombre:</strong> {contacto.Nombre}<br>" +
                       $"<strong>Email:</strong> {contacto.Email}<br>" +
                       $"<strong>Mensaje:</strong> {contacto.Mensaje}",
                IsBodyHtml = true
            };

            mailMessage.To.Add(fromEmail); // Envía el correo a ti mismo

            // Enviar correo
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
