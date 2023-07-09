using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Domain.Errors
{
    public partial class VErrors
    {
        public static class UploadFile
        {
            public static Error Invalid => Error.Validation(
                code: "File.Invalid",
                description: "فایل نا معتبر است");
            public static Error Unable => Error.Validation(
                code: "File.Unable",
                description: "در آپلود فایل خطایی رخ داده");
        }
    }
}
