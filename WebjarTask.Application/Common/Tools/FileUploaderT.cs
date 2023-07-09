using ErrorOr;
using Microsoft.AspNetCore.Http;
using WebjarTask.Domain.Errors;
using WebjarTask.Application.Common.Enums;

namespace WebjarTask.Application.Common.Tools
{
    public static class FileUploaderT
    {
        public static async Task<ErrorOr<string>> UploadFileAsync(this IFormFile file, string pathWithoutFileName, string deleteFileName = "", FileTypeEnum types = FileTypeEnum.Image,
        string FileName = null)
        {
            if (!Directory.Exists(pathWithoutFileName))
                Directory.CreateDirectory(pathWithoutFileName);

            string FileExtension = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = StringExtentionT.RandomCharString(10) + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                FileName += FileExtension;
            }
            else
            {
                FileName += "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                FileName += FileExtension;
            }
            string SavePath = Path.Combine(pathWithoutFileName, FileName);
            using (MemoryStream memory = new MemoryStream())
            {
                try
                {
                    await file.CopyToAsync(memory);
                }
                catch (Exception e)
                {
                    return VErrors.UploadFile.Unable;
                }
                types = FileExtentionT.GetFileType(file.ContentType);
                if (types == FileTypeEnum.Unknown)
                {
                    return VErrors.UploadFile.Invalid;
                }
                bool result = FileExtentionT.IsValidFile(memory.ToArray(), types, FileExtension.Replace('.', ' '));
                if (result)
                {

                    using (var fileStream = new FileStream(SavePath, FileMode.Create))
                    {
                        try
                        {
                            await file.CopyToAsync(fileStream);
                            if (!string.IsNullOrEmpty(deleteFileName))
                            {
                                var delpath = Path.Combine(pathWithoutFileName, deleteFileName);
                                if (File.Exists(delpath))
                                    File.Delete(delpath);
                            }
                        }
                        catch (Exception e)
                        {
                            await file.CopyToAsync(fileStream).ConfigureAwait(false);
                        }
                    }

                    memory.Flush();
                    memory.Close();
                    return FileName;
                }
                else
                {
                    return VErrors.UploadFile.Invalid;
                }
            }
        }
    }
}
