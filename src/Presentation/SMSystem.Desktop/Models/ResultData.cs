namespace SMSystem.Desktop.Models
{
    public class ResultData<TModel> : Result
    {
        public TModel Data { get; set; }

        public virtual ResultData<TModel> Success(TModel data, string message = "")
        {
            base.Success(message);
            Data = data;
            return this;
        }

        public virtual ResultData<TModel> Error(string message = "")
        {
            base.Error(message);
            return this;
        }
    }
}
