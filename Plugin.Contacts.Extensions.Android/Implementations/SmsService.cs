using Android.Content;
using Android.Net;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using Plugin.Contacts.Extensions.Android;

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

            var smsUri = Uri.Parse("smsto:" + toNumber);
            var smsIntent = new Intent(Intent.ActionSendto, smsUri);

            smsIntent.PutExtra("sms_body", message);

            smsIntent.StartActivity();
        }
    }
}