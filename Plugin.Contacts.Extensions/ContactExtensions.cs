using System;
using Plugin.Contacts.Extensions.Abstractions.Interfaces;

namespace Plugin.Contacts.Extensions
{
    public sealed class ContactExtensions
    {
        private static Lazy<ContactExtensions> contactExtensions
            = new Lazy<ContactExtensions>(() => new ContactExtensions(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public readonly ISmsService SmsService = null;
        public readonly IEmailService EmailService = null;
        public readonly IPhoneService PhoneService = null;

        private ContactExtensions()
        {
#if !PORTABLE
            this.SmsService = new SmsService();
            this.EmailService = new EmailService();
            this.PhoneService = new PhoneService();
#endif
        }

        public static ContactExtensions Current
        {
            get
            {
                var service = contactExtensions.Value;

                if (service == null)
                {
                    throw new NotImplementedException();
                }

                return service;
            }
        }
    }
}
