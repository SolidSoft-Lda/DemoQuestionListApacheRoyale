using System.Text;
using System.Net;
using System.Net.Mail;

namespace DemoListQuestions.Helpers;

public class EMailSender
{
    private string server;
    private string username;
    private string password;
    private string from;

    public EMailSender(string server, string username, string password, string from)
    {
        this.server = server;
        this.username = username;
        this.password = password;
        this.from = from;
    }

	public bool Send(string to, string subject, string body)
	{
        try
        {
            SmtpClient smtpClient = new SmtpClient(server);

            //set authentication
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(username, password);

            //add from, to mail message
            MailMessage message = new MailMessage(new MailAddress(from), new MailAddress(to));

            //set subject and encoding
            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;

            //set body message and encoding
            message.Body = body;
            message.BodyEncoding = Encoding.UTF8;

            smtpClient.Send(message);
        }
        catch
        {
            //a possible improvement would be log the exception for analysis
            return false;
        }
        return true;
    }
}