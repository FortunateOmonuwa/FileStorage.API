namespace FileStorage.API.Models.DTO
{
    public class ResponseModel<T>
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
      

    }

}
