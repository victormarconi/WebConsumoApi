using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebConsumoApi.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using EFCore.BulkExtensions;
using WebConsumoApi.Models.ViewModels;
using MySqlConnector;
using System.Data.SqlClient;

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
            //  DbProdutosContext dbProdutosContext = new DbProdutosContext();
            //  return View(dbProdutosContext.ProdutoDB.ToList());
            return View();
        }

        [HttpPost]
        public IActionResult MostrarDados([FromForm] IFormFile ArquivoExcel)
        {
            using (Stream stream = ArquivoExcel.OpenReadStream())
            {
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

                int cantidadFilas2 = HojaExcel.LastRowNum;
                int cantidadFilas = HojaExcel.PhysicalNumberOfRows;

                List<VMProduto> lista = new List<VMProduto>();

                for (int i = 1; i <= cantidadFilas2; i++)
                {

                    IRow fila = HojaExcel.GetRow(i);

                    lista.Add(new VMProduto
                    {
                        name = fila.GetCell(0).ToString(),
                        sku = fila.GetCell(1).ToString(),
                        description = fila.GetCell(2).ToString(),
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
                        images = fila.GetCell(16).ToString(),

                    });
                }
                return StatusCode(StatusCodes.Status200OK, lista);
            }          
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
            int cantidadFilas2 = HojaExcel.PhysicalNumberOfRows;

            List<ProdutoDB> lista = new List<ProdutoDB>();
   
             for (int i = 1; i <= cantidadFilas; i++)
            {

                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ProdutoDB
                {
                    Name = fila.GetCell(0).ToString(),
                    Sku = fila.GetCell(1).ToString(),
                    Active = fila.GetCell(2).ToString(),
                    Description = fila.GetCell(3).ToString(),
                    Price = fila.GetCell(4).ToString(),
                    Qty = fila.GetCell(5).ToString(),
                    Ean = fila.GetCell(6).ToString(),
                    SkuManufacturer = fila.GetCell(7).ToString(),
                    NetWeight = fila.GetCell(8).ToString(),
                    GrossWeight = fila.GetCell(9).ToString(),
                    Width = fila.GetCell(10).ToString(),
                    Height = fila.GetCell(11).ToString(),
                    Depth = fila.GetCell(12).ToString(),
                    Guarantee = fila.GetCell(13).ToString(),
                    Origin = fila.GetCell(14).ToString(),
                    Unity = fila.GetCell(15).ToString(),
                    Ncm = fila.GetCell(16).ToString(),
                    Manufacturer = fila.GetCell(17).ToString(),
                    ExtraOperatingTime = fila.GetCell(18).ToString(),
                    Category = fila.GetCell(19).ToString(),
                    Images = fila.GetCell(20).ToString(),
                    Status = fila.GetCell(21).ToString()
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