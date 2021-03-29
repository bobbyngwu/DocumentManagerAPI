using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DM.Specs.Services.Implementation
{
	public class HttpResponseObject
	{
		public string Content { get; set; }
		public HttpStatusCode StatusCode { get; set; }
	}
}
