namespace SMSystem.Desktop.Models
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public virtual Result Success(string message = "")
        {
            Message = message;
            IsSuccess = true;
            return this;
        }

        public virtual Result Error(string message = "")
        {
            Message = message;
            IsSuccess = false;
            return this;
        }
    }
}
