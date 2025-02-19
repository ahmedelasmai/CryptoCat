using EdjCase.ICP.Candid.Mapping;
using Candid.IcrcLedger.Models;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using Timestamp = System.UInt64;

namespace Candid.IcrcLedger.Models
{
	public class Mint
	{
		[CandidName("to")]
		public Account To { get; set; }

		[CandidName("memo")]
		public OptionalValue<List<byte>> Memo { get; set; }

		[CandidName("created_at_time")]
		public Mint.CreatedAtTimeInfo CreatedAtTime { get; set; }

		[CandidName("amount")]
		public UnboundedUInt Amount { get; set; }

		public Mint(Account to, OptionalValue<List<byte>> memo, Mint.CreatedAtTimeInfo createdAtTime, UnboundedUInt amount)
		{
			this.To = to;
			this.Memo = memo;
			this.CreatedAtTime = createdAtTime;
			this.Amount = amount;
		}

		public Mint()
		{
		}

		public class CreatedAtTimeInfo : OptionalValue<Timestamp>
		{
			public CreatedAtTimeInfo()
			{
			}

			public CreatedAtTimeInfo(Timestamp value) : base(value)
			{
			}
		}
	}
}