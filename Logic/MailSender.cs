using BMSDesk_CLI_API.Web.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BMSDesk_CLI_API.Logic
{
	public class MailSender
	{
		private static IConfiguration _config;
		public MailSender(IConfiguration config)
		{
			_config = config;
		}
		public static int SendMail(string Subject, string Body, string ToEmail, string CC = "", string BCC = "")
		{
			int res = 0;
			try
			{
				Thread thread = new Thread(delegate ()
				{
					using (MailMessage mailmsg = new MailMessage())
					{
						SMPTSetting setting = HtmlHelpers.ClaimsModelService.getSMTP();

						string fromMailAlias = setting.fromEmailAlias;
						string fromMail = setting.fromEmail;

						mailmsg.To.Add(ToEmail);
						mailmsg.Subject = Subject;
						mailmsg.Body = Body;
						mailmsg.IsBodyHtml = true;
						if (!string.IsNullOrEmpty(fromMailAlias) && !string.IsNullOrEmpty(fromMail)) { mailmsg.From = new MailAddress("\"" + fromMailAlias + "\"" + " " + fromMail); }
						else if (!string.IsNullOrEmpty(fromMail)) { mailmsg.From = new MailAddress(fromMail); }

						SendSMTP(mailmsg, setting);
					}
				});
				thread.IsBackground = true;
				thread.Start();
				res = 1;
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}
			return res;
		}


		public static void SendSMTP(MailMessage mailmsg, SMPTSetting setting)
		{
			try
			{
				using (SmtpClient smtp = new SmtpClient(setting.SmtpServer, setting.SmtpPort))
				{
					smtp.UseDefaultCredentials = false;
					smtp.Credentials = new System.Net.NetworkCredential(setting.Username, setting.Password);
					smtp.EnableSsl = setting.EnableSsl;
					smtp.Timeout = 1500000;
					smtp.Send(mailmsg);
				}
			}
			catch (Exception ex)
			{
				mailmsg.Dispose();
				Logger.Log(ex);
			}
		}

	}
}
