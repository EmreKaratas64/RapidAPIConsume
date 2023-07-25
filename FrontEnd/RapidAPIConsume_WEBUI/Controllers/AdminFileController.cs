using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class AdminFileController : Controller
    {

        [HttpGet]
        public IActionResult UploadImageFile()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImageFile(IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await memoryStream.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();

            ByteArrayContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(content, "file", file.FileName);
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync("http://localhost:5291/api/File", multipartFormDataContent);
            if (result.IsSuccessStatusCode)
                TempData["Success"] = "Resim başarıyla yüklendi";
            return View();
        }
    }
}

