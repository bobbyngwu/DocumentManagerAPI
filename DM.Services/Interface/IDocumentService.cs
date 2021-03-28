using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DM.Data.DTO;
using Microsoft.AspNetCore.Http;

namespace DM.Services.Interface
{
	public interface IDocumentReadService
	{
		Task<IList<DocumentDTO>> GetDocuments(CancellationToken cancellationToken);
		Task<DocumentDTO> GetDocument(int id, CancellationToken cancellationToken);
	}
	public interface IDocumentEditService
	{
		Task<Tuple<string, DocumentProcessingStatusEnum>> CreateDocument(List<IFormFile> files, CancellationToken cancellationToken);
		Task ReorderDocuments(IList<DocumentDTO>  documents, CancellationToken cancellationToken);
		Task<DocumentProcessingStatusEnum> DeleteDocument(int id, CancellationToken cancellationToken);
	}
	public interface IDocumentService : IDocumentReadService, IDocumentEditService
	{
	}
}
