using EdjCase.ICP.Candid.Mapping;
using System.Collections.Generic;

namespace Candid.IcrcLedger.Models
{
	public class HttpResponse
	{
		[CandidName("body")]
		public List<byte> Body { get; set; }

		[CandidName("headers")]
		public Dictionary<string, string> Headers { get; set; }

		[CandidName("status_code")]
		public ushort StatusCode { get; set; }

		public HttpResponse(List<byte> body, Dictionary<string, string> headers, ushort statusCode)
		{
			this.Body = body;
			this.Headers = headers;
			this.StatusCode = statusCode;
		}

		public HttpResponse()
		{
		}
	}
}