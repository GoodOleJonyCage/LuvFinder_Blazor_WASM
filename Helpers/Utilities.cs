using Microsoft.AspNetCore.Http;

namespace LuvFinder_Blazor_WASM.Helpers
{
    public class Utilities
    {
        public static bool IsImage(string ContentType)
        {
            if (ContentType.ToLower() != "image/jpg" &&
                ContentType.ToLower() != "image/jpeg" &&
                ContentType.ToLower() != "image/pjpeg" &&
                ContentType.ToLower() != "image/gif" &&
                ContentType.ToLower() != "image/x-png" &&
                ContentType.ToLower() != "image/png")
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
