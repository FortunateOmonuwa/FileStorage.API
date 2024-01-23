using FileStorage.API.Models.DTO;
using System.Text.RegularExpressions;

namespace FileStorage.API.Services.Utilities
{
    public static class Helper_Methods
    {
        public static bool ConfirmRegex(string prop, string regex)
        {
            if(!Regex.IsMatch(regex, prop))
            {
                return false;
            }
            else
            {
                return true;
            }
                
        }



    }
}
