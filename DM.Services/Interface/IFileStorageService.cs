using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DM.Services.Interface
{
	public interface IFileStorageService
	{
		Task<string> Save(IFormFile file, CancellationToken cancellationToken);
		Task Delete(string fileName, CancellationToken cancellationToken);
		Task<string> GetFilePath(string fileName, CancellationToken cancellationToken);
		Task<string> GetMimeType(string fileName);
	}
}
