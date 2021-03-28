using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Data.DTO
{
	public class DocumentUploadConfig
	{
		/// <summary>
		/// max file size in bytes
		/// </summary>
		public int MaxFileSize { get; set; }
		/// <summary>
		/// comma delimited file types without the dot
		/// </summary>
		public string AllowedFileTypes { get; set; }
	}
}
