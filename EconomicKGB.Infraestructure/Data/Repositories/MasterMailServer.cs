using System.Net.Mail;
using System.Net;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public abstract class MasterMailServer
    {
        //Atributos
        private SmtpClient smtpClient = null!;
        protected string senderMail { get; set; } = String.Empty;
        protected string password { get; set; } = String.Empty;
        protected string host { get; set; } = String.Empty;
        protected int port { get; set; }
        protected bool ssl { get; set; }

        //Inicializar propiedades del cliente SMTP
        protected void InitializeComponnent()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        public async void SendMail(string subject, string body, List<string> recipientMail, string path)
        {
            var mailMessage = new MailMessage();
            try
            {

                mailMessage.From = new MailAddress(senderMail);
                foreach (string mail in recipientMail)
                {
                    mailMessage.To.Add(mail);

                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.Attachments.Add(new Attachment(path));//obtiene la ruta del archivo a enviar
                await (smtpClient.SendMailAsync(mailMessage));//Enviar mensaje
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

        public async void SendMail(string subject, string body, List<string> recipientMail)
        {
            var mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(senderMail);
                foreach (string mail in recipientMail)
                {
                    mailMessage.To.Add(mail);

                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                await smtpClient.SendMailAsync(mailMessage);//Enviar mensaje
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
