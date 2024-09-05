using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace PassDataViewAndControls.Controllers
{
    public class MailController : Controller
    {
        private readonly ILogger<MailController> _logger;

        public MailController(ILogger<MailController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("İletişim Formu Yükleniyor...", typeof(MailController));
            return View();
        }

        [HttpPost]
        public IActionResult Index(string txtEmail, string txtKonu, string txtMesaj)
        {
            string msg = string.Empty;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient();

                mail.From = new MailAddress("info@contoso.com", "Contoso Inc.");
                mail.To.Add(txtEmail);
                mail.Subject = txtKonu;
                mail.IsBodyHtml = true;
                mail.Body = txtMesaj;
                smtpServer.Port = 587;
                smtpServer.Host = "smtp.gmail.com";
                smtpServer.EnableSsl = true;
                smtpServer.UseDefaultCredentials = false;
                smtpServer.Credentials = new NetworkCredential("user", "password");
                smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpServer.Send(mail);
                msg = "Mail Gönderildi";
                ViewBag.result = msg;
                _logger.LogInformation(msg);
            }
            catch(Exception ex)
            {
                msg = "Hata : " + ex.Message;
                ViewBag.Result = msg;
                _logger.LogWarning(msg);
            }

            return View();
        }
    }
}
