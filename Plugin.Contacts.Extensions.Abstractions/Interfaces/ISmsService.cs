namespace Plugin.Contacts.Extensions.Abstractions.Interfaces
{
    public interface ISmsService
    {
        bool CanSend { get; }

        void Send(string toNumber, string message);
    }
}
