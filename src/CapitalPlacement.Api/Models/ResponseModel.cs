namespace CapitalPlacement.Api.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public bool HasError { get; set; }
        public string? Message { get; set; }
    }

    public class ResponseModel : ResponseModel<object>
    {

    }
}
