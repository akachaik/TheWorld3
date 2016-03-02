using System;

namespace TheWorld3.Services
{
    public interface IMailService
    {
        bool SendMail(string from, string to, string body);
    }


    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string body)
        {
            Console.WriteLine($"Sending to {to} from {from} with body {body}");
            return true;
        }
    }
}
