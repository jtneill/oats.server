using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace oats.server.Models
{
	public class Deal
	{
		public int Id { get; set; }
		public List<Person> People { get; set; }
		public List<DealTask> DealTasks { get; set; }
	}

}