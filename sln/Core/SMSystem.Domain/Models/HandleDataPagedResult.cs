using System.Collections;

namespace SMSystem.Domain.Models
{
    public abstract class HandleDataPagedResult<THandleResponse, TModel> : HandleDataResult<THandleResponse, TModel>
        where THandleResponse : HandleDataPagedResult<THandleResponse, TModel>, new()
        where TModel :  ICollection
    {
        public int TotalCount { get; protected set; }
        public virtual THandleResponse Success(TModel data, int totalCount, string message = "")
        {
            base.Success(data, message);
            TotalCount = totalCount;
            return (THandleResponse)this;
        }

        public override THandleResponse Success(TModel data, string message = "")
        {
            base.Success(data, message);
            TotalCount = data.Count;
            return (THandleResponse)this;
        }
    }
}
