using System;
using System.ComponentModel.DataAnnotations;

namespace DocsVision.NormativeDocuments.Models
{
	public class LoginViewModel
	{
		[Required]
		public string AccountName { get; set; }

		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }
	}
}