using Foundation;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using UIKit;

namespace Plugin.Contacts.Extensions
{
    internal class SmsService : ISmsService
    {
        public bool CanSend => true;

        public void Send(string toNumber, string message)
        {
            if (toNumber.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (message.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (!this.CanSend)
            {
                // warn the user, or hide the button...
            }

            var smsUrl = NSUrl.FromString("sms:" + toNumber);

            if (UIApplication.SharedApplication.CanOpenUrl(smsUrl))
            {
                UIApplication.SharedApplication.OpenUrl(smsUrl);
            }
            else
            {
                // warn the user, or hide the button...
            }
        }
    }
}