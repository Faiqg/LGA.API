using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGA.API.Model
{
	public class State : IBaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StateId { get; set; }
		[DisplayName("State name")]
		public string StateName { get; set; }
		public decimal Median { get; set; }
	}
}
