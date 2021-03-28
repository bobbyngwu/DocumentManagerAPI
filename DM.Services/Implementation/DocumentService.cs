using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DM.Data.DTO;
using DM.Services.Interface;
using Microsoft.AspNetCore.Http;

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
		public async Task<Tuple<string, DocumentProcessingStatusEnum>> CreateDocument(List<IFormFile> files, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
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
		public Task<Tuple<string, DocumentProcessingStatusEnum>> CreateDocument(List<IFormFile> files, CancellationToken cancellationToken) => _editService.CreateDocument(files, cancellationToken);
		public Task ReorderDocuments(IList<DocumentDTO> documents, CancellationToken cancellationToken) => _editService.ReorderDocuments(documents, cancellationToken);
		public Task<DocumentProcessingStatusEnum> DeleteDocument(int id, CancellationToken cancellationToken) => _editService.DeleteDocument(id, cancellationToken);
		public Task<IList<DocumentDTO>> GetDocuments(CancellationToken cancellationToken) => _readService.GetDocuments(cancellationToken);
		public Task<DocumentDTO> GetDocument(int id, CancellationToken cancellationToken) => _readService.GetDocument(id, cancellationToken);
	}
}
