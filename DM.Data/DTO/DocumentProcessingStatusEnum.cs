using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Data.DTO
{
	public enum DocumentProcessingStatusEnum
	{
		InavlidFileFormat = 1,
		MaxSizeReached = 2,
		UnknownFileType = 3,
		FileUploaded = 4,
		DocumentNotFound = 5,
		OperationCompleted = 6,
		OperationFailed = 7

	}
}
