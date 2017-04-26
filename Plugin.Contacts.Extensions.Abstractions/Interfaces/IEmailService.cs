namespace Plugin.Contacts.Extensions.Abstractions.Interfaces
{
    public interface IEmailService
    {
        bool CanSend { get; }

        void Send(string toAddress, string subject, string message);
    }
}
