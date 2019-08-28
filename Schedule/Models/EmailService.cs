using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Schedule.Models
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Campusom", "campusomteam@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(string.Empty, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("campusomteam@gmail.com", "ecampus5+");//move password to db
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
