using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DM.Data.DTO;
using DM.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DM.Services.Implementation
{
	public class FileStorageService : IFileStorageService
	{
		private readonly ILogger<FileStorageService> _logger;
		IOptionsSnapshot<DocumentUploadConfig> _documentUploadConfig;
		private string mediaDirPath;
		private string fileDirPath;
		public FileStorageService(ILogger<FileStorageService> logger, IOptionsSnapshot<DocumentUploadConfig> documentUploadConfig)
		{
			_logger = logger;
			_documentUploadConfig = documentUploadConfig;
			// may consider pointing this to some other ftp or some other location. If using a cloud filestorage service, consider creating a separate service for that
			// remember to check that permissions are granted for the dir you may wish to access
			mediaDirPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
			mediaDirPath = Path.Combine(mediaDirPath, _documentUploadConfig?.Value.LocalMediaDir);
		}
		public async Task<string> Save(IFormFile file, CancellationToken cancellationToken)
		{
			// implement BL here
			CheckDirExists(mediaDirPath, true);
			if (file == null || file.Length < 1)
				return null;
			string fileName = Guid.NewGuid().ToString();
			string fullFileName = null;
			try
			{
				while (File.Exists(Path.Combine(mediaDirPath, fileName)))
				{
					fileName = Guid.NewGuid().ToString();
				}
				string fileExtension = Path.GetExtension(file.FileName);
				fullFileName = $"{fileName}{fileExtension}";
				string filePath = Path.Combine(mediaDirPath, fullFileName);
				using (Stream stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
			}
			catch (Exception exception)
			{
				_logger.LogError("File Save Operation", exception);
				throw new Exception("Could not complete the File Save Operation");
			}

			return fullFileName;
		}
		public async Task Delete(string fileName, CancellationToken cancellationToken)
		{
			CheckDirExists(mediaDirPath, true);
			// check the file exists, then delete
			string filePath = Path.Combine(mediaDirPath, fileName);
			try
			{
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				}
			}
			catch (Exception exception)
			{
				_logger.LogError("File Delete Operation: Error accessing files", exception);
				throw new Exception("Could not complete the Delete Operation");
			}
		}
		public Task<string> GetFilePath(string fileName, CancellationToken cancellationToken) => Task.FromResult(Path.Combine(mediaDirPath, fileName));
		public Task<string> GetMimeType(string fileName)
		{
			if (!string.IsNullOrEmpty(fileName))
			{
				//ToDo: determine appropriate mime type from extension by searching a list of known mime types
				return Task.FromResult("application/pdf");
			}
			return Task.FromResult("application/octet-stream");
		}

		private void CheckDirExists(string dirPath, bool createIfNotExist)
		{
			if (!string.IsNullOrEmpty(_documentUploadConfig?.Value.LocalMediaDir)) 
			{ 
				if (!Directory.Exists(dirPath) && createIfNotExist)
				{
					Directory.CreateDirectory(dirPath);
				}
			}
			else
			{
				throw new InvalidOperationException($"Local Media Dir Value is not set in Env Variable");
			}
		}
	}
}
