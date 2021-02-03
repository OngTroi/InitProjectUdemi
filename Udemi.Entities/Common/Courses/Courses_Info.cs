using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.Entities.Common.Courses
{
    public class Courses_Info
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string DescriptionShort { get; set; }
		public string DescriptionLong { get; set; }
		public string Thumbnail { get; set; }
		public double Price { get; set; }
		public double Sale { get; set; }
		public double ReviewPoint { get; set; }
		public int Reviews { get; set; }
		public int Participants { get; set; }
		public string Outline { get; set; }
		public int Teacher { get; set; }
		public int CategoryId { get; set; }
		public int SubjectTotal { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime UpdatedDate { get; set; }
		public int IsDeleted { get; set; }
		public int IsCompleted { get; set; }
    }
}
