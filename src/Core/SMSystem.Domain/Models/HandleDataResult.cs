namespace SMSystem.Domain.Models
{
    public abstract class HandleDataResult<THandleResponse, TModel> : HandleResult<THandleResponse>
        where THandleResponse : HandleDataResult<THandleResponse, TModel>, new()
    {
        public TModel Data { get; set; }

        public virtual THandleResponse Success(TModel data, string message = "")
        {
            base.Success(message);
            Data = data;
            return (THandleResponse)this;
        }

        public virtual THandleResponse Error(string message = "")
        {
            base.Error(message);
            return (THandleResponse)this;
        }
    }
}
