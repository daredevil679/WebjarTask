using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebjarTask.Application.Common.Enums;

namespace WebjarTask.Application.Common.Tools
{
    public static class FileExtentionT
    {
        public static string GetContentType(string path)
        {
            Dictionary<string, string> types = GetMimeTypes();
            string ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        public static FileTypeEnum GetFileType(string extension)
        {
            Dictionary<string, string> types = GetMimeTypes();
            foreach (KeyValuePair<string, string> item in types)
            {
                if (item.Value.Replace("-", "") == extension.ToLowerInvariant().Replace("-", ""))
                {
                    string ext = item.Key;
                    FileTypeEnum fileType;
                    switch (ext)
                    {
                        case ".txt":
                            fileType = FileTypeEnum.Text;
                            break;
                        case ".pdf":
                            fileType = FileTypeEnum.PDF;
                            break;
                        case ".doc":
                            fileType = FileTypeEnum.DOC;
                            break;
                        case ".docx":
                            fileType = FileTypeEnum.DOCX;
                            break;
                        case ".xls":
                            fileType = FileTypeEnum.XLS;
                            break;
                        case ".xlsx":
                            fileType = FileTypeEnum.XLSX;
                            break;
                        case ".png":
                            fileType = FileTypeEnum.Image;
                            break;
                        case ".jpg":
                            fileType = FileTypeEnum.Image;
                            break;
                        case ".jpeg":
                            fileType = FileTypeEnum.Image;
                            break;
                        case ".gif":
                            fileType = FileTypeEnum.Image;
                            break;
                        case ".csv":
                            fileType = FileTypeEnum.CSV;
                            break;
                        case ".zip":
                            fileType = FileTypeEnum.ZIP;
                            break;
                        case ".rar":
                            fileType = FileTypeEnum.RAR;
                            break;
                        case ".mp4":
                            fileType = FileTypeEnum.Video;
                            break;
                        case ".apk":
                            fileType = FileTypeEnum.apk;
                            break;
                        default:
                            fileType = FileTypeEnum.Unknown;
                            break;
                    }
                    return fileType;
                }
            }
            return FileTypeEnum.Unknown;

        }
        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".zip","application/zip" },
                {".rar","application/x-rar" },
                {".apk" , "application/vnd.android.package-archive" },
                {".mp4","video/mp4" }
            };
        }
        public static bool IsValidFile(byte[] bytFile, FileTypeEnum flType, string fileContentType)
        {
            bool isvalid = false;

            if (flType == FileTypeEnum.Image)
            {
                isvalid = IsValidImageFile(bytFile, fileContentType);
            }

            return isvalid;
        }
        public static bool IsValidImageFile(byte[] bytFile, string fileContentType)
        {
            bool isvalid = false;

            byte[] chkBytejpg = { 255, 216, 255 };
            byte[] chkBytebmp = { 66, 77 };
            byte[] chkBytegif = { 71, 73, 70, 56 };
            byte[] chkBytepng = { 137, 80, 78, 71 };


            ImageFileExtensionEnum imgfileExtn = ImageFileExtensionEnum.none;
            string toLowerFileContentType = fileContentType.ToLower();
            if (toLowerFileContentType.Contains("jpg") | toLowerFileContentType.Contains("jpeg"))
            {
                imgfileExtn = ImageFileExtensionEnum.jpg;
            }
            else if (toLowerFileContentType.Contains("png"))
            {
                imgfileExtn = ImageFileExtensionEnum.png;
            }
            else if (toLowerFileContentType.Contains("bmp"))
            {
                imgfileExtn = ImageFileExtensionEnum.bmp;
            }
            else if (toLowerFileContentType.Contains("gif"))
            {
                imgfileExtn = ImageFileExtensionEnum.gif;
            }

            if (imgfileExtn == ImageFileExtensionEnum.jpg || imgfileExtn == ImageFileExtensionEnum.jpeg)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 2; i++)
                    {
                        if (bytFile[i] == chkBytejpg[i])
                        {
                            j = j + 1;
                            if (j == 3)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }


            else if (imgfileExtn == ImageFileExtensionEnum.png)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (bytFile[i] == chkBytepng[i])
                        {
                            j = j + 1;
                            if (j == 4)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (imgfileExtn == ImageFileExtensionEnum.bmp)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytebmp[i])
                        {
                            j = j + 1;
                            if (j == 2)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            else if (imgfileExtn == ImageFileExtensionEnum.gif)
            {
                if (bytFile.Length >= 4)
                {
                    int j = 0;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (bytFile[i] == chkBytegif[i])
                        {
                            j = j + 1;
                            if (j == 2)
                            {
                                isvalid = true;
                            }
                        }
                    }
                }
            }
            return isvalid;
        }
    }
}
