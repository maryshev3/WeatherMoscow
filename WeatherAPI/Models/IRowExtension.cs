using NPOI.SS.UserModel;

namespace WeatherAPI.Models
{
    public static class IRowExtension
    {
        public static Weather WeatherRowValue(this IRow Row)
        {
            return new Weather()
            {
                Date = DateOnly.Parse(Row.GetCell(0).StringCellValue),
                Time = TimeOnly.Parse(Row.GetCell(1).StringCellValue),
                Temperature = Convert.ToDouble(Row.GetCell(2).NumericCellValue),
                Humidity = Convert.ToInt32(Row.GetCell(3).NumericCellValue),
                DewPoint = Convert.ToDouble(Row.GetCell(4).NumericCellValue),
                Presure = Convert.ToInt32(Row.GetCell(5).NumericCellValue),
                WindDirection = Row.GetCell(6).StringCellValue,
                WindSpeed = Convert.ToInt32(Row.GetCell(7).NumericCellValue),
                Cloudy = Row.GetCell(8).CellType == CellType.String ? null : Convert.ToInt32(Row.GetCell(8).NumericCellValue),
                HighBorderCloudy = Convert.ToInt32(Row.GetCell(9).NumericCellValue),
                HorizontalVisibility = Row.GetCell(10).CellType == CellType.String ? null : Convert.ToInt32(Row.GetCell(10).NumericCellValue),
                WeatherСonditions = Row.GetCell(11)?.StringCellValue
            };
        }
    }
}
