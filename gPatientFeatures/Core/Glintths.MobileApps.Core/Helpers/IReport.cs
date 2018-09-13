using System;
using System.Collections;
using System.Collections.Generic;

namespace Glintths.MobileApps.Core.Helpers.Reporting
{
	public interface IReport
	{
		bool DisableDataTransmission { get; set; }

		bool DisableExceptionCatching { get; set; }

		bool ForceDataTransmission { get; set; }

		bool IsInitialized { get; }

		void Identify(string uid, IDictionary<string, string> table);

		void Identify(string uid, string key, string value);

		void Report(Exception exception = null, int warningLevel = 0);

		void Report(Exception exception, IDictionary extraData, int warningLevel = 0);

		void Report(Exception exception, string key, string value, int warningLevel = 0);

		void Track(string trackIdentifier, IDictionary<string, string> table = null);
	}

	public static class Traits
	{
		public const string Address = "Address";
		public const string Age = "Age";
		public const string Avatar = "Avatar";
		public const string CreatedAt = "Created at";
		public const string DateOfBirth = "Birthdate";
		public const string Description = "Description";
		public const string Email = "Email";
		public const string FirstName = "First name";
		public const string Gender = "Gender";
		public const string LastName = "Last name";
		public const string Name = "Name";
		public const string Phone = "Phone";
		public const string Website = "Website";
		public const string UserType = "user type";
		public const string ID = "Id";
	}
}