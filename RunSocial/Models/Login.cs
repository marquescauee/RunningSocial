using System.ComponentModel.DataAnnotations;

namespace RunSocial.Models
{
	public class Login
	{
		[Display(Name ="Email Address")]
		[Required(ErrorMessage ="Email is required")]
		public string EmailAddress { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
