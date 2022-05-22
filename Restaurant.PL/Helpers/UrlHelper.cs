using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Restaurant.PL.Helpers
{
    public static class UrlHelper
    {
        public static string GetUrlForImage(HttpContext context, string photoName, string fileExtension = "jpg")
        {
            var name = string.Concat(photoName.Where(c => !char.IsWhiteSpace(c)));
            return $"{context.Request.Scheme}://" +
                   $"{context.Request.Host}/" +
                   $"images/{name}.{fileExtension}";
        }
    }
}
