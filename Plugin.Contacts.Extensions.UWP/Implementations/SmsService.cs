using System;
using System.Threading.Tasks;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using Windows.ApplicationModel.Chat;

namespace Plugin.Contacts.Extensions
{
    internal class SmsService : ISmsService
    {
        public bool CanSend => true;

        public void Send(string toNumber, string message)
        {
            Task.Run(() => this.SendAsync(toNumber, message))
                .Wait();
        }

        private async Task SendAsync(string toNumber, string message)
        {
            if (toNumber.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (message.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            var smsMessage = new ChatMessage()
            {
                Body = message
            };
            smsMessage.Recipients.Add(toNumber);

            await ChatMessageManager.ShowComposeSmsMessageAsync(smsMessage);
        }
    }
}