using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using WebConsumoApi.Models.ViewModels;

namespace WebConsumoApi.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MostrarDados([FromForm] IFormFile ArquivoExcel)
        {
            Stream stream = ArquivoExcel.OpenReadStream();

            IWorkbook MeuExcel = null;

            if (Path.GetExtension(ArquivoExcel.FileName) == ".xlsx")
            {
                MeuExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MeuExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MeuExcel.GetSheetAt(0);

            int cantidadFilas = HojaExcel.LastRowNum;

            List<VMProduto> lista = new List<VMProduto>();

            for (int i = 1; i <= cantidadFilas; i++)
            {

                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new VMProduto
                {
                    name = fila.GetCell(0).ToString(),
                    sku = fila.GetCell(1).ToString(),
                   /*description = fila.GetCell(2).ToString(),
                    price = fila.GetCell(3).ToString(),
                    qty = fila.GetCell(4).ToString(),
                    ean = fila.GetCell(5).ToString(),
                    sku_manufacturer = fila.GetCell(6).ToString(),
                    net_weight = fila.GetCell(7).ToString(),
                    gross_weight = fila.GetCell(8).ToString(),
                    width = fila.GetCell(9).ToString(),
                    height = fila.GetCell(10).ToString(),
                    depth = fila.GetCell(11).ToString(),
                    guarantee = fila.GetCell(12).ToString(),
                    ncm = fila.GetCell(13).ToString(),
                    manufacturer = fila.GetCell(14).ToString(),
                    category = fila.GetCell(15).ToString(),
                    images = fila.GetCell(16).ToString(), */

                });
            }

            return StatusCode(StatusCodes.Status200OK, lista);
        }
    }
}
