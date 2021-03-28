using System.Net;
using DM.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace DocumentManagerAPI.Controllers
{
	public class BaseController : Controller
	{
		private readonly IOptionsSnapshot<DocumentUploadConfig> _documentUploadConfig;

		public BaseController(IOptionsSnapshot<DocumentUploadConfig> documentUploadConfig)
		{
			_documentUploadConfig = documentUploadConfig;
		}
		public IActionResult HandleProcessingStatus(DocumentProcessingStatusEnum processingStatusCode) 
		{
			switch (processingStatusCode)
			{
				case DocumentProcessingStatusEnum.InavlidFileFormat:
					return StatusCode((int)HttpStatusCode.UnsupportedMediaType, $"Acceptable formats are {string.Join(",", _documentUploadConfig?.Value?.AllowedFileTypes)}");
				case DocumentProcessingStatusEnum.MaxSizeReached:
					return StatusCode((int)HttpStatusCode.UnsupportedMediaType, $"Max file limit of {_documentUploadConfig?.Value?.MaxFileSize} reached");
				case DocumentProcessingStatusEnum.UnknownFileType:
					return StatusCode((int)HttpStatusCode.UnsupportedMediaType);
				default:
					return StatusCode(500);
			}
		}
	}
}
