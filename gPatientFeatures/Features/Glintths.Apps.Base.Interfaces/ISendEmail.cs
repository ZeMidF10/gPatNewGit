using System;

namespace Glintths.Apps.Base.Interfaces
{
	public interface ISendEmail
	{
	
		void MailTo (string subject, string to, string body);
	}
}

