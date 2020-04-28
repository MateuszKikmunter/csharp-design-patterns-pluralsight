using StrategyPattern.Business.Models.Strategies.Abstract;
using System.Net;
using System.Net.Mail;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class EmailStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);

            using (var client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                var credentials = new NetworkCredential("your-user-name", "your-password");
                client.Credentials = credentials;

                var mail = new MailMessage("your-email-address", "recipient-email")
                {
                    Subject = "We've created an invoice for your order.",
                    Body = body
                };

                client.Send(mail);
            }
        }
    }
}
