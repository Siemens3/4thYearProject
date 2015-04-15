using ReptileManager.Models;
using System.Web.Mvc;

namespace ReptileManager.Controllers
{
    public class FileController : Controller
    {
        private ReptileContext db = new ReptileContext();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}