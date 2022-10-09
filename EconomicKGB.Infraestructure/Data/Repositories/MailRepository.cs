using SmartSolution.Domain.Interfaces.Repository;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public class MailRepository : MasterMailServer, IMailRepository
    {
        public MailRepository()
        {
            senderMail = "iqprojectsolutions@gmail.com";
            password = "jcxqjnqoybjgrqyy";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            InitializeComponnent();
        }
    }
}