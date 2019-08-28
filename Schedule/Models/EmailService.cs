using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class EmailService
    {
        public async Task SendEmailAsync(string username, string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "rus.gumeniuk@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(username, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 25, false);
                await client.AuthenticateAsync("rus.gumeniuk@gmail.com", "password");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
