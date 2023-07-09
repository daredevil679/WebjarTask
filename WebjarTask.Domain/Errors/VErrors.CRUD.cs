using ErrorOr;

namespace WebjarTask.Domain.Errors
{
    public partial class VErrors
    {
        public static class CRUD
        {
            public static Error Create => Error.Validation(
                code: "CRUD.Create",
                description: "در ایجاد دیتا خطایی رخ داده");
            public static Error Update => Error.Validation(
                code: "CRUD.Update",
                description: "در به روز رسانی دیتا خطایی رخ داده");
            public static Error Read => Error.Validation(
                code: "CRUD.Read",
                description: "در خواندن دیتا خطایی رخ داده");
            public static Error Delete => Error.Validation(
                code: "CRUD.Delete",
                description: "در حذف دیتا خطایی رخ داده");
            public static Error Invalid => Error.Validation(
                code: "CRUD.Invalid",
                description: "درخواست نامعتبر");
        }
    }
}
