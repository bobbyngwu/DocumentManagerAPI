using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DM.Data.DTO;
using DM.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DM.Services.Implementation
{
    public class DocumentReadService : IDocumentReadService
	{
		public async Task<IList<DocumentDTO>> GetDocuments(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public async Task<DocumentDTO> GetDocument(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
    public class DocumentEditService : IDocumentEditService
	{
		private readonly IFileStorageService _fileStorageService;
		private readonly ILogger<DocumentEditService> _logger;
		public DocumentEditService(IFileStorageService fileStorageService, ILogger<DocumentEditService> logger)
		{
			_fileStorageService = fileStorageService;
			_logger = logger;
		}
		public async Task<FileUploadResultDTO> CreateDocument(IFormFile file, CancellationToken cancellationToken)
		{
			FileUploadResultDTO result = new FileUploadResultDTO();
			// attempt to save this
			if (file != null && file.Length > 0)
			{
				try
				{
					var fileName = await _fileStorageService.Save(file, cancellationToken);
					result.FileName = fileName;
					// append to DocumentDBContext
					// context.saveChanges
					result.ProcessingStatus = DocumentProcessingStatusEnum.FileUploaded;
				}
				catch (Exception ex)
				{
					_logger.LogError("Error Saving file", ex);
					result.ProcessingStatus = DocumentProcessingStatusEnum.OperationFailed;
				}
			}
			return result;
		}
		public async Task ReorderDocuments(IList<DocumentDTO> documents, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public async Task<DocumentProcessingStatusEnum> DeleteDocument(int id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
    public class DocumentService : IDocumentService
    {
		private readonly IDocumentReadService _readService;
		private readonly IDocumentEditService _editService;
		public DocumentService(IDocumentReadService readService, IDocumentEditService editService)
		{
			_editService = editService;
			_readService = readService;
		}
		public Task<FileUploadResultDTO> CreateDocument(IFormFile file, CancellationToken cancellationToken) => _editService.CreateDocument(file, cancellationToken);
		public Task ReorderDocuments(IList<DocumentDTO> documents, CancellationToken cancellationToken) => _editService.ReorderDocuments(documents, cancellationToken);
		public Task<DocumentProcessingStatusEnum> DeleteDocument(int id, CancellationToken cancellationToken) => _editService.DeleteDocument(id, cancellationToken);
		public Task<IList<DocumentDTO>> GetDocuments(CancellationToken cancellationToken) => _readService.GetDocuments(cancellationToken);
		public Task<DocumentDTO> GetDocument(int id, CancellationToken cancellationToken) => _readService.GetDocument(id, cancellationToken);
	}
}
