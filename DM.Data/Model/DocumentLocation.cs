using System;

namespace DM.Data.Model
{
	public class DocumentLocation
	{
		public DocumentStorageProvider StorageProvider { get; set; }
		public int StorageProviderId { get; set; }
		public string FilePath { get; set; }
	}
}
