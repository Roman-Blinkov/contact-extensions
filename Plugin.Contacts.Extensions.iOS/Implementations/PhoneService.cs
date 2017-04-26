using Foundation;
using Plugin.Contacts.Extensions.Abstractions;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using UIKit;

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

            var phoneUrl = new NSUrl("tel:" + number);

            if (!UIApplication.SharedApplication.OpenUrl(phoneUrl))
            {
                var av = new UIAlertView(
                    "Not supported",
                    "Scheme 'tel:' is not supported on this device",
                    (IUIAlertViewDelegate)null,
                    "OK",
                    null);

                av.Show();
            };
        }
    }
}