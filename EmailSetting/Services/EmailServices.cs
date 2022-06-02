﻿using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace EmailSetting.Services
{
	public class EmailServices
	{
		public async Task SendEmailAsync(string email,string subject,string message)
		{
			var emailMessage = new MimeMessage();

			emailMessage.From.Add(new MailboxAddress("Admin", "akmal199601@mail.ru"));
			emailMessage.To.Add(new MailboxAddress("",email));
			emailMessage.Subject = subject;
			emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = message
			};
			using var client = new SmtpClient();
			await client.ConnectAsync("smtp.yandex.ru", 25, false);
			await client.AuthenticateAsync("akmal199601@mail.ru", "password");
			await client.SendAsync(emailMessage);

			await client.DisconnectAsync(true);
		}
	}
}
