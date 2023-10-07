using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Linq;

namespace WeatherAPI.Models
{
    public static class ExcelWeatherController
    {
        public async static Task<IEnumerable<Weather>> ReadExcelAsync(Stream File)
        {
            return await Task<IEnumerable<Weather>>.Run
                (
                    () =>
                    {
                        List<Weather> Weathers = new List<Weather>();

                        // Открытие существующей рабочей книги
                        IWorkbook Workbook = new XSSFWorkbook(File);

                        //Первые 4 строки таблицы - заголовок
                        foreach (var Sheet in Workbook)
                            foreach (IRow Row in Sheet)
                                if (Row.RowNum >= 4)
                                    try
                                    {
                                        Weathers.Add(Row.WeatherRowValue());
                                    }
                                    catch
                                    {
                                        continue;
                                    }

                        return Weathers;
                    }
                );
            
        }
    }
}
