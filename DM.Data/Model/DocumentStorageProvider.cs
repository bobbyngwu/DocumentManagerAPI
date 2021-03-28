using System;

namespace DM.Data.Model
{
	public class DocumentStorageProvider : ModelIdentity
	{
		public string Name { get; set; }
		public bool IsActive { get; set; }
	}
}
