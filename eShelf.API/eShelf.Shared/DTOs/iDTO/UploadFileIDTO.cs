using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShelf.Shared.DTOs.iDTO
{
    public class UploadFileIDTO
    {
        public required Stream FileBytes { get; set; }
        public required string FileName { get; set; }
        public required string FileExtension { get; set; }
        public required double FileSize { get; set; }
    }
}
