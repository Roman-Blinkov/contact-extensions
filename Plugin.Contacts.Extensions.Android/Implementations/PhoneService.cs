using Android.Content;
using Android.Net;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using Plugin.Contacts.Extensions.Android;

namespace Plugin.Contacts.Extensions
{
    internal class PhoneService : IPhoneService
    {
        public bool CanPhone => true;

        public void Phone(string number, string name)
        {
            if (number.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            if (name.IsBadFormat())
            {
                throw new System.FormatException("Incorrect argument: toNumber !");
            }

            var phoneUri = Uri.Parse("tel:" + number);
            var phoneIntent = new Intent(Intent.ActionDial, phoneUri);

            phoneIntent.StartActivity();
        }
    }
}