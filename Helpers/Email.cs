using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCamp.Adm.Helpers
{
    /// <summary>
    /// Email
    /// </summary>
    public class Email
	{
        public static string GenericEmail = "contacto@grupoinderoforte.com";
        public static string SendGridKey = "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";

		/// <summary>
		/// Sends the mail.
		/// </summary>
		/// <param name="to">To.</param>
		/// <param name="subject">The subject.</param>
		/// <param name="body">The body.</param>
		public static void SendMail(string to, string subject, string body)
        {
                var client = new SendGridClient(SendGridKey);
                var message = new SendGridMessage();
                message.From = new EmailAddress(GenericEmail, "Grupo Inderoforte");
                message.AddTo(new EmailAddress(to, to));
                message.Subject = subject;
                message.HtmlContent = body;

                client.SendEmailAsync(message);
        }
    }
}
