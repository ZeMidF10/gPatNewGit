using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.MobileApps.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Glintths.MobileApps.Core.ServiceAccessLayer
{
	public static class ServiceReturnHandling
	{
		public const string TimeoutMessageKey = "TIMEOUT_MESSAGE";
		public const string NoInternetMessageKey = "NOINTERNET_MESSAGE";
		public const string InvalidTimezoneMessageKey = "TIMEZONE_MESSAGE";

		public const string GenericMessageKey = "GENERIC ERROR_MESSAGE";
		public const string UnauthorizeMessageKey = "UNAUTHORIZE_MESSAGE";
		public const string SuccessMessageKey = "SUCCESS_MESSAGE";

		public static string GetErrorMessage(Exception exc, Dictionary<string, string> uiMessages)
		{
			//FaultException //Exception //WebException
			string key = GenericMessageKey;
			string defaultMessage = AppResources.UnexpetedError;

            if (exc is TimeoutException)
			{
				key = TimeoutMessageKey;
				defaultMessage = AppResources.ServiceUnavailable;
            }
			else if (exc is InvalidTimeZoneException)
			{
				key = InvalidTimezoneMessageKey;
				defaultMessage = AppResources.NotSupportedTimeZone;
            }
			else if (exc is UnauthorizedAccessException)
			{
				key = UnauthorizeMessageKey;
				defaultMessage = AppResources.NotPermissions;
            }
			else if (exc is WebException)
			{
				key = NoInternetMessageKey;
				defaultMessage = AppResources.ValidateInternet;
            }

			return uiMessages.Keys.Contains(key) ? uiMessages[key] : defaultMessage;
		}

		public static ServiceReturn<T> HandleException<T>(Exception exc, Dictionary<string, string> uiMessages)
		{
			ServiceReturn<T> ret = new ServiceReturn<T>()
			{
				CallException = exc,
				ErrorCode = "0x0020",
				Success = false,
				ErrorMessage = exc.Message,
				UIMessage = GetErrorMessage(exc, uiMessages)
			};

			if (Reporter.IsInitialized) Reporter.Instance().Report(exc, uiMessages, 1);

			return ret;
		}

		public static string GetSuccessMessage(Dictionary<string, string> uiMessages)
		{
			//FaultException //Exception
			string key = SuccessMessageKey;
			string defaultMessage = AppResources.Success;

            return uiMessages.Keys.Contains(key) ? uiMessages[key] : defaultMessage;
		}

		public static ServiceReturn<T> BuildSuccessCallReturn<T>(T objectReturn, Dictionary<string, string> uiMessages)
		{
			ServiceReturn<T> ret = new ServiceReturn<T>()
			{
				CallException = null,
				ErrorCode = "0x0000",
				Success = true,
				ErrorMessage = String.Empty,
				UIMessage = GetSuccessMessage(uiMessages),
				Result = objectReturn
			};

			return ret;
		}
	}
}