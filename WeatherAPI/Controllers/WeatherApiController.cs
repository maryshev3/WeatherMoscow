using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherApiController : ControllerBase
    {
        private readonly ILogger<WeatherApiController> _logger;

        private readonly AppDbContext _appDbContext;

        private static int RecordsInPage = 50;

        public WeatherApiController(ILogger<WeatherApiController> logger, AppDbContext AppDbContext)
        {
            _logger = logger;
            _appDbContext = AppDbContext;
        }

        [HttpGet]
        [EnableCors]
        public async Task<List<Weather>> GetPageAsync(int PageNum)
        {
            return await _appDbContext.Weathers.Skip((PageNum - 1) * RecordsInPage).Take(RecordsInPage).ToListAsync();
        }

        [HttpGet("/GetYear")]
        [EnableCors]
        public async Task<List<Weather>> GetYearAsync(int Year, int PageNum)
        {
            return await _appDbContext.Weathers.Where(x => x.Date.Year == Year).Skip((PageNum - 1) * RecordsInPage).Take(RecordsInPage).ToListAsync();
        }

        [HttpGet("/GetMonth")]
        [EnableCors]
        public async Task<List<Weather>> GetMonthAsync(int Month, int PageNum)
        {
            return await _appDbContext.Weathers.Where(x => x.Date.Month == Month).Skip((PageNum - 1) * RecordsInPage).Take(RecordsInPage).ToListAsync();
        }

        [HttpGet("/GetYearAndMonth")]
        [EnableCors]
        public async Task<List<Weather>> GetYearAndMonthAsync(int Year, int Month, int PageNum)
        {
            return await _appDbContext.Weathers.Where(x => x.Date.Month == Month && x.Date.Year == Year).Skip((PageNum - 1) * RecordsInPage).Take(RecordsInPage).ToListAsync();
        }

        [HttpPost]
        [EnableCors]
        public async Task PostAsync([FromForm]List<IFormFile> FormFile)
        {

            foreach(var File in FormFile)
                _appDbContext.AddRange(await ExcelWeatherController.ReadExcelAsync(File.OpenReadStream()));

            await _appDbContext.SaveChangesAsync();
        }
    }
}