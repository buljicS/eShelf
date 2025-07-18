using eShelf.Shared.Utils;
using eShelf.Shared.DTOs.iDTO;
using System.Reflection.PortableExecutable;
using eShelf.Domain.Context;
using eShelf.Shared.Interfaces;

namespace eShelf.Infrastructure.FileManager
{
    public class FileManager : IFileHandler
    {
        public Task<string> ExtractMetadata(byte[] pdfFile)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadFileAsync(UploadFileIDTO uploadFileIDTO)
        {
            throw new NotImplementedException();
        }
    }
}
