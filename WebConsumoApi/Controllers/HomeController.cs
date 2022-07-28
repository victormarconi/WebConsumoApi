using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebConsumoApi.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using WebConsumoApi.Models.ViewModels;
using EFCore.BulkExtensions;

namespace WebConsumoApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbProdutosContext _dbocontext;

        public HomeController(DbProdutosContext context)
        {
            _dbocontext = context;
        }

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

        public IActionResult Privacy()
        {
            return View();
        }

         [HttpPost]
        public IActionResult EnviarDados([FromForm] IFormFile ArquivoExcel)
        {
            Stream stream = ArquivoExcel.OpenReadStream();

            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArquivoExcel.FileName) == ".xlsx")
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MiExcel.GetSheetAt(0);

            int cantidadFilas = HojaExcel.LastRowNum;

            List<Produto> lista = new List<Produto>();

            for (int i = 1; i <= cantidadFilas; i++)
            {

                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new Produto
                {
                    IdItem = fila.GetCell(0).ToString(),
                    NomeItem = fila.GetCell(1).ToString(),
                    QtdEstoque = fila.GetCell(2).ToString(),
                    PrecoPor = fila.GetCell(3).ToString(),

                });
            }

            _dbocontext.BulkInsert(lista);

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Os dados foram carregados com sucesso!" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}