using Microsoft.AspNetCore.Http;

namespace CatWebApp.Models
{
    public class UploadFileModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
