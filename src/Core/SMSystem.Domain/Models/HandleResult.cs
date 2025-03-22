namespace SMSystem.Domain.Models
{
    public class HandleResult<THandleResponse>
        where THandleResponse : HandleResult<THandleResponse>, new()
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public virtual THandleResponse Success(string message = "")
        {
            Message = message;
            IsSuccess = true;
            return (THandleResponse)this;
        }

        public virtual THandleResponse Error(string message = "")
        {
            Message = message;
            IsSuccess = false;
            return (THandleResponse)this;
        }
    }
}
