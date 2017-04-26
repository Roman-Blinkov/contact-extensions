using Android.App;
using Android.Content;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Android;

namespace Plugin.Contacts.Extensions
{
    internal class EmailService : IEmailService
    {
        public bool CanSend => true;

        public void Send(string toAddress, string subject, string message)
        {
            if (toAddress.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (subject.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (message.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            var emailIntent = new Intent(Intent.ActionSend);

            emailIntent.PutExtra(Intent.ExtraEmail, new string[] { toAddress });
            emailIntent.PutExtra(Intent.ExtraSubject, subject);
            emailIntent.PutExtra(Intent.ExtraText, message);

            emailIntent.SetType("message/rfc822");

            emailIntent.StartActivity();
        }
    }
}