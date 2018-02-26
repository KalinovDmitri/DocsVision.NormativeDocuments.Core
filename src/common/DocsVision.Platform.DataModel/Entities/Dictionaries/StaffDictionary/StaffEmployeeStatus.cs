using System;

namespace DocsVision.Platform.DataModel.Entities
{
	public enum StaffEmployeeStatus : int
	{
		Active,
		Sick,
		Vacation,
		BusinessTrip,
		Absent,
		Discharged,
		Transfered,
		DischargedNoRestoration
	}
}