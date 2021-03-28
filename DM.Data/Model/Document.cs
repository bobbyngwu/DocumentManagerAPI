using System;

namespace DM.Data.Model
{
	public class Document : ModelIdentity
	{
		public string Name { get; set; }
		public string Extension { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDateTime { get; set; }
		public int Order { get; set; }
		public DateTime LastModified { get; set; }
		public int SizeBytes { get; set; }
		public DocumentType DocumentType { get; set; }
		public int DocumentTypeId { get; set; }
		public Publisher CreatedBy { get; set; }
		public int CreatedById { get; set; }
		public DocumentLocation Location { get; set; }
		public int DocumnetLocationId { get; set; }

	}
}
