using System.ComponentModel.DataAnnotations;

namespace AssignmentApp.Models
{
	public class StudentEntity
	{
		public int Id { get; set; }

		[Required]
		public string? Name { get; set; }

		[Required]
		[Range(0, 100)]
		public int Age { get; set; }
		[Required]
		public String? Majo { get; set; }
	}
}
