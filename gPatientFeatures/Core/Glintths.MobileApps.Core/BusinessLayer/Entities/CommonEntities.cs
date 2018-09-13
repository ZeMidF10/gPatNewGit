using System.Runtime.Serialization;

namespace Glintths.MobileApps.Core.BusinessLayer.Entities
{
	[DataContract]
	public class COEntityStatus
	{
		[DataMember]
		public Visibility Visibility { get; set; }

		[DataMember]
		public EntityStatus EntityState { get; set; }

		[DataMember]
		public Operation PerformedOperation { get; set; }
	}

	[DataContract]
	public class RelationshipEntityStatus
	{
		[DataMember]
		public Visibility Visibility { get; set; }

		[DataMember]
		public EntityStatus EntityState { get; set; }

		[DataMember]
		public Operation PerformedOperation { get; set; }
	}

	[DataContract]
	public class LocalEntityStatus
	{
		[DataMember]
		public EntityStatus EntityState { get; set; }

		[DataMember]
		public Operation PerformedOperation { get; set; }
	}

	[DataContract]
	public enum EntityStatus
	{
		[EnumMemberAttribute]
		Active,

		[EnumMemberAttribute]
		Inactive
	}

	[DataContract]
	public enum Visibility
	{
		[EnumMemberAttribute]
		Visible,

		[EnumMemberAttribute]
		Invisible
	}

	[DataContract]
	public enum Operation
	{
		[EnumMemberAttribute]
		None,

		[EnumMemberAttribute]
		Inserted,

		[EnumMemberAttribute]
		Deleted,

		[EnumMemberAttribute]
		Updated
	}
}