using EdjCase.ICP.Candid.Mapping;

namespace Candid.WorldHub.Models
{
	public class DeleteField
	{
		[CandidName("fieldName")]
		public string FieldName { get; set; }

		public DeleteField(string fieldName)
		{
			this.FieldName = fieldName;
		}

		public DeleteField()
		{
		}
	}
}