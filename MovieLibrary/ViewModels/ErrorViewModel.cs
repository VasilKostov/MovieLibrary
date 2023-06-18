namespace MovieLibrary.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public int ErrorCode { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}