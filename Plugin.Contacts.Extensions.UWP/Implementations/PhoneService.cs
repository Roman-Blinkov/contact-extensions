using Plugin.Contacts.Extensions.Abstractions.Interfaces;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;

namespace Plugin.Contacts.Extensions
{
    internal class PhoneService : IPhoneService
    {
        public bool CanPhone
        {
            get
            {
                return ApiInformation
                    .IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager");
            }
        }

        public void Phone(string number, string name)
        {
            //if(!CanPhone)
            //{
            //    throw new System.Exception("Sarac");
            //}

            PhoneCallManager.ShowPhoneCallUI(number, name);
        }
    }
}