namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IMailRepository
    {
        void SendMail(string subject, string body, List<string> recipientMail, string path);
        void SendMail(string subject, string body, List<string> recipientMail);
    }
}
