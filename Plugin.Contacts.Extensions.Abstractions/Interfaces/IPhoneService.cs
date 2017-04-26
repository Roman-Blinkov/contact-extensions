namespace Plugin.Contacts.Extensions.Abstractions.Interfaces
{
    public interface IPhoneService
    {
        bool CanPhone { get; }

        void Phone(string number, string name);
    }
}
