using Microsoft.AspNetCore.Mvc;

namespace ActionresultTypes.Controllers
{
    public class ContentResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ContentResult GetContentResult()
        {
            string content = "Hello ContentResult";
            return Content(content, "text/plain", System.Text.Encoding.UTF8);
        }

        public ContentResult GetHtmlContent()
        {
            string content = "<!DOCTYPE html>" +
                "<html>" +
                "<head lang='en'>" +
                "<meta charset='utf-8'>" +
                "<link rel='stylesheet' href='../lib/bootstrap/dist/css/bootstrap.min.css'>" +
                "</head>" +
                "<body>" +
                "<div class='row'>" +
                "<div class='col-lg-8 col-md-8 col-sm-8'>" +
                "<div class='card'>" +
                "<div class='card-header'> HTML Content" +
                "</div>" +
                "<div class='card-body'>Content Type Html" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</body>" +
                "</html>";

            ContentResult contentResult = new ContentResult();
            contentResult.Content = content;
            contentResult.ContentType = "text/html";
            return contentResult;
        }

        public EmptyResult GetEmptyResult()
        {
            return new EmptyResult();
        }

        //public ContentResult JavaScriptContent()
        //{
        //    string content = "alert('Hello JavaScript Content')";
        //    return Content(content, "application/javascript");
        //}
    }
}
