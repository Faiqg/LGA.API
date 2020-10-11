using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGA.API.Model
{
	public class Score : IBaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ScoreId { get; set; }
		public int? DisadvantageScore { get; set; }
		public int? AdvantageDisadvantageScore { get; set; }
		public int Year { get; set; }
		public Location Location { get; set; }
	}
}
