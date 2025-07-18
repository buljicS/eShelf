using eShelf.Shared.Constants;
using eShelf.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShelf.Services
{
    public class FileServices
    {
        private readonly IFileHandler _fileHandler;

        public FileServices(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public async Task<string> UploadBook(IFormFile pdfBook)
        {
            var fileExt = Path.GetExtension(pdfBook.FileName);

            if(FileConstants.AllowedExtensions.Any(ext => ext == fileExt))
            {

            }

            return "File type not allowed";
        }
    }
}
