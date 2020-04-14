using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextilWorld.Models;

namespace TextilWorld.Services {
    /// <summary>
    /// Сервис отправляет сообщение на почту.
    /// </summary>
    public class SendMessageService {
        public static async Task<string> SendMessage(Message message) {
            try {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("textil@home-textiles.ru"));
                emailMessage.To.Add(new MailboxAddress("textil@home-textiles.ru"));
                emailMessage.Subject = "Новый заказ";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                    Text = "Имя: " + message.Name + "</br>" +
                "Телефон или email: " + message.Number + "</br>" +
                "Интересует: " + message.Product
                };
                using (var client = new SmtpClient()) {
                    await client.ConnectAsync("mail.hosting.reg.ru", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("textil@home-textiles.ru", "tQb6@n20");
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex) {
                throw new ArgumentException(ex.Message.ToString());
            }
            return "Ok";
        }
    }
}
