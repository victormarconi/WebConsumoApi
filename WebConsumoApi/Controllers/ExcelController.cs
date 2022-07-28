using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebConsumoApi.Models;
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
                    id_Item = fila.GetCell(0).ToString(),
                    nome_Item = fila.GetCell(1).ToString(),
                    qtd_Estoque = fila.GetCell(2).ToString(),
                    preco_por = fila.GetCell(3).ToString(),

                });
            }

            return StatusCode(StatusCodes.Status200OK, lista);
        }
    }
}
