using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid.Models;
using ActionId = System.String;

namespace Candid.World.Models
{
	public class ActionState
	{
		[CandidName("actionCount")]
		public UnboundedUInt ActionCount { get; set; }

		[CandidName("actionId")]
		public string ActionId { get; set; }

		[CandidName("intervalStartTs")]
		public UnboundedUInt IntervalStartTs { get; set; }

		public ActionState(UnboundedUInt actionCount, string actionId, UnboundedUInt intervalStartTs)
		{
			this.ActionCount = actionCount;
			this.ActionId = actionId;
			this.IntervalStartTs = intervalStartTs;
		}

		public ActionState()
		{
		}
	}
}