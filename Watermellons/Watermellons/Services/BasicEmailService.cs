using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Watermellons.Services
{
    public class BasicEmailService : IEmailService
    {
        readonly MailAddress FROMADDRESS = new MailAddress("li.watermellon.demo@gmail.com", "LI Watermellon Demo");
        readonly string FROMPASSWORD = "W@T3RM3LL0N";

        public bool EmailMessage(string toAddress, string subject, string body)
        {

            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(FROMADDRESS.Address, FROMPASSWORD)
                };
                using (var message = new MailMessage(FROMADDRESS.Address, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}