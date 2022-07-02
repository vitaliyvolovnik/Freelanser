using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Freelanser
{
    //public class SendGridEmailSender:IEmailSender
    //{
    //    private IConfiguration _config;

    //    public SendGridEmailSender(IConfiguration configure)
    //    {
    //        this._config=configure;
    //    }

    //    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        var apiKey = _config["SendGridApiKey"];
    //        var client = new SendGridClient(apiKey);
    //        var message = new SendGridMessage()
    //        {
    //            From = new EmailAddress("Volo_fy25@student.itstep.org", "Vitaliy"),
    //            Subject = subject,
    //            PlainTextContent = htmlMessage,
    //            HtmlContent = htmlMessage
    //        };
    //        message.AddTo(new EmailAddress(email));
    //        var responce = await client.SendEmailAsync(message);
    //    }
    //}
}
