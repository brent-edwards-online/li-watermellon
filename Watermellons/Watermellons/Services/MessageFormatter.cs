using System.Text;
using Watermellons.EntityFramework;

namespace Watermellons.Services
{
    public class MessageFormatter : IMessageFormatter
    {
        public string FormatMessage(CompetitionEntry entry)
        {
            StringBuilder messageBody = new StringBuilder();
            messageBody.Append("Name: ");
            messageBody.Append(entry.FullName);
            messageBody.Append("\n");
            messageBody.Append("Email: ");
            messageBody.Append(entry.Email);
            messageBody.Append("\n");
            messageBody.Append("Gender: ");
            if (entry.Gender == false)
                messageBody.Append("Male");
            else
                messageBody.Append("Female");
            messageBody.Append("\n");
            messageBody.Append("Favourite Place To Eat Watermellon: ");
            messageBody.Append(entry.FavouriteWatermellonPlace);
            messageBody.Append("\n");
            messageBody.Append("Terms and conditions: ");
            if(entry.TermsAndConditionsAccepted == true)
                messageBody.Append("Accepted");
            else
                messageBody.Append("Not Accepted");
            messageBody.Append("\n");

            return messageBody.ToString();
        }
    }
}