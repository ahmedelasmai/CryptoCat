using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using System.Collections.Generic;
using Candid.IcrcLedger.Models;
using BlockIndex = EdjCase.ICP.Candid.Models.UnboundedUInt;
using Block = Candid.IcrcLedger.Models.Value;
using QueryBlockArchiveFn = EdjCase.ICP.Candid.Models.Values.CandidFunc;

namespace Candid.IcrcLedger.Models
{
	public class GetBlocksResponse
	{
		[CandidName("first_index")]
		public BlockIndex FirstIndex { get; set; }

		[CandidName("chain_length")]
		public ulong ChainLength { get; set; }

		[CandidName("certificate")]
		public OptionalValue<List<byte>> Certificate { get; set; }

		[CandidName("blocks")]
		public GetBlocksResponse.BlocksInfo Blocks { get; set; }

		[CandidName("archived_blocks")]
		public GetBlocksResponse.ArchivedBlocksInfo ArchivedBlocks { get; set; }

		public GetBlocksResponse(BlockIndex firstIndex, ulong chainLength, OptionalValue<List<byte>> certificate, GetBlocksResponse.BlocksInfo blocks, GetBlocksResponse.ArchivedBlocksInfo archivedBlocks)
		{
			this.FirstIndex = firstIndex;
			this.ChainLength = chainLength;
			this.Certificate = certificate;
			this.Blocks = blocks;
			this.ArchivedBlocks = archivedBlocks;
		}

		public GetBlocksResponse()
		{
		}

		public class BlocksInfo : List<Block>
		{
			public BlocksInfo()
			{
			}
		}

		public class ArchivedBlocksInfo : List<GetBlocksResponse.ArchivedBlocksInfo.ArchivedBlocksInfoElement>
		{
			public ArchivedBlocksInfo()
			{
			}

			public class ArchivedBlocksInfoElement
			{
				[CandidName("start")]
				public BlockIndex Start { get; set; }

				[CandidName("length")]
				public UnboundedUInt Length { get; set; }

				[CandidName("callback")]
				public QueryBlockArchiveFn Callback { get; set; }

				public ArchivedBlocksInfoElement(BlockIndex start, UnboundedUInt length, QueryBlockArchiveFn callback)
				{
					this.Start = start;
					this.Length = length;
					this.Callback = callback;
				}

				public ArchivedBlocksInfoElement()
				{
				}
			}
		}
	}
}