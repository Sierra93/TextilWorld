using System;
using System.Collections.Generic;
using System.Text;
using WhatsAppApi;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Threading.Tasks;
using TextilWorld.Models;
using TextilWorld.Core;

namespace TextilWorld.Services {
    /// <summary>
    /// Сервис отправляет сообщение в WhatsApp.
    /// </summary>
    public class SendMessage {
        public static async Task<object> SendMessageToWhatsApp(Message message) {
            const string ACCOUNT_S_ID = "AC55de8cba556cb38987c3b1e470a6b3d9";
            const string AUTH_TOKEN = "89a85f834f52fb404dd0cd42b1f87fc2";
            var isEqualStatus = Core.Enums.StatusMessage.queued.ToString();

            TwilioClient.Init(ACCOUNT_S_ID, AUTH_TOKEN);

            var messageObject = await MessageResource.CreateAsync( 
                from: new PhoneNumber("whatsapp:+14155238886"),
                body: "Имя: " + message.Name + "\n" +
                "Моб.телефон: " + message.Number + "\n" +
                "Интересует: " + message.Product + "\n" +
                "Комментарий: " + message.Comment,
                to: new PhoneNumber("whatsapp:+79856838046")
            );
            var sResult = messageObject.Status.ToString();

            if (!sResult.Equals(isEqualStatus)) {
                throw new ArgumentException();
            }

            return messageObject.Status;            
        }
    }
}
