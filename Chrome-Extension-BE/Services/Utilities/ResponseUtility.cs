using FileStorage.API.Models.DTO;

namespace FileStorage.API.Services.Utilities
{
    public static class ResponseUtility
    {
        public static ResponseModel<T> CreateErrorResponse<T>(string? message)
        {
            if (message == null)
            {
                message = "Operation Unsuccessful...Please try again";
            }

            return new ResponseModel<T>
            {
                IsSuccessful = false,
                Message = message,
                Result = default
            };
        }

        public static ResponseModel<T> CreateSuccessResponse<T>(T result, string? message = "")
        {
            return new ResponseModel<T>
            {
                IsSuccessful = true,
                Message = message,
                Result = result
            };
        }
    }

}
