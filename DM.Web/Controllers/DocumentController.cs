using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DM.Data.DTO;
using DM.Services.Implementation;
using DM.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DocumentManagerAPI.Controllers
{
	//[Authorize]
	[Produces("application/json")]
	[Route("api/document")]
	public class DocumentController : BaseController
	{
		private readonly IDocumentService _documentService;
		ILogger<DocumentController> _logger;
		private readonly IFileStorageService _fileStorageService;

		public DocumentController(IDocumentService documentService, ILogger<DocumentController> logger, 
			IOptionsSnapshot<DocumentUploadConfig> documentUploadConfig, 
			IFileStorageService fileStorageService) :base(documentUploadConfig)
		{
			_documentService = documentService;
			_logger = logger;
			_fileStorageService = fileStorageService;
		}


		//ToDo: Add Pagination with Filter DTO
		[HttpGet]
		[Route("documents")]
		public async Task<IActionResult> GetDocuments(CancellationToken cancellatioToken)
		{
			var documents = await _documentService.GetDocuments(cancellatioToken);
			if(documents != null)
			{
				_logger.LogError($"Documents not found");
				return NotFound();
			}
			return Ok(documents);
		}

		[HttpGet]
		[Route("document/{id}")]
		public async Task<IActionResult> GetDocument(int id, CancellationToken cancellatioToken)
		{
			var document = await _documentService.GetDocument(id, cancellatioToken);
			if (document != null)
			{
				_logger.LogError($"Document not found for id  {id}");
				return NotFound();
			}
			return Ok(document);
		}


		[HttpGet]
		[Route("download/{fileName}")]
		[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 10000000)]
		public async Task<FileContentResult> DownloadDocument(string fileName, CancellationToken cancellatioToken)
		{
			var documentUrl = await _fileStorageService.GetFilePath(fileName, cancellatioToken);
			if (!string.IsNullOrEmpty(documentUrl))
			{
				WebClient client = new WebClient();
				return new FileContentResult(client.DownloadData(documentUrl), await _fileStorageService.GetMimeType(fileName))
				{
					FileDownloadName = fileName
				};
			}
			return null;
		}

		[HttpPost]
		[Route("upload")]
		public async Task<IActionResult> UploadDocument([FromForm] IFormFile file, CancellationToken cancellationToken)
		{
			if (file == null)
				return StatusCode((int) HttpStatusCode.BadRequest, "File Value cannot be null");
			var documentResult = await _documentService.CreateDocument(file, cancellationToken);
			if (documentResult?.ProcessingStatus == DocumentProcessingStatusEnum.FileUploaded)
			{
				return StatusCode((int)HttpStatusCode.Created, documentResult.FileName);
			}
			return HandleProcessingStatus(documentResult.ProcessingStatus);

		}

		[HttpPut]
		[Route("reorder")]
		public async Task<IActionResult> ReorderDocuments([FromBody] IList<DocumentDTO> documents, CancellationToken cancellationToken)
		{
			if (documents == null)
			{
				return BadRequest("Request not in the right format, no document information provided");
			}
			try
			{
				await _documentService.ReorderDocuments(documents, cancellationToken);
				return StatusCode((int) HttpStatusCode.NoContent);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error occurred  reordering documents", ex);
				return StatusCode((int)HttpStatusCode.NotModified, "Unable to complete request");
			}
		}

		[HttpDelete]
		[Route("document/{id}")]
		public async Task<IActionResult> DeleteDocument(int id, CancellationToken cancellationToken)
		{
			var deleteDocumentResult = await _documentService.DeleteDocument(id, cancellationToken);
			if (deleteDocumentResult == DocumentProcessingStatusEnum.OperationCompleted)
			{
				return Ok(); // subject to Business rule consider, 202 if we will not delete the resource but mark it for deletion
			}
			return HandleProcessingStatus(deleteDocumentResult);
		}
	}
}
