namespace Catcher.Web.Models
{
    public class HttpResModel<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public static class ApiCode
    {
        public const string Success = "0000";
        public const string Fail = "9999";
    }
}
