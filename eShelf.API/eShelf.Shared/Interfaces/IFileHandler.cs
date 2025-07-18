using eShelf.Shared.DTOs.iDTO;

namespace eShelf.Shared.Interfaces
{
    public interface IFileHandler
    {
        Task<bool> UploadFileAsync(UploadFileIDTO uploadFileIDTO);

        Task<string> ExtractMetadata(byte[] pdfFile);
    }
}
