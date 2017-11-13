using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public class StaffEmployee : BaseCardSectionRow
	{
		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public Guid? Position { get; set; }

		public string AccountName { get; set; }

		public Guid? Manager { get; set; }

		public string RoomNumber { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string Email { get; set; }

		public DateTime? BirthDate { get; set; }

		public string Comments { get; set; }

		public StaffEmployeeStatus Status { get; set; }

		public StaffEmployeeGender Gender { get; set; }

		public string AccountSID { get; set; }

		public virtual StaffPosition EmployeePosition { get; set; }

		public virtual StaffEmployee EmployeeManager { get; set; }
	}
}