using System.Collections.Generic;

namespace API.Helpers
{
	public class ResponseEntity
	{
		public bool error { get; set; }
		public string message { get; set; }
		public dynamic data { get; set; }
	}
}