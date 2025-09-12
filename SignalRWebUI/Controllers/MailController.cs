using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;            // ✅ MailKit SmtpClient
using MimeKit;                     // ✅ MimeMessage, BodyBuilder
using SignalRWebUI.Dtos.MailDtos;
namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon","mail"); 
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            mimeMessage.Subject = createMailDto.Subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mail", "key");
            client.Send(mimeMessage);
            client.Disconnect(true);     

            return RedirectToAction("Index", "Category");
        }

    }
}