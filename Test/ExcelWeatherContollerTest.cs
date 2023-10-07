using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Models;
using Xunit;

namespace Test
{
    internal static class ExcelWeatherContollerTest
    {
        public static void ReadExcelTest(Stream FilePath) 
        {
            IEnumerable<Weather> list;

            list = ExcelWeatherController.ReadExcel(FilePath);

            Assert.Equal(2160, list.Count());
        }
    }
}
