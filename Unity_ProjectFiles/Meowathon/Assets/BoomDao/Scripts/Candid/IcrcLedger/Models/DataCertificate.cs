using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;

namespace Candid.IcrcLedger.Models
{
	public class DataCertificate
	{
		[CandidName("certificate")]
		public OptionalValue<List<byte>> Certificate { get; set; }

		[CandidName("hash_tree")]
		public List<byte> HashTree { get; set; }

		public DataCertificate(OptionalValue<List<byte>> certificate, List<byte> hashTree)
		{
			this.Certificate = certificate;
			this.HashTree = hashTree;
		}

		public DataCertificate()
		{
		}
	}
}