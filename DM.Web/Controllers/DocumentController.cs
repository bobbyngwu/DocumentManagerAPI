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

		public DocumentController(IDocumentService documentService, ILogger<DocumentController> logger, IOptionsSnapshot<DocumentUploadConfig> documentUploadConfig) :base(documentUploadConfig)
		{
			_documentService = documentService;
			_logger = logger;
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

		[HttpPost]
		[Route("document")]
		public async Task<IActionResult> CreateDocument([FromBody] List<IFormFile> files, CancellationToken cancellationToken)
		{
			var documentResult = await _documentService.CreateDocument(files, cancellationToken);
			if (documentResult.Item2 == DocumentProcessingStatusEnum.FileUploaded)
			{
				return StatusCode((int)HttpStatusCode.Created, documentResult.Item1);
			}
			return HandleProcessingStatus(documentResult.Item2);

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
