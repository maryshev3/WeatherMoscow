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
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly AppDbContext _appDbContext;

        private static int RecordsInPage = 50;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext AppDbContext)
        {
            _logger = logger;
            _appDbContext = AppDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [EnableCors]
        public async Task<List<Weather>> Get(int PageNum)
        {
            return await _appDbContext.Weathers.Skip((PageNum - 1) * RecordsInPage).Take(RecordsInPage).ToListAsync();
        }

        [HttpPost(Name = "PostWeatherForecast")]
        [EnableCors]
        public async Task PostAsync(List<IFormFile> FormFile)
        {

            foreach(var File in FormFile)
                _appDbContext.AddRange(await ExcelWeatherController.ReadExcelAsync(File.OpenReadStream()));

            await _appDbContext.SaveChangesAsync();
        }
    }
}