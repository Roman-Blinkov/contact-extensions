using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using Windows.ApplicationModel.Email;

namespace Plugin.Contacts.Extensions
{
    internal class EmailService : IEmailService
    {
        public bool CanSend => true;

        public void Send(string toAddress, string subject, string message)
        {
            Task.Run(() => this.SendAsync(toAddress, subject, message))
                .Wait();
        }

        private async Task SendAsync(string toAddress, string subject, string message)
        {
            if (toAddress.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (message.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            var emailMessage = new EmailMessage()
            {
                Subject = subject,
                Body = message
            };

            emailMessage.To.Add(new EmailRecipient(toAddress));

            //await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
    }
}