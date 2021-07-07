using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Services
{
    public class EmailService
	{
		public static void SendEmail(string toEmailAddress, string subject, string body, string sendGridAPIKey)
		{
			Execute(toEmailAddress, subject, body, sendGridAPIKey).Wait();
		}

		static async Task Execute(string toEmailAddress, string subject, string body, string sendGridAPIKey)
		{
            var client = new SendGridClient(sendGridAPIKey);
            var from = new EmailAddress("test.logicstones@gmail.com", "Test-LS");
            var to = new EmailAddress(toEmailAddress);//, "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
	}
}