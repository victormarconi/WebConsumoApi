using Microsoft.AspNetCore.Mvc;

namespace WebConsumoApi.Controllers
{
    public class ExcelController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveRegistration(HttpPostedFileBase myExcelData)
        {
            if (myExcelData.ContentLength > 0) //checa se o arquivo teve upload
            {
                string filePath = 
            } 
        }
    }
}
