using EmailServiceApp.Domain.Services;
using EmailServiceApp.services.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailServiceApp.services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly SendEmailService _emailService;

        public SendEmailController(SendEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("sendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest emailRequest)
        {
            // Criar o HTML do corpo do email
            string htmlBody = $@"
        <html>
        <body style='font-family: Arial, sans-serif;'>
            <h1 style='color: #07342C;'>Olá, {emailRequest.ToName}</h1>
            <p style='color: #2F2F2F;'>Estamos muito felizes em tê-lo conosco!</p>
            <p style='color: #2F2F2F;'>{emailRequest.Body}</p>            
        </body>
        </html>";

            
        await _emailService.SendEmailAsync(emailRequest.ToEmail, emailRequest.Subject, htmlBody);
        return Ok("Email enviado com sucesso!");
        }
    }
}
