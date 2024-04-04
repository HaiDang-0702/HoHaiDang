using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoHaiDang
{
	internal class Job
	{
		public string Name { get; set; }
		public int Priority { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }

		public Job(string name, int priority, string description, string status)
		{
			Name = name;
			Priority = priority;
			Description = description;
			Status = status;
		}
	}
}
