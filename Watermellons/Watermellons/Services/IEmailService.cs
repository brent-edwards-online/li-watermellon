using System.Threading.Tasks;


namespace Watermellons.Services
{
    public interface IEmailService
    {
        bool EmailMessage(string toAddress, string subject, string message);
    }
} 
