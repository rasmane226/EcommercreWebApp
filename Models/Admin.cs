using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
	public class Admin
	{
		[Key]
        public int AdminID { get; set; }
        [StringLength(20)]
        public String? UserName { get; set; }
		[StringLength(20)]
		public String? Password { get; set; }
		[StringLength(1)]
		public String? AdminRole { get; set; }
    }
}
