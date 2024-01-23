namespace FileStorage.API.Models.DTO
{
    public static class ResponseService
    {
        public static string SucessStatus { get; set; } = "Successful";
        public static string SuccessMessage { get; set; } = "Operation was succesful!";
        public static string FailedStatus { get; set; } = "Error";
        public static string FailedMessage { get; set; } = "Something went wrong! Please try again";
    }
}
